using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Mars.Rovers.Navigation
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = ValidateInput(args);

            if (!result.Any())
            {
                foreach (var error in result)
                {
                    WriteLineWithColor(error.Message, ConsoleColor.Red);
                }
                return;
            }

            var lines = File.ReadAllLines(args[0]);
            var platueaXY = lines[0].Split(' ');
            Plateau plateau = new Plateau(int.Parse(platueaXY[0]), int.Parse(platueaXY[1]));
            var j = 1;

            for (int i = 1; i < lines.Length; i += 2)
            {
                var pos = lines[i].Split(' ');
                var x = int.Parse(pos[0]);
                var y = int.Parse(pos[1]);
                var orientation = (Orientation)Enum.Parse(typeof(Orientation), pos[2],ignoreCase: true);

                Position position = new Position(x, y, orientation);
                Rover rover = new Rover(plateau, position);

                var instruction = lines[i + 1];
                rover.ActionCommands(instruction);
                WriteLineWithColor($"Rover {j} :"+ rover.PrintPosition(), ConsoleColor.Green);
                j++;
            }

        }
        
        static IEnumerable<Result> ValidateInput(string[] args)
        {

            if(args.Length != 1)
                 yield return new Result("Please only input the text file's full path.");

            if(!File.Exists(args[0]))
                yield return new Result("Can't find the text file, please check the file and try again.");

            var lines = File.ReadAllLines(args[0]);

            if(lines.Length < 3)
                yield return new Result("Some instuctions are missing, please complete at least 3 lines of instructions.");

            if (!System.Text.RegularExpressions.Regex.IsMatch(lines[0], "[0-9] [0-9]$"))
                yield return new Result("The plateau's height and width are not in the correct formate.");

            string oddRegex = "[0-9] [0-9] [NnWwSsEe]$";
            string evenRegex = "[LlMmRr]$";
            
            for (int i = 1; i < lines.Length; i++)
            {
                bool odd = i % 2 != 0;
                
                if (odd && (!System.Text.RegularExpressions.Regex.IsMatch(lines[i], oddRegex)))
                    {
                        yield return new Result("Some instuctions are not in the right formate.");
                        break;
                    }
                
                if (!odd && (!System.Text.RegularExpressions.Regex.IsMatch(lines[i], evenRegex)))
                {
                        yield return new Result("Some instuctions are not in the right formate.");
                        break;
                }
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
