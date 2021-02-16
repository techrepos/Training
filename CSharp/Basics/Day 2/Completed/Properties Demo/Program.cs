using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
			var obj = new PropertyDemo();

			obj.FirstName = "Amal";
			obj.LastName = "Dev";
			obj.EmailAddress = "amal@dev.com";
			obj.Address = "add1";
			
			


        }




    }

    class PropertyDemo
    {
		//read write properties
		private string firstName;
		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		/* Equivalent expression bodied syntax
		 
		public string FirstName
		{
			get => firstName; 
			set => firstName = value; 
		}

		 */
		//read only property
		private string lastName;
		public string LastName
		{
			get { return lastName; }

		}

		//write only property
		private string address;
		public string Address
		{
			set { address = value; }

		}

		//automatic properties
		public string EmailAddress { get; set; } = "test@test.com";

	}
}
