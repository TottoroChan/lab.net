namespace Task1
{
    public class Point
    {
        private double x, y;

        public void set(double x1, double y1)
        {
            x = x1;
            y = y1;
            return;
        }
        public void get(out double x1, out double y1)
        {
            x1 = x;
            y1 = y;
            return;
        }

        public Point()
        {
            x = 0;
            y = 0;
        }
        public Point(double x1, double y1)
        {
            x = x1;
            y = y1;

        }
    }
}
