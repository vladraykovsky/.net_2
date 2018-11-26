namespace laba2
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }

    public class PatientDoctor
    {
        public string doctorLogin { get; set;  }
        public string patientLogin { get; set;  }
    }
    
}