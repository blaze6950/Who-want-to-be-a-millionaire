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
using System.Windows.Shapes;

namespace Who_want_to_be_a_millionaire
{
    /// <summary>
    /// Interaction logic for AskPeopleGraph.xaml
    /// </summary>
    public partial class AskPeopleGraph : Window
    {
        public AskPeopleGraph(Button firstButton, Button secondButton, Button thirdButton, Button fourthButton)
        {
            InitializeComponent();
            ButtonFirst.Content = firstButton.Content;
            ButtonSecond.Content = secondButton.Content;
            ButtonThird.Content = thirdButton.Content;
            ButtonFourth.Content = fourthButton.Content;

            RandomizeVoices();
        }

        private void RandomizeVoices()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            List<int> values = new List<int>();
            values.Add(0);
            values.Add(0);
            values.Add(0);
            values.Add(0);
            for (int i = 0; i < 300; i++)
            {
                values[rnd.Next(0, 4)]++;
            }
            values[0] = values[0] / 3;
            values[1] = values[1] / 3;
            values[2] = values[2] / 3;
            values[3] = values[3] / 3;

            RectangleFirst.Width = values[0] * 2.4;
            RectangleFirst.ToolTip = values[0].ToString() + " %";
            RectangleSecond.Width = values[1] * 2.4;
            RectangleSecond.ToolTip = values[1].ToString() + " %";
            RectangleThird.Width = values[2] * 2.4;
            RectangleThird.ToolTip = values[2].ToString() + " %";
            RectangleFourth.Width = values[3] * 2.4;
            RectangleFourth.ToolTip = values[3].ToString() + " %";

            ButtonFirst.ToolTip = values[0].ToString() + " %";
            ButtonSecond.ToolTip = values[1].ToString() + " %";
            ButtonThird.ToolTip = values[2].ToString() + " %";
            ButtonFourth.ToolTip = values[3].ToString() + " %";
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
