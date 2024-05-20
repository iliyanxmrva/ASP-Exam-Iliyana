using Microsoft.AspNetCore.Identity;

namespace asp_exam_iliyana.Models
{
    public class User : IdentityUser
    {
		private string _firstName;
		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}

		private string _lastName;
		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}

		private string _address;
		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}

		private string _phoneNumber;
		public string PhoneNumber
		{
			get { return _phoneNumber; }
			set { _phoneNumber = value; }
		}

        public User() { }

        public User(string email, string firstname, string lastname, string address, string phoneNumber)
        {
			UserName = email;
            Email = email;
            FirstName = firstname;
            LastName = lastname;
            Address = address;
			PhoneNumber = phoneNumber;
        }

        internal void UpdateProfileDetails(string firstName, string lastName, string address, string phoneNumber, string email = "")
        {
            FirstName = firstName;
            LastName = lastName;
			Address = address;
			PhoneNumber = phoneNumber;

            if (!String.IsNullOrEmpty(email))
            {
                Email = email;
            }
        }

    }
}
