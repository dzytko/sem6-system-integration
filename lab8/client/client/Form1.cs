using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;

namespace client
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }

    public class AuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
    public class Role
    {
        public string Role_{ get; set; }
        public override string ToString()
        {
            return Role_;
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<Role> Roles { get; set; }
        public override string ToString()
        {
            return $"{Username}, Roles: [{string.Join(", ", Roles)}]";;
        }
    }

    public partial class Form1 : Form
    {
        private const string UrlBase = "http://localhost:8080/";
        private readonly HttpClient _httpClient = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private async void login_button_Click(object sender, EventArgs e)
        {
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            const string url = UrlBase + "api/User/authenticate";
            var request = new AuthenticationRequest
            {
                Username = username_textbox.Text,
                Password = password_textbox.Text
            };
            
            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($@"{response.ReasonPhrase}",@"Login failed");
                jwt_textbox.Text = "";
                return;
            }
            
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<AuthenticationResponse>(jsonResponse);
            
            var jwt = responseObject?.Token;
            if (jwt == null)
            {
                jwt_textbox.Text = "";
                return;
            }

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
            jwt_textbox.Text = jwt;
        }

        private async void get_user_count_button_Click(object sender, EventArgs e)
        {
            const string url = UrlBase + "api/User/count";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($@"{response.ReasonPhrase}",@"Failed to get user count");
                get_user_count_res_label.Text = "";
                return;
            }
            
            var jsonResponse = await  response.Content.ReadAsStringAsync();
            var userCount = JsonConvert.DeserializeObject<int>(jsonResponse);
            
            get_user_count_res_label.Text = userCount.ToString();
        }

        private async void get_random_prime_button_Click(object sender, EventArgs e)
        {
            const string url = UrlBase + "api/Random";
            
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($@"{response.ReasonPhrase}",@"Failed to get random prime");
                get_random_prime_res_label.Text = "";
                return;
            }
            
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var randomPrime = JsonConvert.DeserializeObject<int>(jsonResponse);
            
            get_random_prime_res_label.Text = randomPrime.ToString();
        }

        private async  void get_users_button_Click(object sender, EventArgs e)
        {
            const string url = UrlBase + "api/User";
            
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($@"{response.ReasonPhrase}", @"Failed to get users");
                get_users_res_textbox.Text = "";
                return;
            }
            
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            var users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);
            if (users == null)
                return;

            get_users_res_textbox.Text = string.Join("\n", users);
        }
    }
}