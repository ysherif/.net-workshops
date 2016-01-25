
namespace Mars.Rovers.Navigation
{
    public class Rover
    {
        Position _currentPosition;
        Plateau _plateau;
        
        public Rover(Plateau plateau, Position position)
        {
            _currentPosition = position;
            _plateau = plateau;
        }

        public void MoveForward()
        {
                switch (_currentPosition.orientation)
                {
                    case Orientation.N:
                    _currentPosition.incrementY(_plateau.Height);
                        break;

                    case Orientation.E:
                    _currentPosition.incrementX(_plateau.Width);
                        break;

                    case Orientation.S:
                    _currentPosition.decreamentY();
                        break;

                    case Orientation.W:
                    _currentPosition.decreamentX();
                        break;
             
            }
        }

        public void TurnLeft()
        {
           
            switch (_currentPosition.orientation)
            {
                case Orientation.N:
                    _currentPosition.orientation = Orientation.W;
                    break;
                case Orientation.E:
                    _currentPosition.orientation = Orientation.N;
                    break;
                case Orientation.S:
                    _currentPosition.orientation = Orientation.E;
                    break;
                case Orientation.W:
                    _currentPosition.orientation = Orientation.S;
                    break;
            }

        }

        public void TurnRight()
        {

            switch (_currentPosition.orientation)
            {
                case Orientation.N:
                    _currentPosition.orientation = Orientation.E;
                    break;
                case Orientation.E:
                    _currentPosition.orientation = Orientation.S;
                    break;
                case Orientation.S:
                    _currentPosition.orientation = Orientation.W;
                    break;
                case Orientation.W:
                    _currentPosition.orientation = Orientation.N;
                    break;
            }

        }

        public void ActionCommand(char commandSymbol)
        {
            switch (commandSymbol)
            {
                case 'M': MoveForward();
                    break;
                case 'L': TurnLeft();
                    break;
                case 'R':TurnRight();
                    break;
            }
        }

        public string PrintPosition()
        {
            return _currentPosition.ToString();
        }
    }

    

    

   

}
