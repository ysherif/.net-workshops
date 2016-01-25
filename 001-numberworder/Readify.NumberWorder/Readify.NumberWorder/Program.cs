using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Readify.NumberWorder
{
    class Program
    {
        static void Main(string[] args)
        {
                var numbersDictionary = new Dictionary<char, string>() {
                    { '0', "ZERO" },
                    { '1', "ONE" },
                    { '2', "TWO" },
                    { '3', "THREE" },
                    { '4', "FOUR" },
                    { '5', "FIVE" },
                    { '6', "SIX" },
                    { '7', "SEVEN" },
                    { '8', "EIGHT" },
                    { '9', "NINE" },
                };
                
                var result = ValidateInput(args);

                if (!result.Count().Equals(0))
                {
                    result.ToList().ForEach(o => { WriteLineWithColor(o.Message, ConsoleColor.Red); });
                    return;
                }
                
                var words = string.Join(string.Empty, args[0].Select(i => numbersDictionary[i]));

                WriteLineWithColor(string.Format("Output: {0}", words), ConsoleColor.Green);
            
        }
        
        private static void WriteLineWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static IEnumerable<Result> ValidateInput(string[] args)
        {
            var validationResult = new List<Result>();

            if (args.Length == 0)
             yield return new Result() { Message = "Please make sure that the input is not empty." };
            
            if (args.Length > 1)
                yield return new Result() { Message = "Please make sure there is only one input without spaces." };

            if (!System.Text.RegularExpressions.Regex.IsMatch(args[0], "^[0-9]*$"))
                yield return new Result() { Message = "Please make sure that the input contains only numbers." };
        }

        }
        struct Result
    {
        public string Message { get; set; }
    }

    }

    

