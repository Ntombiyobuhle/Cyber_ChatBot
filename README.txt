Cyber_ChatBot
 # 1 When you run the application/ program  
  - the voice greeting will play using format .wav
  - if the file is not found or using a different format it will show an error message
  - the voice greeting audio will

 #   2 After the vioce greeting the Ascii art logo will display
    -   The image is in a format jpeg
    -   the image is reginerated by ASCII
    -  if the image is not found the program will show an error message
   
  #  3 After the image the Chatbot will display an welcoming message
    - it will welcome the user and it has borders

  #    4 Afer the welcome message the chatbot prompts for username 
    -   after the user input there name the input validation method will check if the user input the name using  numbers and symbols
    -   if so the chotbot will tell the user to prompt using there name using letters only.
    -   when the user prompts the correct thing the chatbot will greet the user and include user name in text form
    -   and tell the user to prompt a question related to cybersecurity
    -    eg: Hello Sihle I am here to help you with cybersecurity queries.
   
  #    5 After the user name the user will be able to ask questions related to cybersecurity
    - password
    - SQL
    - Phishing
    - SQL injection
   
    -  if you ask something that is not relation it will ptint something like this
    -  eg: PLEASE search something related to CYBER SECURITY.
    -   when the user type Exit it will print
    -   eg "Thank you "  username +" for using CyberBuddy. Hope we helped you answer your queries!
    
#6 Example how it will show

=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=
CyberBuddy : Welcome to CyberBuddy!
=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=
CyberBuddy : What is your name?
You: Sihle
CyberBuddy : Hello Sihle, I am here to help you with cybersecurity queries.
CyberBuddy : Please type your question or type 'Exit' to end the conversation.
Sihle: What is password
CyberBuddy : Use strong passwords, enable 2FA, and keep your system updated.

CyberBuddy : Please type your question or type 'Exit' to end the conversation
Sihle:  what is Sql
CyberBuddy : SQL stands for Structured Query Language, used for managing databases.

CyberBuddy : Please type your question or type 'Exit' to end the conversation
Sihle: What is phishing
CyberBuddy : Phishing is a fraudulent attempt to obtain sensitive information.

CyberBuddy : Please type your question or type 'Exit' to end the conversation
Sihle:  how is sihle
CyberBuddy :  PLEASE search something related to CYBER SECURITY.
CyberBuddy : Please type your question or type 'Exit' to end the conversation


#part 2 
#Memory
Remembers user's name across multiple questions.

Can respond to "What is my name?" with personalized recall.
it recalls all the covenversation you had with the chatbot.
Example for memory
CyberBuddy : What is your name?
You: Alexis
CyberBuddy : Hello Alexis, I am here to help you with cybersecurity queries.
CyberBuddy : Please type your question or type 'Exit' to end the conversation.
Alexis: Tell me about phishing
CyberBuddy : Phishing is an attempt to trick users into providing sensitive information. Avoid clicking links in unexpected emails.
sihle: what is phishing
CyberBuddy : To recognize a phishing email, check for grammatical errors, suspicious links, and unexpected requests for personal information.
sihle: tell me more about phishing
CyberBuddy : Phishing is an attempt to trick users into providing sensitive information. Avoid clicking links in unexpected emails.
sihle: what is my name
CyberBuddy : Your name is sihle.
sihle: remember
CyberBuddy : Here is everything we've talked about:
Alexis: tell me about phishing
CyberBuddy : Phishing is an attempt to trick users into providing sensitive information. Avoid clicking links in unexpected emails.
sihle: what is phishing
CyberBuddy : To recognize a phishing email, check for grammatical errors, suspicious links, and unexpected requests for personal information.
sihle: tell more about phishing
CyberBuddy : Phishing is an attempt to trick users into providing sensitive information. Avoid clicking links in unexpected emails.
sihle: what is my name
CyberBuddy : Your name is sihle.


# Sentimental Awareness
Detects if the user expresses frustration or confusion.

Responds with calming or reassuring messages if sentiment is negative.
example

sihle: im worried about my password
CyberBuddy :  It's completely understandable to feel that way. Cybersecurity can be overwhelming, but I'm here to help.
Use a password manager to store your credentials safely.

# Response Randomization
Answers are randomly selected from a pool of valid responses for each topic.
Adds variety so the user doesn't get the same answer repeatedly.
Example for randomisation 

Sihle:  tell me about password
CyberBuddy : Use a password manager to store your credentials safely.
Sihle:  tell me more about password
CyberBuddy : A strong password should be at least 12 characters long, include numbers, symbols, and a mix of uppercase and lowercase letters.


