namespace Mars.Rovers.Navigation
{
    public interface IRover
    {
        void MoveForward();
        void TurnLeft();
        void TurnRight();
        void ActionCommand(char commandSymbol);
        string PrintPosition();
    }
}
