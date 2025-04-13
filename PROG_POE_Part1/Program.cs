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
