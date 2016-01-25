namespace Mars.Rovers.Navigation
{
    public class Plateau
    {
        public Plateau(int width, int height)
        {
            Height = height;
            Width = width;
        }

        public int Height { get; set; }
        public int Width { get; set; }
    }
}
