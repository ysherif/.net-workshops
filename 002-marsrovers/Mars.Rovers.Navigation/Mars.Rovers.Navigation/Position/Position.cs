namespace Mars.Rovers.Navigation
{
    public class Position:IPosition
    {
        public Position(int x, int y, Orientation or)
        {
            Xcoordinates = x;
            Ycoordinates = y;
            orientation = or;
        }

        public void incrementX(int max)
        {
            if (Xcoordinates < max)
                Xcoordinates++;
        }
        public void decreamentX()
        {
            if (Xcoordinates > 0)
                Xcoordinates--;
        }

        public void incrementY(int max)
        {
            if (Ycoordinates < max)
                Ycoordinates++;
        }
        public void decreamentY()
        {
            if (Ycoordinates > 0)
                Ycoordinates--;
        }

        public int Xcoordinates { get; set; }
        public int Ycoordinates { get; set; }
        public Orientation orientation { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Xcoordinates, Ycoordinates, orientation.ToString());
        }
    }

    public enum Orientation
    {
        N,
        E,
        S,
        W
    }
}
