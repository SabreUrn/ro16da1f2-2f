using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackPacking.Item;

namespace BackPacking.Algorithms {
    /// <summary>
    /// This class tries to fit as many items as possible into
    /// the backpack by sorting them by least weight.
    /// </summary>
    public class BackPackingSolverRatio : BackPackingSolverBase {
        public BackPackingSolverRatio(List<BackPackItem> items, double capacity)
            : base(items, capacity) {
        }

        public override void Solve(double capacityLeft) {
            BackPackItem currentItem = TheVault.Items[0];
            foreach(BackPackItem item in TheVault.Items) {
                if((item.Value / item.Weight) > (currentItem.Value / currentItem.Weight)) {
                    currentItem = item;
                }
            }

            if (currentItem.Weight <= capacityLeft) {
                TheVault.RemoveItem(currentItem.Description);
                TheBackPack.AddItem(currentItem);
                Solve(TheBackPack.WeightCapacityLeft);
            } else { //most valuable item (by ratio) weighs more than we have room for
                List<BackPackItem> lowWeightItems = new List<BackPackItem>();
                foreach (BackPackItem item in TheVault.Items) {
                    if (item.Weight < capacityLeft) {
                        lowWeightItems.Add(item);
                    }
                }
                lowWeightItems = lowWeightItems.OrderBy(o => o.Value).ToList();

                if (lowWeightItems.Count > 0) {
                    if (lowWeightItems[0].Weight <= capacityLeft) {
                        TheVault.RemoveItem(lowWeightItems[0].Description);
                        TheBackPack.AddItem(lowWeightItems[0]);
                        Solve(TheBackPack.WeightCapacityLeft);
                    }
                }
            }
        }
    }
}