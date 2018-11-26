using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace laba2
{
    public partial class AddConnection : Window
    {
        private UserDto _userDto;
        static HttpClient client = new HttpClient();
        public AddConnection(UserDto userDto)
        {
            InitializeComponent();
            _userDto = userDto;
        }
        
        private async void connectButton_Click(object sender, RoutedEventArgs e)
        {
            await RunAsync();
            string patientLogin = this.patientLogin.Text;
            string doctorLogin = this.doctorLogin.Text;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",_userDto.Token);
            PatientDoctor patientDoctor = new PatientDoctor();
            patientDoctor.patientLogin = patientLogin;
            patientDoctor.doctorLogin = doctorLogin;
            Console.WriteLine(patientDoctor.doctorLogin);
            var response = await client.PostAsJsonAsync("api/Doctors/"+doctorLogin, patientDoctor);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Patient was Added");
            }
            else
            {
                MessageBox.Show("Unable to add Patient");
            }
        }
        
        
        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
