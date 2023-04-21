using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PZ_10
{
    public partial class MainWindow : Window
    {
        List<NotePadStatus> st = new List<NotePadStatus>();
        int cntF = 0;
        int cntsF = 10;

        public MainWindow()
        {
            InitializeComponent();
            SaveText();
        }
        async Task SaveText()
        {
            TextRange text = new TextRange(tb1.Document.ContentStart, tb1.Document.ContentEnd);
            NotePadStatus save = new NotePadStatus(tb1.FontSize, text.Text, tb1.FontWeight, tb1.FontStyle);
            if (cntsF > 0)
            {
                st.Add(save);
                cntsF--;

                MessageBox.Show($"Сохранение: {st.Count}");
            }
            else
            {
                st = new List<NotePadStatus>();
                cntsF = 4;
                st.Add(save);

                MessageBox.Show($"Сохранение: {st.Count}");
            }
            await Task.Delay(TimeSpan.FromSeconds(5));
            await SaveText();
        }
        private void Bold_Text(object sender, RoutedEventArgs e)
        {
            Bold bold = new Bold(tb1.Selection.Start, tb1.Selection.End);
        }

        private void Save_File(object sender, RoutedEventArgs e)
        {
            TextRange txt = new TextRange(tb1.Document.ContentStart, tb1.Document.ContentEnd);
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(dialog.FileName))
                {
                    writer.Write(txt.Text);
                }
            }
        }

        private void Italic_Text(object sender, RoutedEventArgs e)
        {
            Italic italic = new Italic(tb1.Selection.Start, tb1.Selection.End);
        }

        private void Underline_Text(object sender, RoutedEventArgs e)
        {
            Underline underline = new Underline(tb1.Selection.Start, tb1.Selection.End);
        }

        private void Change_txt(object sender, RoutedEventArgs e)
        {
            int sz = Convert.ToInt32(txtSize.Text);
            tb1.FontSize = sz;
        }

        private void Undo_Text(object sender, RoutedEventArgs e)
        {
            NotePadStatus status = new NotePadStatus();

            if (cntF < st.Count) status = st[st.Count - cntF - 1];
            tb1.FontSize = status.FontSize;
            tb1.FontStyle = status.FontStyle;
            tb1.FontWeight = status.FontWeight;

            FlowDocument doc = new FlowDocument();

            Paragraph p = new Paragraph();

            p.Inlines.Add(new Run(status.Txt));
            doc.Blocks.Add(p);
            tb1.Document = doc;
            cntF++;
        }
    }
}
