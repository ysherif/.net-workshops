using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Rovers.Navigation
{
    class Program
    {
        static void Main(string[] args)
        {

            args = new string[] { "5", "5" ,"1", "2", "N" ,"LMLMLMLMM", "3" ,"3" ,"E" ,"MMRMMRMRRM"};
            
            var result = ValidateInput(args);

            if (!result.Count().Equals(0))
            {
                result.ToList().ForEach(o => { WriteLineWithColor(o.Message, ConsoleColor.Red); });
                return;
            }
            
            Command roverCommand = new Command(args);
            
            Plateau plateau = new Plateau(roverCommand.PlateauWidth, roverCommand.PlateauHeight);

            Position positionOne = new Position(roverCommand.RoverOneCurrentX, roverCommand.RoverOneCurrentY, roverCommand.RoverOneOrientation);
            Position positionTwo = new Position(roverCommand.RoverTwoCurrentX, roverCommand.RoverTwoCurrentY, roverCommand.RoverTwoOrientation);

            Rover roverOne = new Rover(plateau, positionOne);
            Rover roverTwo = new Rover(plateau, positionTwo);

            roverOne.ActionCommands(roverCommand.RoverOneDirections);
            roverTwo.ActionCommands(roverCommand.RoverTwoDirections);
         
            Console.WriteLine(string.Concat(roverOne.PrintPosition()," ", roverTwo.PrintPosition()));
        }


        static IEnumerable<Result> ValidateInput(string[] args)
        {
            //if (args.Length != 10)
             //   yield return new Result("The number of arguments doesn't match the required number.");

            string regex = "[0-9] [0-9] [0-9] [0-9] [A-Z] [A-Z]* [0-9] [0-9] [A-Z] [A-Z]*";

            string joinedArgs = string.Join(" ", args);

            if (!System.Text.RegularExpressions.Regex.IsMatch(joinedArgs, regex))
            {
                yield return new Result("The input is not valid, please enter a valid input. Example: 5 5 1 2 N LMLMLMLMM 3 3 E MMRMMRMRRM");
            }

        }


        struct Result
        {
            public Result(string message)
            {
                Message = message;
            }
            public string Message { get; set; }
        }

        private static void WriteLineWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
