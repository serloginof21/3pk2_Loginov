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

namespace PZ_6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btn1(object sender, RoutedEventArgs e)
        {
            var task1 = CountNumbers(235, 100, pgB);
            await task1;
        }

        async static Task<int> CountNumbers(int a, int b, ProgressBar p)
        {
            for(int j = 0; j < b; j++)
            {
                a = (a * 10 / 50 * a) + (a+10/1480*2);
                p.Value++;
                await Task.Delay(TimeSpan.FromSeconds(0.5));
            }
            return a;
        }
    }
}
