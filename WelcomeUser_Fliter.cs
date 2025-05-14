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
        private ArrayList keyWords = new ArrayList();
        private List<string> conversationHistory = new List<string>();

        private Random random = new Random();

        public WelcomeUser_Fliter()
        {
            StoreReplies();// Store the replies
            StoreIgnoreWords();// Store the ignore words
            StoreKeyWords();// Store the keywords
            StoreSentiments();// Store the sentiments
            BuildReplyLookup();// Build the reply dictionary


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
        // method for remebering the user's name
        public delegate string SpecialQuestionHandler(string question);
        private string HandleSpecialQuestion(string question)
        {
            string cleaned = question.ToLower().Trim();

            foreach (string phrase in nameRecallQuestions)
            {
                if (cleaned.Contains(phrase))
                {
                    return $"Your name is {username}.";
                }
            }

            return null; // Not a match
        }

         private string HandleHelpQuestions(string question)
        {
            string cleaned = question.ToLower().Trim();

            foreach (string phrase in needHelpQuestions)
            {
                if (cleaned.Contains(phrase))
                {
                    return "You can ask me about topics like passwords, scams, privacy, ransomware, viruses, and firewalls.\nTry asking something like 'How do I protect my password?' or 'What is ransomware?'";
                }
            }

            return null;
        }

        // being of  sentiments
        public class Sentiment
        {
            public string Keyword { get; set; }
            public string Response { get; set; }

            public Sentiment(string keyword, string response)
            {
                Keyword = keyword.ToLower();
                Response = response;
            }
        }
        // sentiments
        private delegate void SentimentHandler(string userInput);
        private List<Sentiment> sentiments = new List<Sentiment>();
        // Method to check if the input contains any of the  Sentiment words
        private void DetectSentiment(string userInput)
        {
            foreach (Sentiment sentiment in sentiments)
            {
                if (userInput.ToLower().Contains(sentiment.Keyword))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(ChatBot_name + sentiment.Response);
                    Console.ForegroundColor = ConsoleColor.White;

                    conversationHistory.Add(ChatBot_name + sentiment.Response);
                    break;
                }
            }
        }

        // Builds the reply dictionary (called once in the constructor)
        private void BuildReplyLookup()
        {
            foreach (string item in replies)
            {
                int colonIndex = item.IndexOf(':');
                if (colonIndex < 0) continue; // skip items that don't use keyword: format

                string keyword = item.Substring(0, colonIndex).Trim().ToLower();
                string answer = item.Substring(colonIndex + 1).Trim();

                if (!replyLookup.ContainsKey(keyword))
                {
                    replyLookup[keyword] = new List<string>();
                }

                replyLookup[keyword].Add(answer);
            }
        }

        // Handles questions we don't understand
        private bool HandleUnknownInput(string question)
        {
            foreach (string keyword in keyWords)
            {
                if (question.Contains(keyword)) return false; // We do understand it
            }

            // If no known keyword found, use a default fallback reply
            string randomReply = defaultReplies[random.Next(defaultReplies.Count)];

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(randomReply);
            Console.ForegroundColor = ConsoleColor.White;

            conversationHistory.Add(ChatBot_name + randomReply);
            return true; // We've handled it
        }
        // random..
        // Tries to match a keyword and give a related reply
        private bool TryKeywordReply(string question)
        {
            foreach (string keyword in keyWords)
            {
                if (question.Contains(keyword) && replyLookup.ContainsKey(keyword))
                {
                    List<string> possibleReplies = replyLookup[keyword];
                    string randomReply = possibleReplies[random.Next(possibleReplies.Count)];

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(randomReply);
                    Console.ForegroundColor = ConsoleColor.White;

                    conversationHistory.Add(ChatBot_name + randomReply);
                    return true;
                }
            }

            return false;
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
                Console.WriteLine("Thank you " + username + " for using CyberBuddy. Hope we helped you answer your queries!");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=");
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0); // Exit program

            }

            SpecialQuestionHandler specialHandler = HandleSpecialQuestion;
            string specialReply = specialHandler(asking_question);
            if (!string.IsNullOrEmpty(specialReply))
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(specialReply);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            // history of the corvarsation m
            if (asking_question.ToLower() == "remember")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Here is everything we've talked about:");
                foreach (string line in conversationHistory)
                {
                    Console.WriteLine(line);
                }
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            // Save the user's question
            conversationHistory.Add($"{username}: {asking_question}");

            //remember the username 


            //Coversation flow 
            // Check for help-related or topic confusion questions
            string helpReply = HandleHelpQuestions(asking_question);
            if (!string.IsNullOrEmpty(helpReply))
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(helpReply);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            SentimentHandler sentimentHandler = DetectSentiment;
            sentimentHandler(asking_question);

            UnknownInputHandler unknownHandler = HandleUnknownInput;
            if (unknownHandler(asking_question)) return;  // If it's unknown, stop here

            if (TryKeywordReply(asking_question)) return; // If we found a keyword, stop here


            

           //
            
            ArrayList filteredWords = new ArrayList();// List to store filtered words
            foreach (string word in asking_question.Split(' '))// / Split the input into words
            {
                if (!ignoreWords.Contains(word.ToLower()))
                {
                    filteredWords.Add(word);
                }
            }
            // Check if any filtered words match the replies
            foreach (string keyword in filteredWords)
            {
                if (filteredWords.Contains(keyword))
                {
                    ArrayList matchedReplies = new ArrayList();

                    foreach (string reply in replies)
                    {
                        if (reply.ToLower().StartsWith(keyword + ":"))
                        {
                            matchedReplies.Add(reply.Substring(keyword.Length + 1).Trim());
                        }
                    }

                    if (matchedReplies.Count > 0)
                    {
                        int randIndex = random.Next(matchedReplies.Count);
                        string chosenReply = matchedReplies[randIndex].ToString();

                      /*  string chosenreply = "Your chosen reply here";
                        conversationHistory.Add($"{ChatBot_name}{chosenReply}");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(chosenReply);
                        Console.ForegroundColor = ConsoleColor.White;*/

                        //   Console.Write(ChatBot_name );
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(chosenReply);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(ChatBot_name);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("Please type your question or type");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" 'Exit'");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(" to end the conversation");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }
                }
            }

           
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" PLEASE search something related to CYBER SECURITY.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ChatBot_name+"Please type your question or type");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 'Exit'");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(" to end the conversation");
            Console.WriteLine();
            Console.WriteLine();
           Console.ForegroundColor = ConsoleColor.White;
        }

        private void StoreReplies()
        {
            replies.Add("password: Use strong, unique passwords with symbols and numbers.");
            replies.Add("password: Never share your passwords with anyone.");
            replies.Add("password: Use a password manager to store your credentials safely.");
            replies.Add("password:Use strong passwords, enable 2FA, and keep your system updated.");
            replies.Add("password:A strong password should be at least 12 characters long, include numbers, symbols, and a mix of uppercase and lowercase letters.");
            replies.Add("password:To protect personal data online, use strong passwords, enable two-factor authentication, and avoid clicking on suspicious links.");
            replies.Add("password:To secure cloud storage, use strong passwords, enable encryption, and avoid sharing sensitive files openly.");

            replies.Add("scam: Scams trick you into giving away private info. Be alert.");
            replies.Add("scam: Never click on suspicious links or give info to unknown sources.");
            replies.Add("scam: Always verify the sender before trusting emails.");

            replies.Add("privacy: Be cautious about what you share online.");
            replies.Add("privacy: Use incognito mode or privacy-focused browsers.");
            replies.Add("privacy: Regularly check app permissions and privacy settings.");

            replies.Add("ransomware: Ransomware locks files and demands payment. Back up regularly.");
            replies.Add("ransomware: Never pay the ransom. Report the incident.");
            replies.Add("ransomware: Use antivirus and avoid suspicious downloads.");
            replies.Add("ransomware:Ransomware is a type of malware that locks files and demands payment to unlock them. Never pay the ransom.");

            replies.Add("authentication:Two-factor authentication (2FA) adds an extra layer of security.");
            replies.Add("authentication:Two-factor authentication (2FA) adds an extra layer of security by requiring a second form of verification.");

            replies.Add("network:Secure your home network by enabling WPA2/WPA3 and using strong passwords.");
            replies.Add("network:To secure your home Wi-Fi, change the default router password, enable WPA3 encryption, and disable remote access.");

            replies.Add("web:Use HTTPS, verify website authenticity, and enable 2FA for safe transactions.");
            replies.Add("web:To check if a website is secure, look for HTTPS in the URL and verify the site’s security certificate.");

            replies.Add("privacy:A VPN encrypts your internet traffic and hides your IP address to improve privacy and security online.");
            replies.Add("privacy:The GDPR is a data protection law in the EU that ensures companies protect user data and privacy.");

            replies.Add("malware:Malware is malicious software like viruses and ransomware that can harm your computer or steal data.");
            replies.Add("malware: Malware is software designed to harm or steal data.");
            replies.Add("malware: Install antivirus programs and keep them updated.");
            replies.Add("malware: Avoid downloading files from untrusted websites.");

           

            replies.Add("phishing:Phishing is a fraudulent attempt to obtain sensitive information.");
            replies.Add("phishing:Phishing is an attempt to trick users into providing sensitive information. Avoid clicking links in unexpected emails.");
            replies.Add("phishing:To recognize a phishing email, check for grammatical errors, suspicious links, and unexpected requests for personal information.");

            replies.Add("firewall:A firewall is a security system that monitors and controls network traffic to block unauthorized access.");
            replies.Add("firewall: A firewall protects your system from unauthorized access.");
            replies.Add("firewall: Enable your firewall and keep it properly configured.");
            replies.Add("firewall: Use both software and hardware firewalls if possible.");

            replies.Add("sql:SQL:SQL stands for Structured Query Language, used for managing databases.");
            replies.Add("sql:SQL Injection is inserting malicious SQL queries to manipulate databases.");
            replies.Add("sql:SQL Injection is a type of attack where hackers manipulate database queries to access or delete data.");

            replies.Add("cybersecurity:Cybersecurity refers to protecting digital information and networks.");
            replies.Add("cybersecurity:Cybersecurity refers to protecting digital information and networks from cyber threats.");
            replies.Add("cybersecurity:Cybersecurity is important because it helps prevent data breaches, identity theft, and financial fraud.");

            
          
        }
        private void StoreKeyWords()
        {
            keyWords.Add("password");
            keyWords.Add("scam");
            keyWords.Add("privacy");
            keyWords.Add("ransomware");
           // keyWords.Add("virus");
            keyWords.Add("firewall");
            keyWords.Add("Sql");
            keyWords.Add("phishing");
            keyWords.Add("malware");
            keyWords.Add("authentication");
            keyWords.Add("network");
            keyWords.Add("web");
            keyWords.Add("cybersecurity");




        }

        private readonly List<string> nameRecallQuestions = new List<string>
{
         "what is my name",
         "can you tell me my name",
         "do you remember my name",
         "what do you call me",
         "what name do you have for me",
         "who am i",
         "my name",
         "Do you know who I am?" ,
         "What did I say my name was?" ,
         "Remind me of my name.",
         "What name are we using?",
         "Hey, what's my name again?",
         "What name did I give you?",
         "What name do I go by?",
         "What name should I use?",
         "What do you call me, chatbot?",
         "My name is",

};
        private readonly List<string> needHelpQuestions = new List<string>
{
       "what can i ask",
       "what do you do",
       "help me",
       "i need help",
       "what topics",
       "show topics",
       "what are the topics",
       "i'm confused",
       "tell me more",
      "how can you help"
};

        private void StoreSentiments()
        {
            sentiments.Add(new Sentiment("worried", "It's completely understandable to feel that way. Cybersecurity can be overwhelming, but I'm here to help."));
            sentiments.Add(new Sentiment("curious", "I'm glad you're curious! Asking questions is the first step toward better security."));
            sentiments.Add(new Sentiment("frustrated", "That sounds frustrating. Let's try to simplify this and find a solution."));
            sentiments.Add(new Sentiment("afraid", "There's no need to be afraid — with the right precautions, you'll stay safe online."));
            sentiments.Add(new Sentiment("confused", "Cybersecurity can be confusing. I'll do my best to explain things clearly."));
            sentiments.Add(new Sentiment("concerned", "You're right to be cautious. Let's make sure your digital safety is strong."));
        }

        // Default fallback replies for unknown questions
        private List<string> defaultReplies = new List<string>
           {
             "I'm not sure I understand. Could you try rephrasing?",
             "Hmm... I didn't get that. Try asking in a different way?",
            "I don't have an answer for that right now. Can you explain more?"
              };

        // This will hold replies by keyword for quick search
        private Dictionary<string, List<string>> replyLookup = new Dictionary<string, List<string>>();

        // A simple delegate for unknown input handling
        private delegate bool UnknownInputHandler(string question);


        private void StoreIgnoreWords()
        {
            string[] commonWords = { "what", "is", "how", "to", "about", "can", "the", "your", "i", "my", "me", "tell", "when","inform" };
            foreach (string word in commonWords)
            {
                ignoreWords.Add(word.Trim().ToLower()); // make sure the words are lowercase
            }
        }
    }
}
