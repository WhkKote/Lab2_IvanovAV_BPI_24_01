using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Lab2_IvanovAV_BPI_24_01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Formula1Image.Source = ByteArrayToImageSource(Properties.Resources.p1);
            Formula2Image.Source = ByteArrayToImageSource(Properties.Resources.p2);
            Formula3Image.Source = ByteArrayToImageSource(Properties.Resources.p3);
            Formula4Image.Source = ByteArrayToImageSource(Properties.Resources.p4);
            Variant4Image.Source = ByteArrayToImageSource(Properties.Resources.p5);

            Formula1FComboBox.ItemsSource = new[] { 4, 5, 6, 7, 8, 9 };
            Formula2FComboBox.ItemsSource = new[] { 10, 20, 30, 40 };
            Formula3CComboBox.ItemsSource = new[] { 0, 1 };
            Formula3DComboBox.ItemsSource = new[] { -1, 0, 1 };
            Formula4CComboBox.ItemsSource = new[] { 0, 1, 2, 3, 4, 5 };
        }

        private BitmapImage ByteArrayToImageSource(byte[] data)
        {
            using MemoryStream memory = new MemoryStream(data);

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = memory;
            image.EndInit();
            image.Freeze();

            return image;
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text = string.Empty;

            try
            {
                Formula formula;

                if (Formula1RadioButton.IsChecked == true)
                {
                    if (Formula1ATextBox.Text.Trim() == string.Empty)
                        throw new ArgumentException("Введите значение A.");

                    if (Formula1FComboBox.SelectedItem == null)
                        throw new ArgumentException("Выберите значение F.");

                    double a = double.Parse(Formula1ATextBox.Text.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture);
                    int f = Convert.ToInt32(Formula1FComboBox.SelectedItem);

                    if (double.IsNaN(a) || double.IsInfinity(a))
                        throw new ArgumentException("Значение A должно быть конечным числом.");

                    formula = new Formula1(a, f);
                }
                else if (Formula2RadioButton.IsChecked == true)
                {
                    if (Formula2ATextBox.Text.Trim() == string.Empty)
                        throw new ArgumentException("Введите значение A.");

                    if (Formula2BTextBox.Text.Trim() == string.Empty)
                        throw new ArgumentException("Введите значение B.");

                    if (Formula2FComboBox.SelectedItem == null)
                        throw new ArgumentException("Выберите значение F.");

                    double a = double.Parse(Formula2ATextBox.Text.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture);
                    double b = double.Parse(Formula2BTextBox.Text.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture);
                    int f = Convert.ToInt32(Formula2FComboBox.SelectedItem);

                    if (double.IsNaN(a) || double.IsInfinity(a) || double.IsNaN(b) || double.IsInfinity(b))
                        throw new ArgumentException("Значения A и B должны быть конечными числами.");

                    formula = new Formula2(a, b, f);
                }
                else if (Formula3RadioButton.IsChecked == true)
                {
                    if (Formula3ATextBox.Text.Trim() == string.Empty)
                        throw new ArgumentException("Введите значение A.");

                    if (Formula3BTextBox.Text.Trim() == string.Empty)
                        throw new ArgumentException("Введите значение B.");

                    if (Formula3CComboBox.SelectedItem == null)
                        throw new ArgumentException("Выберите значение C.");

                    if (Formula3DComboBox.SelectedItem == null)
                        throw new ArgumentException("Выберите значение D.");

                    double a = double.Parse(Formula3ATextBox.Text.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture);
                    double b = double.Parse(Formula3BTextBox.Text.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture);
                    int c = Convert.ToInt32(Formula3CComboBox.SelectedItem);
                    int d = Convert.ToInt32(Formula3DComboBox.SelectedItem);

                    if (double.IsNaN(a) || double.IsInfinity(a) || double.IsNaN(b) || double.IsInfinity(b))
                        throw new ArgumentException("Значения A и B должны быть конечными числами.");

                    formula = new Formula3(a, b, c, d);
                }
                else if (Formula4RadioButton.IsChecked == true)
                {
                    if (Formula4ATextBox.Text.Trim() == string.Empty)
                        throw new ArgumentException("Введите значение A.");

                    if (Formula4CComboBox.SelectedItem == null)
                        throw new ArgumentException("Выберите значение C.");

                    if (Formula4DTextBox.Text.Trim() == string.Empty)
                        throw new ArgumentException("Введите значение D.");

                    double a = double.Parse(Formula4ATextBox.Text.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture);
                    int c = Convert.ToInt32(Formula4CComboBox.SelectedItem);
                    int d = int.Parse(Formula4DTextBox.Text.Trim());

                    if (double.IsNaN(a) || double.IsInfinity(a))
                        throw new ArgumentException("Значение A должно быть конечным числом.");

                    if (d < 0)
                        throw new ArgumentException("Значение D не может быть меньше 0.");

                    formula = new Formula4(a, c, d);
                }
                else if (Variant4RadioButton.IsChecked == true)
                {
                    if (Variant4NTextBox.Text.Trim() == string.Empty)
                        throw new ArgumentException("Введите значение N.");

                    if (Variant4KTextBox.Text.Trim() == string.Empty)
                        throw new ArgumentException("Введите значение K.");

                    if (Variant4XTextBox.Text.Trim() == string.Empty)
                        throw new ArgumentException("Введите значение X.");

                    if (Variant4FTextBox.Text.Trim() == string.Empty)
                        throw new ArgumentException("Введите значение F.");

                    if (Variant4YTextBox.Text.Trim() == string.Empty)
                        throw new ArgumentException("Введите значение Y.");

                    int n = int.Parse(Variant4NTextBox.Text.Trim());
                    int k = int.Parse(Variant4KTextBox.Text.Trim());
                    double x = double.Parse(Variant4XTextBox.Text.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture);
                    double f = double.Parse(Variant4FTextBox.Text.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture);
                    double y = double.Parse(Variant4YTextBox.Text.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture);

                    if (n <= 0)
                        throw new ArgumentException("Значение N должно быть больше 0.");

                    if (k <= 0)
                        throw new ArgumentException("Значение K должно быть больше 0.");

                    if (double.IsNaN(x) || double.IsInfinity(x) ||
                        double.IsNaN(f) || double.IsInfinity(f) ||
                        double.IsNaN(y) || double.IsInfinity(y))
                        throw new ArgumentException("X, F и Y должны быть конечными числами.");

                    formula = new Variant4Formula(n, k, x, f, y);
                }
                else
                {
                    throw new ArgumentException("Выберите формулу для расчёта.");
                }

                double result = formula.Calculate();

                if (double.IsNaN(result) || double.IsInfinity(result))
                    throw new ArithmeticException("Получен некорректный результат вычисления.");

                ResultTextBlock.Text = "Результат: " + result.ToString("G10");
            }
            catch (FormatException)
            {
                ResultTextBlock.Text = "Ошибка: введено некорректное число.";
            }
            catch (OverflowException)
            {
                ResultTextBlock.Text = "Ошибка: введённое число выходит за допустимый диапазон.";
            }
            catch (ArgumentException ex)
            {
                ResultTextBlock.Text = "Ошибка: " + ex.Message;
            }
            catch (ArithmeticException ex)
            {
                ResultTextBlock.Text = "Ошибка: " + ex.Message;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            bool integerField =
                textBox == Formula4DTextBox ||
                textBox == Variant4NTextBox ||
                textBox == Variant4KTextBox;

            string currentText = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength);

            foreach (char symbol in e.Text)
            {
                if (char.IsDigit(symbol))
                    continue;

                if (!integerField && (symbol == ',' || symbol == '.'))
                {
                    if (!currentText.Contains(",") && !currentText.Contains("."))
                        continue;
                }

                if (!integerField && symbol == '-')
                {
                    if (textBox.SelectionStart == 0 && !currentText.Contains("-"))
                        continue;
                }

                e.Handled = true;
                return;
            }

            e.Handled = false;
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text = string.Empty;

            try
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text.Trim();

                if (text == string.Empty)
                    throw new ArgumentException("Поле не должно быть пустым.");

                if (textBox == Formula4DTextBox)
                {
                    int value = int.Parse(text);

                    if (value < 0)
                        throw new ArgumentException("Значение D не может быть меньше 0.");
                }
                else if (textBox == Variant4NTextBox)
                {
                    int value = int.Parse(text);

                    if (value <= 0)
                        throw new ArgumentException("Значение N должно быть больше 0.");
                }
                else if (textBox == Variant4KTextBox)
                {
                    int value = int.Parse(text);

                    if (value <= 0)
                        throw new ArgumentException("Значение K должно быть больше 0.");
                }
                else
                {
                    double value = double.Parse(text.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture);

                    if (double.IsNaN(value) || double.IsInfinity(value))
                        throw new ArgumentException("Введите конечное число.");
                }
            }
            catch (FormatException)
            {
                ResultTextBlock.Text = "Ошибка: введено некорректное число.";
            }
            catch (OverflowException)
            {
                ResultTextBlock.Text = "Ошибка: число выходит за допустимый диапазон.";
            }
            catch (ArgumentException ex)
            {
                ResultTextBlock.Text = "Ошибка: " + ex.Message;
            }
        }

        private void FormulaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Formula1InputGrid.IsEnabled = Formula1RadioButton.IsChecked == true;
            Formula2InputGrid.IsEnabled = Formula2RadioButton.IsChecked == true;
            Formula3InputGrid.IsEnabled = Formula3RadioButton.IsChecked == true;
            Formula4InputGrid.IsEnabled = Formula4RadioButton.IsChecked == true;
            Variant4InputGrid.IsEnabled = Variant4RadioButton.IsChecked == true;

            Formula1InputGrid.Opacity = Formula1InputGrid.IsEnabled ? 1 : 0.4;
            Formula2InputGrid.Opacity = Formula2InputGrid.IsEnabled ? 1 : 0.4;
            Formula3InputGrid.Opacity = Formula3InputGrid.IsEnabled ? 1 : 0.4;
            Formula4InputGrid.Opacity = Formula4InputGrid.IsEnabled ? 1 : 0.4;
            Variant4InputGrid.Opacity = Variant4InputGrid.IsEnabled ? 1 : 0.4;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Formula3BTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}