using Snake.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public delegate void ReadLineHitLimit(int limit);
    public delegate void ReadLineBadCharacter(ConsoleKeyInfo attemptedKey);

    static class Utils
    {
        static Random r = new Random();

        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        public static T[] AppendOrReplace<T>(T[] array, T newValue)
        {
            for (int aI = 0; aI < array.Length; aI++)
            {
                if (array[aI] == null)
                {
                    array[aI] = newValue;
                    return array;
                }
            }

            T[] newArray = new T[array.Length];
            for (int rI = 1; rI < array.Length; rI++)
            {
                newArray[rI - 1] = array[rI];
            }
            newArray[array.Length - 1] = newValue;
            return newArray;
        }

        public static T GetRandomElementWithProbabilities<T>(List<KeyValuePair<T, double>> elements)
        {
            double rInt = r.NextDouble();

            double cumulative = 0.0;
            for (int i = 0; i < elements.Count; i++)
            {
                cumulative += elements[i].Value;
                if (rInt < cumulative)
                {
                    return elements[i].Key;
                }
            }
            return default(T);
        }

        public static bool RandomBool()
        {
            return r.Next() % 2 == 0;
        }

        public static string SHA256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static event ReadLineHitLimit ReadLineHitLimitEvent;
        public static event ReadLineBadCharacter ReadLineBadCharacterEvent;

        public static string ReadLine(InputMode inputMode, int limit = int.MaxValue, bool password = false)
        {
            string input = "";

            string alphaSet = "abcdefghijklmnopqrstuvwxyz";
            string numSet = "0123456789";
            for (;;)
            {
                ConsoleKeyInfo currentCharacter = Console.ReadKey(true);
                
                if (currentCharacter.Key == ConsoleKey.Backspace)
                {
                    if (input != "")
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        input = input.Substring(0, input.Length - 1);
                    }
                }
                else if (currentCharacter.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (input.Length >= limit)
                {
                    ReadLineHitLimitEvent(limit);
                    continue;
                }
                else if (alphaSet.Contains(currentCharacter.KeyChar.ToString().ToLower()) && (inputMode & InputMode.Alphabetical) != 0)
                {
                    Console.Write(password ? '*' : currentCharacter.KeyChar);
                    input += currentCharacter.KeyChar;
                }
                else if (numSet.Contains(currentCharacter.KeyChar.ToString()) &&
                         (inputMode & InputMode.Numerical) != 0)
                {
                    Console.Write(password ? '*' : currentCharacter.KeyChar);
                    input += currentCharacter.KeyChar;
                }
                else if ((currentCharacter.Key >= ConsoleKey.Oem1 && currentCharacter.Key <= ConsoleKey.Oem102 ||
                    (numSet.Contains(currentCharacter.KeyChar.ToString()) && ((currentCharacter.Modifiers & ConsoleModifiers.Shift) != 0)) ||
                    currentCharacter.Key == ConsoleKey.Spacebar)
                    && (inputMode & InputMode.Symbolic) != 0)
                {
                    Console.Write(password ? '*' : currentCharacter.KeyChar);
                    input += currentCharacter.KeyChar;
                }
                else
                {
                    ReadLineBadCharacterEvent(currentCharacter);
                    continue;
                }
            }
            return input;
        }

        public static void ClearReadLineEventHandlers()
        {
            ReadLineBadCharacterEvent = null;
            ReadLineHitLimitEvent = null;
        }
    }
}
