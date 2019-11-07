using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using VkNet;
using System;

namespace MyApp
{
    public class MainWindow : Window
    {
        // Author this gude: apap26
        // ___GUIDE BEGIN___
        // гайд по созданию кнопки и привязке ее к действию или "гайд по тому как дышать" (если ты пишешь в блокноте, как и я)
        // Сначала пишешь в <Имя окна>.xaml Кнопку (как описать - кури доки)
        // Теперь в аналогичном этому файле, как поле пишешь:
        //  public Button Имя => this.FindControl<Тип>("Имя");
        // эта штука вроде как ищет объект в разметке (Если я правильно понял Карачева)
        // Потом описываешь функцию которая будет исполнятся при клике (См btn2_Click)
        // Она дб private void, и принимать в качестве аргументов (object sender, Avalonia.Interactivity.RoutedEventArgs e)
        // Теперь в ините подписываешся на событи нажатия ("чтобы повесить какое-либо событие, надо привязать его вручную.
        // способов несколько, можно подойти на паре.
        // сам использую подобное:
        // btnFrog.Click += <название метода обработки клика> (sender, args)" (С) Карачев)
        // Пишешь btn2.Click = btn2_Click; //Объект btn2 поле Click равно имя функции (Без скобочек)
        // Аналогичное работает и с текст боксами
        // !!!ДЛЯ ЛЮБИТЕЛЕЙ VISUAL STUDIO!!!
        // Вам не нужно объявлять это public Button Имя => this.FindControl<Тип>("Имя"); (Сгенерируется само)
        // Все остальное аналогично
        // ___END GUIDE___
        public Button Vhod => this.FindControl<Button>("Vhod");
        public Button Problem => this.FindControl<Button>("Problem");
        public Button frogButton => this.FindControl<Button>("frogButton");
        public TextBox Login => this.FindControl<TextBox>("Login");
        public TextBox Password => this.FindControl<TextBox>("Password");
        
        private VkApi api;
        public MainWindow(VkApi api)
        {
            this.api = api;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            Vhod.Click += Vhod_Click;
            Problem.Click += Problem_Click;
        }
        
        private void Problem_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e){
            // var rnd = new Random();
            // try{
            //     api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams{
            //         RandomId = rnd.Next(),
            //         UserId = 279278413,
            //         Message = "Саня, допили разметку!!1!"
            //     });
            // }catch(VkNet.Exception.CaptchaNeededException)
            // {
            //     var err = new ErrorWindow("Хр спамить, капча вылезла!");
            //     err.Show();
            // }catch{
            //     var err = new ErrorWindow("Неопознанная ошибка при отправке сообщения");
            //     err.Show();
            // }

            var vin = new ErrorWindow("Проблемы с доступом на vk.com? Просто добавь цифру %i чтобы получилось vk%i.com");
            vin.Show();
        }
        private void Vhod_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try{
                api.Authorize(new VkNet.Model.ApiAuthParams{
                    ApplicationId = 2685278,
                    Login = Login.Text,
                    Password = Password.Text,
                });
                var vin = new SelectionChatWindow(api);
                vin.Show();
                this.Close();
            }catch(VkNet.Exception.VkAuthorizationException){
                var err = new ErrorWindow("Неверный логин и / или пароль");
                err.Show();
            }catch(VkNet.Exception.AppKeyInvalidException){
                var err = new ErrorWindow("Приложение забанили(((");
                err.Show();
            }catch(Exception){
                var err = new ErrorWindow("хз чё произошло");
                err.Show();
            }
            Password.Text = "";
        }
    }
}
