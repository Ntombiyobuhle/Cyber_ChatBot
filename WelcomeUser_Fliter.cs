using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;


namespace Cyber_ChatBot
{
    public class WelcomeUser_Fliter
    {
        private string username = string.Empty;
        private string ChatBot_name = "CyberBuddy : ";
        private string asking_question = string.Empty;
        private ArrayList replies = new ArrayList();
        private ArrayList ignoreWords = new ArrayList();

        public WelcomeUser_Fliter()
        {
            StoreReplies();// Store the replies
            StoreIgnoreWords();// Store the ignore words

            // Welcome message
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ChatBot_name + "Welcome to CyberBuddy!");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ChatBot_name + "What is your name?");


            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("You: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            username = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;


            // Input validation for username
            while (!IsValidUsername(username))
            {
                Console.Write(ChatBot_name);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid username. Please enter a name with only letters.");
                Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("you: ");
                username = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }



            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(ChatBot_name + "Hello " + username + ", I am here to help you with cybersecurity queries.");
            Console.WriteLine(ChatBot_name + "Please type your question or type 'Exit' to end the conversation.");

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(username + ": ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                asking_question = Console.ReadLine();
                
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(ChatBot_name);
                ProcessQuestion(asking_question);
            }
            while (!asking_question.Equals("exit", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine(ChatBot_name + "Thank you " + username + " for using CyberBuddy. Hope we helped you answer your queries!");
            Environment.Exit(0);

        } // End of constructor


        // Method to validate username
        private bool IsValidUsername(string username)
        {
            return username.All(char.IsLetter);
        }
        // Method to process user input
        private void ProcessQuestion(string asking_question)
        {
            asking_question = asking_question.Trim().ToLower(); // Normalize input

            if (asking_question == "exit")
            {// Exit condition
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=");
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write(ChatBot_name);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine( "Thank you " + username + " for using CyberBuddy. Hope we helped you answer your queries!");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=");
               Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0); // Exit program
                
            }
            
            ArrayList filteredWords = new ArrayList();// List to store filtered words
            foreach (string word in asking_question.Split(' '))// / Split the input into words
            {
               if (!ignoreWords.Contains(word))
                {
                    filteredWords.Add(word);
                }
            }
            // Check if any filtered words match the replies
            foreach (string word in filteredWords)
            {
                foreach (string reply in replies)
                {
                    // Check if the reply contains the filtered word
                    if (reply.ToLower().Contains(word))
                    {
                        Console.Write(ChatBot_name );
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(reply);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(ChatBot_name);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Please type your question or type 'Exit' to end the conversation");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }
                }
            }

           
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" PLEASE search something related to CYBER SECURITY.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ChatBot_name + "Please type your question or type 'Exit' to end the conversation.");
            Console.WriteLine();
           Console.ForegroundColor = ConsoleColor.White;
        }

        private void StoreReplies()
        {
            replies.Add("Cybersecurity refers to protecting digital information and networks.");
            replies.Add("Use strong passwords, enable 2FA, and keep your system updated.");
            replies.Add("Use HTTPS, verify website authenticity, and enable 2FA for safe transactions.");
            replies.Add("Passwords should be strong, unique, and stored securely.");
            replies.Add("Two-factor authentication (2FA) adds an extra layer of security.");
            replies.Add("Secure your home network by enabling WPA2/WPA3 and using strong passwords.");
            replies.Add("SQL stands for Structured Query Language, used for managing databases.");
            replies.Add("Phishing is a fraudulent attempt to obtain sensitive information.");
            replies.Add("Cross-Site Scripting (XSS) allows attackers to inject malicious scripts.");
            replies.Add("SQL Injection is inserting malicious SQL queries to manipulate databases.");
            replies.Add("Cybersecurity refers to protecting digital information and networks from cyber threats.");
            replies.Add("Cybersecurity is important because it helps prevent data breaches, identity theft, and financial fraud.");
            replies.Add("To protect personal data online, use strong passwords, enable two-factor authentication, and avoid clicking on suspicious links.");
            replies.Add("A strong password should be at least 12 characters long, include numbers, symbols, and a mix of uppercase and lowercase letters.");
            replies.Add("To check if a website is secure, look for HTTPS in the URL and verify the site’s security certificate.");
            replies.Add("Phishing is an attempt to trick users into providing sensitive information. Avoid clicking links in unexpected emails.");
            replies.Add("Two-factor authentication (2FA) adds an extra layer of security by requiring a second form of verification.");
            replies.Add("To secure your home Wi-Fi, change the default router password, enable WPA3 encryption, and disable remote access.");
            replies.Add("A firewall is a security system that monitors and controls network traffic to block unauthorized access.");
            replies.Add("Malware is malicious software like viruses and ransomware that can harm your computer or steal data.");
            replies.Add("A denial-of-service (DoS) attack overwhelms a system with traffic to make it unavailable.");
            replies.Add("Ransomware is a type of malware that locks files and demands payment to unlock them. Never pay the ransom.");
            replies.Add("Social engineering attacks manipulate people into giving away confidential information.");
            replies.Add("SQL Injection is a type of attack where hackers manipulate database queries to access or delete data.");
            replies.Add("A VPN encrypts your internet traffic and hides your IP address to improve privacy and security online.");
            replies.Add("To recognize a phishing email, check for grammatical errors, suspicious links, and unexpected requests for personal information.");
            replies.Add("To secure cloud storage, use strong passwords, enable encryption, and avoid sharing sensitive files openly.");
            replies.Add("The GDPR is a data protection law in the EU that ensures companies protect user data and privacy.");
            replies.Add("Artificial Intelligence (AI) is used in cybersecurity for threat detection, anomaly detection, and automated security responses.");
            replies.Add("The future of cybersecurity includes advancements in AI, quantum encryption, and more sophisticated cyber threats.");
          
        }

        private void StoreIgnoreWords()
        {
            string[] commonWords = { "what", "is", "how", "to", "about", "can", "the", "your", "i", "my", "me", "tell", "when","inform" +
                    ""};
            foreach (string word in commonWords)
            {
                ignoreWords.Add(word);
            }
        }
    }
}
