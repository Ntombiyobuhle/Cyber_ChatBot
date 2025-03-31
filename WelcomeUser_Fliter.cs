using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Net.Http;

namespace Cyber_ChatBot
{
    public class WelcomeUser_Fliter
    {

        //declear variables 
        private string username = string.Empty; // promtp user for name
        private string ChatBot_name = "CyberBuddy : "; // chatbot name
        private string asking_question = string.Empty; // promtp user for question
        private ArrayList replies = new ArrayList(); // Store predefined replies
        private ArrayList ignore = new ArrayList(); // Store ignored phrases


        //constructor
        public WelcomeUser_Fliter()
        {
            StoreReplies(); // Store replies
            StoreIgnore(); // Store ignored phrases
            // CyberBuddy welcome message
            Console.WriteLine(ChatBot_name + "Welcome to CyberBuddy!");
            Console.WriteLine(ChatBot_name + " What is you name");

            // user input name and changing colour for user input
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("you: ");
            username = Console.ReadLine();


            // resetting the colour
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ChatBot_name + "Hello " + username + "  i am here to help you with any queries you may have.");
            Console.WriteLine(ChatBot_name + "Please type your question or type 'Exit' to end the conversation");



            do
            {
                // changing colour for user input
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(username + ":");
                asking_question = Console.ReadLine();


                // resetting the colour
                Console.ForegroundColor = ConsoleColor.White;


              
                processing_question(asking_question);


            } while (asking_question != "Exit");
            Console.Write(ChatBot_name);
            Console.WriteLine("Thank you " + username + " for using  CyberBuddy, hope we help you answer you queries");
            Environment.Exit(0);

        }//end of constructor





        // method to process the question
        private void processing_question(string asking_question)
        {
            if (asking_question != "Exit")
            {
                string[] words = asking_question.Split(' ');
                ArrayList storingWords = new ArrayList();

                // FOR  LOOPS 
                foreach (string word in words)
                {
                    if (!ignore.Contains(word))
                    {
                        storingWords.Add(word);
                    }
                }//end of for loop

                Boolean found = false;
                string message = string.Empty;

                foreach (string reply in replies)
                {
                    string[] replyWords = reply.Split(' ');

                    foreach (string storedWord in storingWords)
                    {
                        switch (storedWord.ToLower())
                        {
                            case "password":
                                if (replyWords.Contains("password"))
                                {
                                    message = reply.ToString();
                                    found = true;
                                    break;
                                }
                                break;

                            case "cyber":
                                if (replyWords.Contains("cyber") && replyWords.Contains("security"))
                                {
                                    message = reply.ToString();
                                    found = true;
                                    break;
                                }
                                break;

                               
                        }

                        if (found) break;
                    }

                    if (found) break;
                }

                if (found)
                {
                    Console.WriteLine(message);
                }
                else
                {
                    Console.Write(ChatBot_name);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("PLEASE SEARCH SOMETHING RELATED TO CYBER SECURITY.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.Write(ChatBot_name);
                Console.WriteLine("Thank you " + username + " for using CyberBuddy, hope we help you answer you queries");
                Environment.Exit(0);
            }
        }




        private void StoreReplies()
        {
            replies.Add(ChatBot_name + " Cbersecurity refers to the practices, technologies, and processes designed to protect digital information," +
                 " networks, and computer systems from unauthorized access, use, disclosure, disruption, modification, or destruction." +
                 " Cybersecurity is important because it helps protect sensitive information, prevents financial loss, and maintains the " +
                 "confidentiality, integrity, and availability of data.");

            replies.Add(ChatBot_name + " To protect yourself from cyber threats, use strong, unique passwords; enable two-factor authentication (2FA);" +
                " keep your operating system, software, and apps up-to-date; use reputable antivirus software; avoid suspicious links" +
                " and attachments; and use a virtual private network (VPN) when using public Wi-Fi.");


            replies.Add(ChatBot_name + " To ensure secure online transactions, use HTTPS websites; verify the website's authenticity; use strong passwords" +
                " and 2FA; keep your browser and software up-to-date; use a reputable payment gateway; and monitor your accounts for suspicious activity.");


            replies.Add(ChatBot_name + " To create strong, unique passwords, use a combination of uppercase and lowercase letters, numbers, and special characters; avoid " +
                "using easily guessable information (e.g., name, birthdate); and consider using a password manager to generate and store complex passwords.");


            replies.Add(ChatBot_name + " Two-factor authentication (2FA) is a security process that requires a user to provide two different authentication factors to" +
                " access a system, network, or application. 2FA typically combines something you know (e.g., password) with something you have (e.g., smartphone, token generator).");


            replies.Add("To manage passwords securely, use a reputable password manager to generate, store, and retrieve complex passwords; enable 2FA whenever possible; and avoid " +
                "using the same password across multiple sites.");


            replies.Add("CyberBuddy " + "Using the same password across multiple sites increases the risk of a single data breach compromising multiple accounts. If a hacker gains access to one account," +
                " they may be able to use the same password to access other accounts.");


            replies.Add("CyberBuddy :" + "To secure your home, change the default administrator password; enable WPA2 encryption (or WPA3, if available); set up a guest network;" +
                " keep your router's firmware up-to-date; and use a reputable antivirus program.");


            replies.Add(ChatBot_name + "Passwords should be strong, unique, and complex, with a minimum of 12 characters, mixing uppercase and lowercase letters, numbers, and special characters." +
                " Avoid using easily guessable information or common patterns. Use a password manager to generate and store unique passwords.");


            replies.Add(ChatBot_name + "It is recommended that you update your password every 60-90 days. However, if you are utilizing a password manager and have a strong, distinctive password," +
                " you may not need to update it as frequently. The key is to strike a balance between password security and the inconvenience of frequent password changes.\r\n");

            replies.Add(ChatBot_name + "A password manager is a software application that securely stores and manages your passwords. It generates strong, unique passwords and autofills them for you," +
                " eliminating the need to remember multiple passwords. This not only saves time but also enhances security by ensuring that each account has a distinct and robust password.\r\n\r\n");

            replies.Add(ChatBot_name +  "No, it is not advisable to use the same password for multiple accounts. If one account is compromised, all accounts with the same password will be vulnerable." +
                " This can lead to a domino effect, where a single password compromise can result in multiple accounts being hacked. Instead, use a password manager to generate and store unique passwords for each account.\r\n");

            replies.Add(ChatBot_name+"A strong password is a combination of characters, numbers, and special characters that is at least 12 characters long. It should not contain easily guessable information such as names, birthdates, or common words.\r\n\r\n");

            replies.Add(ChatBot_name+ "To maintain the security of your passwords, it is essential to utilize a password manager, enable two-factor authentication, use strong and unique passwords, and avoid sharing your passwords with others. Additionally, " +
                "you should be cautious when using public computers or networks and avoid using the same password for multiple accounts.\r\n");
            replies.Add(ChatBot_name + "If you forget your password, you can retrieve it by using the \"forgot password\" feature on the website or application. This will typically send a password reset link to your registered email address." +
                " Alternatively, you can use a password manager to retrieve your password. It is essential to ensure that your password recovery options are secure and do not compromise your account security.\r\n");
            replies.Add(ChatBot_name + "");
            replies.Add(ChatBot_name + "");
            replies.Add(ChatBot_name + "");
            replies.Add(ChatBot_name + "");
            replies.Add(ChatBot_name + "");
            replies.Add(ChatBot_name + "");
        
    }//end of method

        private void StoreIgnore()
        {
            // storing ignore in the array list
            ignore.Add("what is");
            ignore.Add("Tell me about");
            ignore.Add("how to change my");
            ignore.Add("How can I");
            ignore.Add("How do I ");
            ignore.Add("How can I ensure");
            ignore.Add("Chabge");
        }
    } //end of class
}// end of namespace
