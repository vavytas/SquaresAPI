using System.ComponentModel.DataAnnotations;

namespace SquaresAPIHomework.Entities
{
    public class OnePoint
    {
        [Key]
        public int PointId { get; set; }

        public double XProp { get; set; }
        public double YProp { get; set; }

        public OnePoint(int pointId, double xprop, double yprop)
        {
            this.PointId = pointId;
            this.XProp = xprop;
            this.YProp = yprop;
        }

        public OnePoint(double xprop, double yprop)
        {
            this.XProp = xprop;
            this.YProp = yprop;
        }

        public OnePoint()
        {
        }

        // Find the distance between two points
        public double FindDistance(OnePoint pointB)
        {
            return Math.Sqrt(Math.Pow(XProp - pointB.XProp, 2) + Math.Pow(YProp - pointB.YProp, 2));
        }

    }
}
