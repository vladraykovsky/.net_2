using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace laba2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        static HttpClient client = new HttpClient();

        
        public MainWindow()
        {
            InitializeComponent();
           
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        static async Task<UserDto> LogIn(LoginPassword loginUser)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "authenticate/doctor", loginUser);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            var user = await response.Content.ReadAsAsync<UserDto>();
            return user;
        }

        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            await RunAsync();
            LoginPassword loginPassword = new LoginPassword();
            loginPassword.Login = this.textBoxEmail.Text;
            loginPassword.Password = this.passwordBox1.Password;
            UserDto userDto = await LogIn(loginPassword);
            AddConnection addConnection = new AddConnection(userDto);
            addConnection.Show();

        }
        
    }
}