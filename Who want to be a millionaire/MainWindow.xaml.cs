using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Who_want_to_be_a_millionaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Question> _questions = new List<Question>();
        private List<Question> _oldQuestions = new List<Question>();
        private bool _isStart = false;
        private bool _fiftyFifty = false, _callToFriend = false, _askPeople = false;

        public MainWindow()
        {
            InitializeComponent();

            #region InitialListOfQuestions

            _questions.Add(new Question("До какого события продолжается рождественский пост?",
                "До первой звезды", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Какую фамилию носил главный герой поэмы А. Твардовского?",
                "Тёркин", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("В песне какого барда есть строчка \"Лыжи у печки стоят... \"?",
                "Юрий Визбор", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question(
                "Что в конце XIX века было основным товаром на Лубянской площади в Москве во время Введенской ярмарки?",
                "Сани", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Какой советский космонавт получил первую космическую почту?",
                "Владимир Шаталов", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Как называют звезду, которая указала волхвам место рождения Христа?",
                "Вифлеемская", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Где, если верить пословице, любопытной Варваре нос оторвали?",
                "На базаре", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question(
                "Как называют период времени, когда солнце в северных широтах не опускается за горизонт?",
                "Полярный день", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Кто автор проекта радиобашни на Шаболовке?",
                "Владимир Шухов", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("За чем послала жена мужа в мультфильме \"Падал прошлогодний снег\"?",
                "За ёлкой", "1", "2", "3", "4", "5", "6", "7"));

            _questions.Add(new Question("Какой знак восточного гороскопа следует за знаком Дракона?",
                "Змея", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Где проходила первая \"Главная ёлка Страны Советов\"?",
                "В Доме союзов", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Какой \"танец\" исполнил Чарли Чаплин в фильме \"Золотая лихорадка\"?",
                "Танец булочек", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Какие семьи, по мнению Л. Н. Толстого, похожи друг на друга?",
                "Счастливые", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question(
                "Какое неофициальное звание получал альпинист, покоривший пять высочайших вершин СССР?",
                "Снежный барс", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question(
                "Как на Руси называли мелкие льдинки, плавающие на поверхности воды перед ледоставом?",
                "Сало", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Какое астрономическое явление жители Земли могут наблюдать один раз в 76 лет?",
                "Комета Галлея", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("К какому семейству птиц относится снегирь?",
                "Вьюрковые", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Что испанцы съедают в новогоднюю полночь с каждым ударом часов?",
                "Виноградинку", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("В какую одежду принято плакать, чтобы вызвать сочувствие?",
                "В жилетку", "1", "2", "3", "4", "5", "6", "7"));

            _questions.Add(new Question("Что в декабре-январе делают молодые олени?",
                "Сбрасывают рога", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Какое прозвище носил король Англии Ричард I?",
                "Львиное Сердце", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("На какой день недели приходится первый день Нового 2002 года?",
                "Вторник", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question(
                "На премьере какого из этих балетов две главные партии танцевала одна балерина?",
                "\"Лебединое озеро\"", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question(
                "Какие по счёту часы хотел подарить Киврин Кире Шемаханской в канун Нового года в кинофильме \"Чародеи\"?",
                "14", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Что в дореволюционной России означала поговорка \"Идти под ёлку\"?",
                "Идти в кабак", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Какое из этих украшений можно встретить на новогодней ёлке?",
                "Бусы", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Какую обувь приобрёл к зиме Шарик из мультфильма про Простоквашино?",
                "Кеды", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question("Как называется традиционная народная русская забава \"Взятие снежного... \"?",
                "Городка", "1", "2", "3", "4", "5", "6", "7"));
            _questions.Add(new Question(
                "Чем, по словам Огурцова, героя кинофильма \"Карнавальная ночь\", не воспитаешь зрителя?",
                "Голыми ногами", "1", "2", "3", "4", "5", "6", "7"));

            #endregion


        }

        private void StartStopButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (StartStopButton.Content.Equals("Start"))
            {
                _isStart = true;
                StartStopButton.Content = "Stop";
                LoadNextQuestion();
            }
            else
            {
                _isStart = false;
                ClearQuestionsReset();
            }
        }

        private void ClearQuestionsReset()
        {
            StartStopButton.Content = "Start";
            QuestionTextBlock.Text = String.Empty;
            ButtonFirstVariant.Content = String.Empty;
            ButtonSecondVariant.Content = String.Empty;
            ButtonThirdVariant.Content = String.Empty;
            ButtonFourthVariant.Content = String.Empty;
            MoneyPriseList.SelectedIndex = 14;
            foreach (var oldQuestion in _oldQuestions)
            {
                oldQuestion.ResetQuestion();
                _questions.Add(oldQuestion);
            }
            _oldQuestions.Clear();
            ButtonAskPeople.IsEnabled = true;
            ButtonCallToFriend.IsEnabled = true;
            ButtonFiftyFifty.IsEnabled = true;
            _isStart = false;
            foreach (ListBoxItem item in MoneyPriseList.Items)
            {
                item.Background = Brushes.AliceBlue;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClearQuestionsReset();
        }

        private void ButtonAnswers_OnClick(object sender, RoutedEventArgs e)
        {
            if (_isStart)
            {
                if (e.OriginalSource is Button)
                {
                    if (_oldQuestions[_oldQuestions.Count - 1].IsItTrue(((Button) e.OriginalSource).Content.ToString()))
                    {
                        ((Button) e.OriginalSource).Background = Brushes.Green;
                        String str = (MoneyPriseList.Items[MoneyPriseList.SelectedIndex] as ListBoxItem).Content
                            .ToString();                        
                        if (MoneyPriseList.SelectedIndex == 0)
                        {
                            MessageBox.Show("AWESOME! You win that game and earn 1 000 000 $!", "K.O.",
                                MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            ClearQuestionsReset();
                        }
                        else
                        {
                            MessageBox.Show("Congraturlations! You are earning " + str + "$ !", "WOW", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                            LoadNextQuestion();
                        }                                              
                    }
                    else
                    {
                        ((Button) e.OriginalSource).Background = Brushes.Red;
                        MessageBox.Show("Youlose, sorry((", "Oh", MessageBoxButton.OK, MessageBoxImage.Stop);
                        ClearQuestionsReset();
                    }
                }
            }
        }

        private void LoadNextQuestion()
        {
            if (0 < MoneyPriseList.SelectedIndex)
            {
                var rnd = new Random(DateTime.Now.Second);
                (MoneyPriseList.SelectedItem as ListBoxItem).Background = Brushes.BlueViolet;
                if (_oldQuestions.Count != 0)
                {                    
                    MoneyPriseList.SelectedIndex = MoneyPriseList.SelectedIndex - 1;                    
                }
                _oldQuestions.Add(_questions[rnd.Next(0, _questions.Count)]);
                _questions.Remove(_oldQuestions[_oldQuestions.Count - 1]);
                QuestionTextBlock.Text = _oldQuestions[_oldQuestions.Count - 1].GeneralQuestion;
                ButtonFirstVariant.Content = _oldQuestions[_oldQuestions.Count - 1].TakeAnswer;
                ButtonSecondVariant.Content = _oldQuestions[_oldQuestions.Count - 1].TakeAnswer;
                ButtonThirdVariant.Content = _oldQuestions[_oldQuestions.Count - 1].TakeAnswer;
                ButtonFourthVariant.Content = _oldQuestions[_oldQuestions.Count - 1].TakeAnswer;
                ButtonFirstVariant.Background = Brushes.AliceBlue;
                ButtonSecondVariant.Background = Brushes.AliceBlue;
                ButtonThirdVariant.Background = Brushes.AliceBlue;
                ButtonFourthVariant.Background = Brushes.AliceBlue;
            }
        }

        private void ButtonExit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonFiftyFifty_OnClick(object sender, RoutedEventArgs e)
        {
            if (_isStart)
            {
                ButtonFiftyFifty.IsEnabled = false;
                int value = 0;
                if (!_oldQuestions[_oldQuestions.Count - 1].IsItTrue(ButtonFirstVariant.Content.ToString()))
                {
                    ButtonFirstVariant.Background = Brushes.Orange;
                    value++;
                }
                if (!_oldQuestions[_oldQuestions.Count - 1].IsItTrue(ButtonSecondVariant.Content.ToString()))
                {
                    ButtonSecondVariant.Background = Brushes.Orange;
                    value++;
                }
                if (value == 2)
                {
                    return;
                }
                if (!_oldQuestions[_oldQuestions.Count - 1].IsItTrue(ButtonThirdVariant.Content.ToString()))
                {
                    ButtonThirdVariant.Background = Brushes.Orange;
                    value++;
                }
                if (value == 2)
                {
                    return;
                }
                if (!_oldQuestions[_oldQuestions.Count - 1].IsItTrue(ButtonFourthVariant.Content.ToString()))
                {
                    ButtonFourthVariant.Background = Brushes.Orange;
                    value++;
                }
                if (value == 2)
                {
                    return;
                }                
            }
        }

        private void ButtonCallToFriend_OnClick(object sender, RoutedEventArgs e)
        {
            if (_isStart)
            {
                ButtonCallToFriend.IsEnabled = false;
                if (_oldQuestions[_oldQuestions.Count - 1].IsItTrue(ButtonFirstVariant.Content.ToString()))
                {
                    ButtonFirstVariant.Background = Brushes.Blue;
                    return;
                }
                if (_oldQuestions[_oldQuestions.Count - 1].IsItTrue(ButtonSecondVariant.Content.ToString()))
                {
                    ButtonSecondVariant.Background = Brushes.Blue;
                    return;
                }
                if (_oldQuestions[_oldQuestions.Count - 1].IsItTrue(ButtonThirdVariant.Content.ToString()))
                {
                    ButtonThirdVariant.Background = Brushes.Blue;
                    return;
                }
                if (_oldQuestions[_oldQuestions.Count - 1].IsItTrue(ButtonFourthVariant.Content.ToString()))
                {
                    ButtonFourthVariant.Background = Brushes.Blue;
                    return;
                }                
            }
        }

        private void ButtonAskPeople_OnClick(object sender, RoutedEventArgs e)
        {
            if (_isStart)
            {
                ButtonAskPeople.IsEnabled = false;
                AskPeopleGraph apg = new AskPeopleGraph(ButtonFirstVariant, ButtonSecondVariant, ButtonThirdVariant, ButtonFourthVariant);
                apg.Show();
            }
        }
    }
}
