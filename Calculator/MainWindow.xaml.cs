using System;
using System.Collections.Generic;
using System.Data;
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
using static System.Net.Mime.MediaTypeNames;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string text;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNumeric_Click(object sender, RoutedEventArgs e)
        {
            texbBoxInput.Text += ((Button)sender).Content.ToString();
            text = texbBoxInput.Text ;//содержимое текстбкса сложили в строку
        }

        private void btnC_Click(object sender, RoutedEventArgs e)//кнопка очищение окошка ввода
        {
            texbBoxInput.Text = " ";
    }
        private void Compute(string s)//математические действия
        {
            double s2;
            for (int i = s.Length - 1; i > 0; i--)
                if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/')
                    s = "(" + s.Substring(0, i) + ")" + s.Substring(i);
                s2 = Convert.ToDouble(new DataTable().Compute(s, ""));
            texbBoxInput.Text = s2.ToString();
        }
      
        private void btnEquals_Click(object sender, RoutedEventArgs e)//кнопка очищение окошка ввода
        {
            try
            {
                Compute(text);
            }
            catch (Exception)
            {
                texbBoxInput.Text = "Error!";
            }
        }
     

    }
}
