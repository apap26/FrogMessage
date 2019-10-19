using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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

        public Button btn2 => this.FindControl<Button>("btn2");
        public Button frogButton => this.FindControl<Button>("frogButton");
        public TextBox tb1 => this.FindControl<TextBox>("tb1");
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btn2_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            tb1.Text = "btn2 is clicked!!";
        }
        private void frogButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            tb1.Text = "I'm FROOOOOG!!!";
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            btn2.Click += btn2_Click;
            frogButton.Click += frogButton_Click;
        }
        
    }
}
