using System.Collections;
using System;

namespace Cyber_ChatBot
{
    public class Filter
    {
        // creating a list of the replies
        // declearing variables
        ArrayList replies = new ArrayList();
        ArrayList ignore = new ArrayList();

        //constructor
        public Filter()
        {
            {
                // method for ignore and replies to store values
                store_replies();
                store_ignore();


                
                /*Console.WriteLine("what is your name ");
                 // changing the color of the text for the user input
                 Console.ForegroundColor = ConsoleColor.Green;
                 // getting the user input
                 string input = Console.ReadLine();

                 // changing the color of the text for the output
                 Console.ForegroundColor = ConsoleColor.White;
                 Console.Write("CyberBuddy:");
                 Console.WriteLine("Nice to know you " + input);

                 Console.Write("CyberBuddy:");
                 Console.WriteLine("I am here to help you with security queries ");
                 // the users name 
                 Console.ForegroundColor = ConsoleColor.Green;

                 Console.Write(input + ":");
                 // Console.ForegroundColor = ConsoleColor.Green;
                 

                /* Welcome_User welcome_User = new Welcome_User();
                string username = welcome_User.Username;*/
                string enteredQuestion = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                

                // array willl capture words 
                string[] words = enteredQuestion.Split(' ');
                ArrayList storingWords = new ArrayList();
                // FOR  LOOPS 
                for (int i = 0; i < words.Length; i++)
                {
                    if (!ignore.Contains(words[i]))
                    {
                        storingWords.Add(words[i]);
                    } // end of if statement

                    // temp vaiable
                    Boolean found = false;
                    string message = string.Empty;


                    // using for loop to get answers
                    for (int j = 0; j < storingWords.Count; j++)
                    {
                        // seaching answer word by wword
                        for (int a = 0; a < replies.Count; a++)
                        {
                            if (storingWords[j].ToString().Contains(replies[a].ToString()))
                            {
                                //answers
                                message += replies[a];
                                found = true;
                            }
                        }// end of for loop



                    }
                    // display results
                    if (found)
                    {
                        //display the message
                        Console.WriteLine(message);

                        //Console.ForegroundColor = ConsoleColor.Green;
                        // Console.Write(input + ":");
                        //  Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" PLEASE Search something related to CYBER SECURITY");
                        Console.ForegroundColor = ConsoleColor.White;

                    }

                }
            }
        }// end of constructor
        private void store_replies()
        {
            // Method to store the replies

            replies.Add(" CyberBuddy :" + " Cbersecurity refers to the practices, technologies, and processes designed to protect digital information," +
                " networks, and computer systems from unauthorized access, use, disclosure, disruption, modification, or destruction." +
                " Cybersecurity is important because it helps protect sensitive information, prevents financial loss, and maintains the " +
                "confidentiality, integrity, and availability of data.");

            replies.Add("To protect yourself from cyber threats, use strong, unique passwords; enable two-factor authentication (2FA);" +
                " keep your operating system, software, and apps up-to-date; use reputable antivirus software; avoid suspicious links" +
                " and attachments; and use a virtual private network (VPN) when using public Wi-Fi.");
            replies.Add("CyberBuddy :" + "To ensure secure online transactions, use HTTPS websites; verify the website's authenticity; use strong passwords" +
                " and 2FA; keep your browser and software up-to-date; use a reputable payment gateway; and monitor your accounts for suspicious activity.");
            replies.Add("CyberBuddy :" + "To create strong, unique passwords, use a combination of uppercase and lowercase letters, numbers, and special characters; avoid " +
                "using easily guessable information (e.g., name, birthdate); and consider using a password manager to generate and store complex passwords.");
            replies.Add("CyberBuddy :" + "Two-factor authentication (2FA) is a security process that requires a user to provide two different authentication factors to" +
                " access a system, network, or application. 2FA typically combines something you know (e.g., password) with something you have (e.g., smartphone, token generator).");
            replies.Add("To manage passwords securely, use a reputable password manager to generate, store, and retrieve complex passwords; enable 2FA whenever possible; and avoid " +
                "using the same password across multiple sites.");
            replies.Add("CyberBuddy :" + "Using the same password across multiple sites increases the risk of a single data breach compromising multiple accounts. If a hacker gains access to one account," +
                " they may be able to use the same password to access other accounts.");
            replies.Add("CyberBuddy :" + "To secure your home Wi-Fi network, change the default administrator password; enable WPA2 encryption (or WPA3, if available); set up a guest network;" +
                " keep your router's firmware up-to-date; and use a reputable antivirus program.");
            replies.Add("CyberBuddy :" + "");
            replies.Add("CyberBuddy :" + "");
            replies.Add("CyberBuddy :" + "");
            replies.Add("CyberBuddy :" + "");
            replies.Add("");
            replies.Add("");
            replies.Add("");
            replies.Add("");
            replies.Add("");
            replies.Add("");
            replies.Add("");
            replies.Add("");
            replies.Add("");
        }// end of storing replies method
        private void store_ignore()
        {
            // Method to store the ignore
            // storing ignore in the array list
            ignore.Add("what is");
            ignore.Add("Tell me about");
            ignore.Add("how to change my");
            ignore.Add("How can I");
            ignore.Add("How do I ");
            ignore.Add("How can I ensure");
            ignore.Add("Chabge");
            ignore.Add("");
            ignore.Add("");
            ignore.Add("");
            ignore.Add("");
            ignore.Add("");
            ignore.Add("");
            ignore.Add("");
            ignore.Add("");
            ignore.Add("");
            ignore.Add("");
            ignore.Add("");
            ignore.Add("");
            ignore.Add("");
        }// end of  storing ignore method
    }//end of constructor
    }

