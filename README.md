# CyberShield Assistant – Part 2 GUI Cybersecurity Chatbot

## Student Information

- **Student Name:** Ndivhuwo
- **Module:** Programming 2A
- **Module Code:** PROG6221
- **Project:** CyberShield Assistant – POE Part 2
- **Institution:** Rosebank College

---

# Project Overview

CyberShield Assistant is a professional WPF GUI Cybersecurity Awareness Chatbot developed in C#.  

This project builds on the original Part 1 console chatbot by transforming it into a modern graphical desktop application with advanced interactive features required in Part 2 of the POE.

The chatbot helps educate users about cybersecurity topics such as:

- Password safety
- Online scams
- Phishing attacks
- Privacy protection
- Two-factor authentication (2FA)
- Safe browsing
- Malware awareness
- Social engineering

The chatbot also supports memory, sentiment detection, dynamic responses, and conversation flow to create a more natural and engaging user experience.

---

# Features Implemented

## GUI Design and Implementation

- Professional WPF graphical interface
- Modern cybersecurity-themed colour palette
- Responsive layout with smooth user interaction
- Chat bubbles for conversations
- Dedicated memory panel
- Quick topic buttons
- ASCII art logo from Part 1
- Automatic voice greeting on startup

---

## Keyword Recognition

The chatbot recognises many cybersecurity-related keywords including:

- password
- phishing
- privacy
- scam
- malware
- hacking
- social engineering
- 2FA
- ransomware
- VPN
- identity theft
- cyberbullying
- antivirus
- suspicious links
- online safety

The bot responds with relevant cybersecurity guidance depending on the topic detected.

---

## Random Responses

The chatbot uses lists and collections to provide different responses for the same topic.

This helps conversations feel:

- More natural
- Less repetitive
- More engaging

Example:
Different phishing tips appear each time the user asks.

---

## Conversation Flow

The chatbot remembers the current topic and supports follow-up questions such as:

- Tell me more
- Explain more
- Give me another tip
- Another example

The conversation continues naturally without restarting.

---

## Memory and Recall

The chatbot stores user information during the session including:

- User name
- Favourite cybersecurity topic
- Last discussed topic
- Topic history

The chatbot uses this information to personalise responses.

---

## Sentiment Detection

The chatbot detects emotions such as:

- Worried
- Curious
- Frustrated
- Confused

The responses adjust based on the user’s mood to create a more empathetic interaction.

Example:

User:
> I am worried about scams

Chatbot:
> It is understandable to feel worried about scams. Let me help you stay safe online.

---

## Error Handling

The chatbot handles:

- Empty input
- Unknown questions
- Unexpected text
- Invalid messages

The application continues running smoothly without crashing.

---

## Code Structure and Optimisation

The project uses:

- Object-Oriented Programming (OOP)
- Classes and methods
- Dictionaries
- Lists
- Collections
- Modular structure
- Beginner-friendly comments

The project was designed to allow easy expansion in Part 3.

---

# Technologies Used

- C#
- WPF
- .NET 8
- XAML
- Visual Studio 2022

---

# Project Structure

```text
Ndivhuwo_CyberShield_Part2/
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── App.xaml
├── App.xaml.cs
│
├── Models/
│   ├── UserMemory.cs
│   └── BotReply.cs
│
├── Services/
│   ├── ChatbotEngine.cs
│   ├── AudioService.cs
│   ├── ResponseService.cs
│   ├── SentimentService.cs
│   └── MemoryService.cs
│
├── Resources/
│   └── greeting.wav
│
├── README.md
│
└── NdivhuwoCyberShieldPart2.csproj


## How to Run

1. Open `NdivhuwoCyberShieldPart2.csproj` in Visual Studio.
2. Restore packages if prompted.
3. Ensure `greeting.wav` is inside the `Resources` folder.
4. Build the project.
5. Run the WPF application.
6. Enter your name and start chatting with the chatbot.