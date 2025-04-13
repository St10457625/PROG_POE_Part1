using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace PROG_POE_Part1
{
    internal class Program
    {
        public static void Main()
        {

            //Play audio greeting
            PlayGreetingAudio("Cyberbot_greeting.wav");

            Console.Title = "Cyber Security Chatbot";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"

 ██████╗██╗   ██╗██████╗ ███████╗██████╗ ██████╗  ██████╗ ████████╗
██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔═══██╗╚══██╔══╝
██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝██████╔╝██║   ██║   ██║   
██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗██╔══██╗██║   ██║   ██║   
╚██████╗   ██║   ██████╔╝███████╗██║  ██║██████╔╝╚██████╔╝   ██║   
 ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚═════╝  ╚═════╝    ╚═╝   
                                                                   
");  //ASCII ART

            Console.Write("What is your name? ");
            Console.ForegroundColor = ConsoleColor.White;
            string userName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hello {userName}! I'm here to provide information on Cybersecurity");
            Console.WriteLine("You can ask about different types of security,key aspects of Cybersecurity or type 'exit' to quit.\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{userName}: ");
                string userInput = Console.ReadLine()?.ToLower().Trim();


                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Chatbot: Please enter a valid question");
                    continue;
                }

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Chatbot : Keep checking up on the latest cybersecurity updates! Bye! ");
                    break;
                }

                HandleUserQuery(userInput, userName);
            }
        }


        static void PlayGreetingAudio(string filePath)
        {
            try
            {
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

                if (File.Exists(fullPath))
                {
                    SoundPlayer player = new SoundPlayer(fullPath);
                    player.PlaySync(); //Play audio synchronousely
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error playing audio: {ex.Message}");

            }
        }
    }
}
