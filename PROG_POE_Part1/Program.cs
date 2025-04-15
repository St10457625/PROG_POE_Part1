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
            // Play audio greeting at startup
            PlayAudio("Audio\\Greeting voice.wav");

            // Set console title and display ASCII art logo in cyan
            Console.Title = "Cyber Security Chatbot";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
 ██████╗██╗   ██╗██████╗ ███████╗██████╗ ██████╗  ██████╗ ████████╗
██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔═══██╗╚══██╔══╝
██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝██████╔╝██║   ██║   ██║   
██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗██╔══██╗██║   ██║   ██║   
╚██████╗   ██║   ██████╔╝███████╗██║  ██║██████╔╝╚██████╔╝   ██║   
 ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚═════╝  ╚═════╝    ╚═╝   
");  // ASCII Art header

            // Ask for user's name
            Console.Write("Please enter in your name ");
            Console.ForegroundColor = ConsoleColor.White;
            string name = Console.ReadLine();

            // Greet the user and explain available commands
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Hello {name}! I'm here to provide information on Cybersecurity");
            Console.WriteLine("You can ask:" +
                              "\nCybersecurity" +
                              "\nProtection" +
                              "\nThreats" +
                              "\nTools" +
                              "\nOr type 'exit' to quit.\n");

            // Start chatbot interaction loop
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{name}: ");
                string userInput = Console.ReadLine()?.ToLower().Trim(); // Normalize input

                // Handle empty input
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Chatbot: Please enter a valid question");
                    continue;
                }

                // Exit condition
                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Chatbot : Keep checking up on the latest cybersecurity updates! Bye!");
                    break;
                }

                // Pass user input to the query handler
                HandleUserInput(userInput, name);
            }
        }

        // Method to play a .wav audio file
        static void PlayAudio(string filePath)
        {
            try
            {
                // Build full path to the audio file
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

                // If the file exists, play it
                if (File.Exists(fullPath))
                {
                    using (SoundPlayer player = new SoundPlayer(fullPath))
                    {
                        player.PlaySync(); // Play audio synchronously
                    }
                }
                else
                {
                    // Show error if file not found
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Audio file not found: {fullPath}");
                }
            }
            catch (Exception ex)
            {
                // Handle errors related to audio playback
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error playing audio: {ex.Message}");
            }
        }

        // Method to handle user input and generate responses
        static void HandleUserInput(string input, string userName)
        {
            // Dictionary of recognized keywords and responses
            Dictionary<string, string> responeses = new Dictionary<string, string>
            {
                {"help", "You can ask about: 'Cybersecurity', 'Protection', 'Threats', or 'Tools'" },
                {"cybersecurity", "Cybersecurity is the practice of protecting computers, networks, and data from unauthorized access, attacks, or damage. It helps keep your personal info, devices, and online activities safe." },
                {"protection", "Protection in cybersecurity means using safe habits and tools—like strong passwords, software updates, and antivirus—to keep your devices and information secure from cyber threats." },
                {"threats", "Cyber threats are actions or events that can harm your computer, data, or online security—like viruses, hackers, phishing scams, or ransomware attacks." },
                {"tools", "Cybersecurity tools help protect your devices and data. These include antivirus software, firewalls, VPNs, password managers, and security scanners." }
            };

            // If the input matches a keyword, respond with the relevant message
            if (responeses.ContainsKey(input))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Chatbot: {responeses[input]}");
            }
            else
            {
                // Ask if the user wants general cybersecurity tips
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Chatbot: I didn't quite catch that, {userName}. Would you like me to suggest some cybersecurity tips (yes/no)?");

                string reply = Console.ReadLine()?.ToLower().Trim();

                if (reply == "yes")
                {
                    // Provide tips if user agrees
                    CybersecurityTips();
                }
                else
                {
                    // Friendly fallback message
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Chatbot: No problem! Let me know if you need more information on cybersecurity.");
                }
            }
        }

        // Method to share a list of cybersecurity tips
        static void CybersecurityTips()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Chatbot: Here are some cybersecurity tips to help keep you safe online:");
            Console.WriteLine("- Use strong, unique passwords for each account.");
            Console.WriteLine("- Turn on two-factor authentication (2FA) wherever possible as this provides an extra layer of protection.");
            Console.WriteLine("- Don’t click on suspicious links or email attachments as this could lead to identity theft or information theft.");
            Console.WriteLine("- Keep your software and devices updated as these contain the latest security patches.");
            Console.WriteLine("- Use a reputable antivirus or security suite and make sure to do regular scans.");
            Console.WriteLine("- Back up your important files regularly if you have cloud services available.");
        }
    }
}
