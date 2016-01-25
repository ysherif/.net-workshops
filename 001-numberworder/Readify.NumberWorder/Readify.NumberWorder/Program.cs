using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readify.NumberWorder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            { 
                if (args.Length == 0)
                    throw new ArgumentNullException();

                int number;
                
                if (!args[0].All(o => int.TryParse(o.ToString(), out number)))
                    throw new InvalidCastException();
                
               var words = string.Join(string.Empty, args[0].Select(o => int.Parse(o.ToString())).Select(i => GetWordsFromNumber(i)));
                
                WriteLineWithColor(string.Format("Output: {0}", words), ConsoleColor.Green);

            }
            catch(ArgumentNullException)
            {
                WriteLineWithColor("Please make sure that the input is not empty.", ConsoleColor.Red);
            }
            catch (InvalidCastException)
            {
                WriteLineWithColor("Please make sure that the input contains only numbers.", ConsoleColor.Red);
            }
            catch (Exception ex)
            {
                WriteLineWithColor(ex.Message, ConsoleColor.Red);
            }
        }

        private static string GetWordsFromNumber(int number)
        {

            switch (number)
            {
                case 0:
                    return "ZERO";

                case 1:
                   return "ONE";

                case 2:
                    return "TWO";

                case 3:
                    return "THREE";

                case 4:
                    return "FOUR";

                case 5:
                    return "FIVE";

                case 6:
                    return "SIX";

                case 7:
                    return "SEVEN";

                case 8:
                    return "EIGHT";
                    
                case 9:
                    return "NINE";

                default: return string.Empty; 
            }
        }
        
        private static void WriteLineWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        }
    }

    

