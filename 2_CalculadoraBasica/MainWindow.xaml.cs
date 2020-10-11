using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace _2_CalculadoraBasica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void operadorTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            calcularButton.IsEnabled = Regex.IsMatch((sender as TextBox).Text, @"^(\+|-|\*|/)$");
        }

        private void calcularButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double operando1 = double.Parse(operando1TextBox.Text);
                double operando2 = double.Parse(operando2TextBox.Text);

                double resultado;
                switch (operadorTextBox.Text)
                {
                    case "+":
                        resultado = operando1 + operando2;
                        break;
                    case "-":
                        resultado = operando1 - operando2;
                        break;
                    case "*":
                        resultado = operando1 * operando2;
                        break;
                    case "/":
                        resultado = operando1 / operando2;
                        break;
                    default:
                        resultado = 0;
                        break;
                }

                resultadoTextBox.Text = $"{resultado}";
            }catch(Exception exception)
            {
                MessageBox.Show(exception.Message, principalWindow.Title);
            }
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            operando1TextBox.Text = "";
            operando2TextBox.Text = "";
            operadorTextBox.Text = "";
            resultadoTextBox.Text = "";
        }
    }
}
