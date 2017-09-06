using System;

namespace GenericsDogsAndCircles {
    public class Circle : IComparable<Circle> {
        #region Instance fields
        private double _radius;
        private double _x;
        private double _y;
        #endregion

        #region Constructor
        public Circle(double radius, double x, double y) {
            _radius = radius;
            _x = x;
            _y = y;
        }
        #endregion

        #region Properties
        public double Radius {
            get { return _radius; }
        }

        public double X {
            get { return _x; }
        }

        public double Y {
            get { return _y; }
        }

        public double Area {
            get { return Math.PI * Radius * Radius; }
        }
        #endregion

        #region Methods
        public int CompareTo(Circle other) {
            if(this.Area > other.Area) {
                return 1; //we're larger than the other
            } else if(other.Area > this.Area) {
                return -1; //the other is larger than us
            }
            return 0; //neither is larger
        }

        public override string ToString() {
            return "Circle at (" + X + "," + Y + ") has an area of " + Area.ToString().Substring(0, 6);
        }
        #endregion
    }
}