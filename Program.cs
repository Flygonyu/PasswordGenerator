using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace PasswordGenerator
{
    internal class Program
    {
        static readonly Random random = new Random();
        static void Main(string[] args)
        {
            
            int length = Convert.ToInt32(args[0]);
            string pattern = args[1].PadRight(length, 'l');
            Console.WriteLine(pattern);

            if (!IsValid(args))
            {
                ShowHelpText();
                return;
            }     
            
            while (pattern.Length >= 1)
            {
                int randomLetter = random.Next(pattern.Length - 1);
                string removedString = pattern.Remove(randomLetter, 1);
                char removedLetter = pattern[randomLetter];

                if (removedLetter == 'l') Console.Write(WriteRandomLowerCaseLetter());
                else if (removedLetter == 'L') Console.Write(WriteRandomUpperCaseLetter());
                else if (removedLetter == 'd') Console.Write(WriteRandomDigit());
                else if (removedLetter == 's') Console.Write(WriteRandomSpecialCharacter());
                pattern = removedString;
            }
        }

        static void ShowHelpText()
        {
            Console.WriteLine("PasswordGenerator  \r\n  Options:\r\n  - l = lower case letter\r\n  - L = upper case letter\r\n  - d = digit\r\n  - s = special character (!\"#¤%&/(){}[]\r\nExample: PasswordGenerator 14 lLssdd\r\n         Min. 1 lower case\r\n         Min. 1 upper case\r\n         Min. 2 special characters\r\n         Min. 2 digits");
        }

        static bool IsValid(string[] args)
        {
            if (args.Length == 2)
            {
                if (!IsNum(args[0]) || !IsLlds(args[1])) return false;
                else return true;
            }
            else return false;
        }
        //int.TryParse(args[0], out int value)

        static bool IsNum(string args)
        {
            foreach (char chara in args)
            {
                if (char.IsDigit(chara)) return true;
                else return false;
                       
            }
            return false;
        }

        static bool IsLlds(string args)
        {
            foreach (char chara in args)
            {
                string lLds = "lLds";
                if (!lLds.Contains(chara)) return false;
                //if (chara != 'L' && chara != 'l' && chara != 'd' && chara != 's') return false;
                //else return true;
            }
            return true;
        }

        static char WriteRandomLowerCaseLetter()
        {
            return (char)random.Next(97, 122);
        }
        static char WriteRandomUpperCaseLetter()
        {
            return (char)random.Next(65, 90);
        }
        static int WriteRandomDigit()
        {
            return random.Next(1, 20);
        }
        static char WriteRandomSpecialCharacter()
        {
            string specialCharacters = "¤%§&#$@";
            int index = random.Next(specialCharacters.Length);
            return specialCharacters[index];
        }
    }
}