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
using System.Security.Cryptography;


namespace CryptoFive
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

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Cypher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Password.Text != "" && DecypherText.Text != "")
                {
                    if (AES.IsChecked == true)
                        CypherText.Text = Crypto.EncryptStringAES(DecypherText.Text, Password.Text);
                    else if (SHA.IsChecked == true)
                        CypherText.Text = SHA_1.Encrypt(DecypherText.Text, Password.Text);
                    else if (Vij.IsChecked == true)
                        CypherText.Text = Vijener.Encrypt(DecypherText.Text, Password.Text);
                }
                else if (Password.Text == "" && DecypherText.Text != "" && RSA.IsChecked == true)
                {
                    CypherText.Text = RSA_Crypt.Encrypt(DecypherText.Text);
                }
                else if (XOR_method.IsChecked == true)
                    CypherText.Text = XOR.EncodeDecrypt(DecypherText.Text, 0x0088);
                else MessageBox.Show("Заполнены не все поля");
            }
            catch (Exception exp)
            {
                MessageBox.Show($"{exp.Message} Невозможно зашифровать");
            }
        }

        private void Decypher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Password.Text != "" && DecypherText.Text != "")
                {
                    if (AES.IsChecked == true)
                        CypherText.Text = Crypto.DecryptStringAES(DecypherText.Text, Password.Text);
                    else if (SHA.IsChecked == true)
                        CypherText.Text = SHA_1.Decrypt(DecypherText.Text, Password.Text);
                    else if (Vij.IsChecked == true)
                        CypherText.Text = Vijener.Decrypt(DecypherText.Text, Password.Text);
                }
                else if (Password.Text == "" && DecypherText.Text != "" && RSA.IsChecked == true)
                {
                    CypherText.Text = RSA_Crypt.Decrypt(DecypherText.Text);
                }
                else if (XOR_method.IsChecked == true)
                    CypherText.Text = XOR.EncodeDecrypt(DecypherText.Text, 0x0088);
                else MessageBox.Show("Заполнены не все поля");
            }
            catch (Exception exp)
            {
                MessageBox.Show($"Невозможно расшифровать");
            }
        }

        private void LeftClear_Click(object sender, RoutedEventArgs e)
        {
            DecypherText.Clear();
        }

        private void PasswordClear_Click(object sender, RoutedEventArgs e)
        {
            Password.Clear();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(CypherText.Text);
        }

        private void RightClear_Click(object sender, RoutedEventArgs e)
        {
            CypherText.Clear();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Swap_Click(object sender, RoutedEventArgs e)
        {
            if (CypherText.Text != "")
            {
                DecypherText.Text = CypherText.Text;
                CypherText.Clear();
            }
        }

        private void RSA_Checked(object sender, RoutedEventArgs e)
        {
            Password.Clear();
            Password.IsEnabled = false;
        }

        private void RSA_Unchecked(object sender, RoutedEventArgs e)
        {
            Password.IsEnabled = true;
        }

    }
}
