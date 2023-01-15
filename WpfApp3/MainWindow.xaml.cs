using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FontFamilyChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SimpleEditor != null) 
            {
                string FontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
                SimpleEditor.FontFamily = new FontFamily(FontName);
            }
        }

        private void FontSizeChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SimpleEditor != null)
            {
                double FontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as TextBlock).Text);
                SimpleEditor.FontSize = FontSize;
            }
        }

        private void FontWeightButton_Click(object sender, RoutedEventArgs e)
        {
            if (SimpleEditor.FontWeight == FontWeights.Normal)
                SimpleEditor.FontWeight = FontWeights.Bold;
            else SimpleEditor.FontWeight = FontWeights.Normal;
        }

        private void FontStyleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SimpleEditor.FontStyle == FontStyles.Normal)
                SimpleEditor.FontStyle = FontStyles.Italic;
            else SimpleEditor.FontStyle = FontStyles.Normal;
        }

        private void FontDecorationButton_Click(object sender, RoutedEventArgs e)
        {
            if(SimpleEditor.TextDecorations.Count == 0)
                SimpleEditor.TextDecorations.Add(TextDecorations.Underline);
            else SimpleEditor.TextDecorations.Remove(TextDecorations.Underline[0]);
        }

        private void BlackRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (SimpleEditor != null) SimpleEditor.Foreground = Brushes.Black;
        }

        private void RedRadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (SimpleEditor != null) SimpleEditor.Foreground = Brushes.Red;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if(openFileDialog.ShowDialog() == true)
                SimpleEditor.Text = File.ReadAllText(openFileDialog.FileName);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, SimpleEditor.Text);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(SimpleEditor !=null && SimpleEditor.Text.Length > 0) e.CanExecute = true;
            else e.CanExecute = false;
        }
    }
}
