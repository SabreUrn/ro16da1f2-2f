using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackPacking.Item;

namespace BackPacking.Algorithms {
    class BackPackingSolverAmount : BackPackingSolverBase {
        public BackPackingSolverAmount(List<BackPackItem> items, double capacity)
            : base(items, capacity) {
        }

        public override void Solve(double capacityLeft) {
            //sort by weight
            List<BackPackItem> items = new List<BackPackItem>();
            foreach (BackPackItem item in TheVault.Items) {
                items.Add(item);
            }
            items = items.OrderBy(o => o.Weight).ToList();
            items.Reverse();


            if (items[0].Weight <= capacityLeft) {
                BackPackItem item = TheVault.RemoveItem(items[0].Description); //vault remove item
                TheBackPack.AddItem(items[0]); //backpack add item
                Solve(TheBackPack.WeightCapacityLeft); //recursive
            }
        }
    }
}
