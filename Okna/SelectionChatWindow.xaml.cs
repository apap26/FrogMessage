using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using VkNet;
using System;
using System.Threading;


namespace MyApp
{
    public class SelectionChatWindow : Window
    {
        public Button SendMessage => this.FindControl<Button>("SendMessage");
        public Button Refresh => this.FindControl<Button>("Refresh");
        public TextBlock one => this.FindControl<TextBlock>("one");
        public TextBlock two => this.FindControl<TextBlock>("two");
        public TextBlock three => this.FindControl<TextBlock>("three");
        public TextBlock four => this.FindControl<TextBlock>("four");
        public TextBlock five => this.FindControl<TextBlock>("five");
        public TextBlock six => this.FindControl<TextBlock>("six");
        public TextBlock seven => this.FindControl<TextBlock>("seven");
        public TextBlock vosem => this.FindControl<TextBlock>("vosem");
        public TextBlock devat => this.FindControl<TextBlock>("devat");
        public TextBlock[] MessageHistory; 

        public TextBox Message => this.FindControl<TextBox>("Message");
        private VkApi api;
        private int PeerId = 279278413;
        public SelectionChatWindow(VkApi api)
        {
            this.api = api;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            SendMessage.Click += sendMessage_Click;
            Refresh.Click += refresh_Click;
            MessageHistory = new TextBlock[9];
            MessageHistory[0] = one;
            MessageHistory[1] = two;
            MessageHistory[2] = three;
            MessageHistory[3] = four;
            MessageHistory[4] = five;
            MessageHistory[5] = six;
            MessageHistory[6] = seven;
            MessageHistory[7] = vosem;
            MessageHistory[8] = devat;
        }

        private void sendMessage_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e){
            if(Message.Text == ""){return;}
            var rnd = new Random();
            try{
                api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams{
                    RandomId = rnd.Next(),
                    PeerId = this.PeerId,
                    Message = Message.Text
                });
            }catch(VkNet.Exception.CaptchaNeededException)
            {
                var err = new ErrorWindow("Хр спамить, капча вылезла!");
                err.Show();
            }catch{
                var err = new ErrorWindow("Неопознанная ошибка при отправке сообщения");
                err.Show();
            }
            Message.Text = "";
            refreshMessage();
        }
        private void refresh_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e){
            refreshMessage();
        }
        private void refreshMessage(){
            var mess = api.Messages.GetHistory(new VkNet.Model.RequestParams.MessagesGetHistoryParams{
                Count  = 9,
                PeerId = this.PeerId,
                Reversed = false
            });
            int i = 8;
            foreach(var e in mess.Messages){
                MessageHistory[i].Text = e.Text;
                i--;
            }
        }
    }
}