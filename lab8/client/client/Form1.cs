using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace client
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }

    public partial class Form1 : Form
    {
        private const string UrlBase = "http://localhost:8080/";
        private string _jwt;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            const string url = UrlBase + "api/authenticate";
            var username = username_textbox.Text;
            var password = password_textbox.Text;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            var json = $"{{\"username\":\"{username}\",\"password\":\"{password}\"}}";

            using var streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(json);

            var httpResponse = (HttpWebResponse)request.GetResponse();
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show("Error");
                return;
            }
            using var streamReader = new StreamReader(httpResponse.GetResponseStream());
            var response = streamReader.ReadToEnd();
            var authResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(response)!;
            _jwt = authResponse.Token;
            jwt_textbox.Text = _jwt;
        }

        private void get_user_count_button_Click(object sender, EventArgs e)
        {
            const string url = UrlBase + "api/users/count";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("Authorization", $"Bearer {_jwt}");
            
            var httpResponse = (HttpWebResponse)request.GetResponse();
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show("Error");
                return;
            }
            using var streamReader = new StreamReader(httpResponse.GetResponseStream());
            var response = streamReader.ReadToEnd();
            get_user_count_res_label.Text = response;
        }

        private void get_random_prime_button_Click(object sender, EventArgs e)
        {
            const string url = UrlBase + "api/random";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("Authorization", $"Bearer {_jwt}");

            var httpResponse = (HttpWebResponse)request.GetResponse();
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show("Error");
                return;
            }
            using var streamReader = new StreamReader(httpResponse.GetResponseStream());
            var response = streamReader.ReadToEnd();
            get_random_prime_res_label.Text = response;
        }

        private void get_users_button_Click(object sender, EventArgs e)
        {
            const string url = UrlBase + "api/user";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("Authorization", $"Bearer {_jwt}");

            var httpResponse = (HttpWebResponse)request.GetResponse();
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show("Error");
                return;
            }

            using var streamReader = new StreamReader(httpResponse.GetResponseStream());
            var response = streamReader.ReadToEnd();
            get_users_res_textbox.Text = response;
        }
    }
}