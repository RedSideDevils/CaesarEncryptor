using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.Drawing;
using System.IO;

namespace MyEnc
{
    class Program
    {
        static void Main(string[] args)
        {
            int DA = 244;
            int V = 212;
            int ID = 255;

            Console.WriteAscii("CaesarEncryptor!", Color.FromArgb(DA, V, ID));
            Console.WriteLine("[OPTIONS]");
            Console.WriteLine("[1.Encryption]");
            Console.WriteLine("[2.Decryption]");
            Console.WriteLine("[3.Encrypt text file]");
            Console.WriteLine("[4.Decrypt text file]");
            Console.WriteLine("[?]Enter option[?]");
            string choose = Console.ReadLine();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();
            List<string> numbers = new List<string>();
            
            Console.WriteLine("[?]Enter key[?]");
            int key = Convert.ToInt32( Console.ReadLine() );
            string result = "";

            if (key > alphabet.Length)
            {
                Console.WriteLine("Big number");
            }

            foreach (var letter in alphabet)
            {
                numbers.Add(Convert.ToString( letter ));
            }
            
            if(choose == "1")
            {
                Console.WriteLine("[?]Enter word[?]");
                string word = Console.ReadLine();
                foreach (var letter in word)
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        try
                        {
                            if (Convert.ToString(letter).ToLower() == numbers[i].ToLower())
                            {
                                result += numbers[i + key];
                            }
                            else
                            {
                                continue;
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Something Wrong!");
                        }
                    }
                }
            }

            else if (choose == "2")
            {
                Console.WriteLine("[?]Enter word[?]");
                string word = Console.ReadLine();
                foreach (var letter in word)
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        try
                        {
                            if (Convert.ToString(letter).ToLower() == numbers[i].ToLower())
                            {
                                result += numbers[i - key];
                            }
                            else
                            {
                                continue;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Something Wrong!");
                            break;
                        }
                    }
                }
            }

            else if (choose == "3")
            {
                string text;
                List<string> text_output = new List<string>();
                Console.WriteLine("[?]Enter Directory");
                string path = Console.ReadLine();
                using (var streamReader = new StreamReader(@path, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                    foreach(var word_from_text in text)
                    {
                        text_output.Add(Convert.ToString(word_from_text));
                    }
                }
                
                foreach(var word_part in text_output)
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
          
                        if (Convert.ToString(word_part).ToLower() == numbers[i].ToLower())
                        {
                            result += numbers[i + key];
                        }
                        else if (Convert.ToString(word_part) == " ")
                        {
                            result += " ";
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                using (StreamWriter writer = new StreamWriter(@path))
                {
                    writer.WriteLine(result);
                }
            }

            else if (choose == "4")
            {
                string text;
                Console.WriteLine("[?]Enter Directory");
                string path = Console.ReadLine();
                List<string> text_output = new List<string>();

                using (var streamReader = new StreamReader(@path, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                    foreach (var word_from_text in text)
                    {
                        text_output.Add(Convert.ToString(word_from_text));
                    }
                }

                foreach (var word_part in text_output)
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {

                        if (Convert.ToString(word_part).ToLower() == numbers[i].ToLower())
                        {
                            result += numbers[i - key];
                        }
                        else if (Convert.ToString(word_part) == " ")
                        {
                            result += "";
                        }
                    }
                }
                using (StreamWriter writer = new StreamWriter(@path))
                {
                    writer.WriteLine(result);
                }
            }

            Console.WriteLine("\n\nResult:" + result);
            Console.ReadKey();
        }
    }
}
