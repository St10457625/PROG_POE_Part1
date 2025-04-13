﻿using System;
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
            Console.WriteLine("You can ask:" +
                              "\nCybersecurity" +
                              "\nProtection" +
                              "\nThreats" +
                              "\nTools" +
                              "\nOr type 'exit' to quit.\n");

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

                if (userInput == "exit")
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

        static void HandleUserQuery(string input, string userName)
        {
            Dictionary<String, string> responeses = new Dictionary<string, string>
            {
                {"help", "You can ask about: 'Cybersecuirty' , 'Protection', 'Threats', or 'Tools'" },
                {"cybersecurity", "Cybersecurity is the practice of protecting computers, networks, and data from unauthorized access, attacks, or damage. It helps keep your personal info, devices, and online activities safe." },
                {"protection" , "Protection in cybersecurity means using safe habits and tools—like strong passwords, software updates, and antivirus—to keep your devices and information secure from cyber threats." },
                {"threats", "Cyber threats are actions or events that can harm your computer, data, or online security—like viruses, hackers, phishing scams, or ransomware attacks." },
                {"tools","Cybersecurity tools help protect your devices and data. These include antivirus software, firewalls, VPNs, password managers, and security scanners. " }
            };

            if (responeses.ContainsKey(input))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Chatbot: {responeses[input]}");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Chatbot: I didnt quite catch that, {userName}. Would you like me to suggest some Cybersecurity tips (yes/no)");
                string reply = Console.ReadLine()?.ToLower().Trim();

                if (reply == "yes")
                {
                    ShareCybersecurityTips();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Chatbot: no problem! Let me know if you need more information on cybersecurity.");

                }
            }
        }

        static void ShareCybersecurityTips()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Chatbot: Here are some cybersecurity tips to help keep you safe online:");
            Console.WriteLine("- Use strong, unique passwords for each account.");
            Console.WriteLine("- Turn on two-factor authentication (2FA) wherever possible as this provides an extra layer of protection.");
            Console.WriteLine("- Don’t click on suspicious links or email attachments as this could lead to identity theft or infromation theft.");
            Console.WriteLine("- Keep your software and devices updated as these contain the latest security patches.");
            Console.WriteLine("- Use a reputable antivirus or security suite and make sure to do regular scans.");
            Console.WriteLine("- Back up your important files regularly if you have cloud services available.");
        }
    }
}
