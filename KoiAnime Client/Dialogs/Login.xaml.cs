using KoiAnime_Client.UserLibs;
using MahApps.Metro.Controls;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KoiAnime_Client.Dialogs
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        RestClient client = new RestClient("http://localhost:5550/");
        public Login()
        {
            InitializeComponent();
        }

        public string Encrypt(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var request = new RestRequest("{id}", Method.GET);
            request.AddParameter("username", UserNameText.Text);
            request.AddUrlSegment("id", "getUser");
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            User u = JsonConvert.DeserializeObject<User>(content);

            if (u.password == Encrypt(UserPasswordText.Password))
            {
                MessageBox.Show("Info","Well Done!");
            }
        }

        private async void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(UserEmailTextBox.Text);

            if (UserPasswordTextBox.Password != ConfirmUserPasswordTextBox.Password || ConfirmUserPasswordTextBox.Password != UserPasswordTextBox.Password)
            {
                await MetroDialog.MessageBoxAsync(this, "Info", "Password is not correct");
            }
            else
            {
                if (!match.Success)
                {
                    await MetroDialog.MessageBoxAsync(this, "Info", "Email is not correct");
                }
                else
                {
                    var request = new RestRequest("{id}", Method.GET);
                    request.AddParameter("username", UsernameTextBox.Text);
                    request.AddParameter("password", Encrypt(UserPasswordTextBox.Password));
                    request.AddParameter("email", UserEmailTextBox.Text);
                    request.AddUrlSegment("id", "createUser");
                    IRestResponse response = client.Execute(request);
                    var content = response.Content;
                    MainWindow m = new MainWindow();
                    m.Show();
                    this.Close();
                }
            }
        }
    }
}
