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
            var result = ValidateInput(args);

            if (!result.Count().Equals(0))
            {
                result.ToList().ForEach(o => { WriteLineWithColor(o.Message, ConsoleColor.Red); });
                return;
            }
            
            Command roverOneCommand = new Command(args.Take(6).ToArray(),true);
            Command roverTwoCommand = new Command(args.Skip(6).ToArray(),false);
            
            Plateau plateau = new Plateau(roverOneCommand.PlateauWidth, roverOneCommand.PlateauHeight);

            Position positionOne = new Position(roverOneCommand.CurrentX, roverOneCommand.CurrentY, roverOneCommand.Orientation);
            Position positionTwo = new Position(roverTwoCommand.CurrentX, roverTwoCommand.CurrentY, roverTwoCommand.Orientation);

            Rover roverOne = new Rover(plateau, positionOne);
            Rover roverTwo = new Rover(plateau, positionTwo);

            roverOne.ActionCommands(roverOneCommand.Directions);
            roverTwo.ActionCommands(roverTwoCommand.Directions);

            WriteLineWithColor(string.Concat(roverOne.PrintPosition()," ", roverTwo.PrintPosition()),ConsoleColor.Green);
        }


        static IEnumerable<Result> ValidateInput(string[] args)
        {
            if (args.Length != 10)
                yield return new Result("The number of arguments doesn't match the required number.");

            string regex = "[0-9] [0-9] [0-9] [0-9] [A-Z] [A-Z]* [0-9] [0-9] [A-Z] [A-Z]*";

            string joinedArgs = string.Join(" ", args);

            if (!System.Text.RegularExpressions.Regex.IsMatch(joinedArgs, regex))
                yield return new Result("The input is not valid, please enter a valid input. Example: 5 5 1 2 N LMLMLMLMM 3 3 E MMRMMRMRRM");
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
