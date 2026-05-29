using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using NdivhuwoCyberShieldPart2.Models;
using NdivhuwoCyberShieldPart2.Services;

namespace NdivhuwoCyberShieldPart2
{
    // This is the main window where the user chats with the bot.
    public partial class MainWindow : Window
    {
        private readonly UserMemory _memory;
        private readonly ChatbotEngine _engine;
        private readonly AudioService _audioService;

        public MainWindow()
        {
            InitializeComponent();

            _memory = new UserMemory();
            _engine = new ChatbotEngine(_memory);
            _audioService = new AudioService();

            AsciiLogoText.Text = BuildAsciiLogo();
            UpdateMemoryDisplay();

            AddBotMessage("Welcome! I am your CyberShield Assistant. Enter your name on the left, ask a cybersecurity question, or use the quick topic buttons.");

            // Plays the greeting automatically without showing a system message.
            _audioService.PlayGreeting();
        }

        // This method sends the user's typed message to the chatbot.
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendCurrentMessage();
        }

        // This method lets the Enter key send the message.
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendCurrentMessage();
            }
        }

        // This method lets the Enter key save the name from the name box.
        private void NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SaveUserName();
            }
        }

        // This method saves the user's name from the textbox.
        private void SaveNameButton_Click(object sender, RoutedEventArgs e)
        {
            SaveUserName();
        }

        // This method is shared by the Save Name button and the Enter key.
        private void SaveUserName()
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                _memory.Name = NameTextBox.Text.Trim();
                UpdateMemoryDisplay();
                AddSystemMessage("Name saved for this session.");
            }
        }

        // This method sends a quick topic when a button is clicked.
        private void QuickTopic_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Content is string topic)
            {
                InputTextBox.Text = topic == "Tell me more"
                    ? "Tell me more"
                    : "Tell me about " + topic;

                SendCurrentMessage();
            }
        }

        // This method performs the full chat process.
        private void SendCurrentMessage()
        {
            string userText = InputTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(userText))
                return;

            AddUserMessage(userText);

            InputTextBox.Clear();

            BotReply reply = _engine.GetReply(userText);

            AddBotMessage(reply.Message);

            UpdateMemoryDisplay();
        }

        // This method adds a user message bubble.
        private void AddUserMessage(string message)
        {
            AddMessageBubble(
                "You",
                message,
                HorizontalAlignment.Right,
                "#D9F1FF",
                "#07111F");
        }

        // This method adds a bot message bubble.
        private void AddBotMessage(string message)
        {
            AddMessageBubble(
                "CyberShield",
                message,
                HorizontalAlignment.Left,
                "#EEF7F0",
                "#07111F");
        }

        // This method adds small system messages.
        private void AddSystemMessage(string message)
        {
            AddMessageBubble(
                "System",
                message,
                HorizontalAlignment.Center,
                "#F4F0FF",
                "#333333");
        }

        // This method creates the visual chat bubble used by all messages.
        private void AddMessageBubble(
            string title,
            string message,
            HorizontalAlignment alignment,
            string background,
            string foreground)
        {
            Border bubble = new()
            {
                Background = (Brush)new BrushConverter().ConvertFromString(background)!,
                CornerRadius = new CornerRadius(16),
                Padding = new Thickness(14),
                Margin = new Thickness(0, 6, 0, 6),
                MaxWidth = 650,
                HorizontalAlignment = alignment
            };

            StackPanel content = new();

            content.Children.Add(new TextBlock
            {
                Text = title,
                FontWeight = FontWeights.Bold,
                Foreground = (Brush)new BrushConverter().ConvertFromString(foreground)!
            });

            content.Children.Add(new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                LineHeight = 21,
                Margin = new Thickness(0, 4, 0, 0),
                Foreground = (Brush)new BrushConverter().ConvertFromString(foreground)!
            });

            bubble.Child = content;

            ChatPanel.Children.Add(bubble);

            ChatScrollViewer.ScrollToEnd();
        }

        // This method updates the memory text shown on the left side.
        private void UpdateMemoryDisplay()
        {
            string favourite =
                string.IsNullOrWhiteSpace(_memory.FavouriteTopic)
                ? "Not set yet"
                : _memory.FavouriteTopic;

            string lastTopic =
                string.IsNullOrWhiteSpace(_memory.LastTopic)
                ? "None yet"
                : _memory.LastTopic;

            string name =
                string.IsNullOrWhiteSpace(_memory.Name)
                ? string.Empty
                : _memory.Name;

            MemoryTextBlock.Text =
                $"Name: {name}\n" +
                $"Favourite topic: {favourite}\n" +
                $"Last topic: {lastTopic}\n" +
                $"Messages remembered: {_memory.TopicHistory.Count}";
        }

        // This method keeps the exact same ASCII logo from the Part 1 console app.
        private string BuildAsciiLogo()
        {
            return @"███╗   ███╗ █████╗ ████████╗██╗██╗     ██████╗  █████╗ 
████╗ ████║██╔══██╗╚══██╔══╝██║██║     ██╔══██╗██╔══██╗
██╔████╔██║███████║   ██║   ██║██║     ██║  ██║███████║
██║╚██╔╝██║██╔══██║   ██║   ██║██║     ██║  ██║██╔══██║
██║ ╚═╝ ██║██║  ██║   ██║   ██║███████╗██████╔╝██║  ██║
╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝╚══════╝╚═════╝ ╚═╝  ╚═╝";
        }
    }
}