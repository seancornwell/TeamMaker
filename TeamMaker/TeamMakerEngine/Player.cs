using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMakerEngine
{
	public class Player
	{
		public Player( string firstName, string lastName, string address, string city, string zip, string state, string dob, string ageGroup, string allStar, string schoolName, string grade, string medical, string specialRequests, string buddyRequest1, string buddyRequest2, string headCoachRequest, string volunteersNeeded )
		{
			FirstName = firstName;
			LastName = lastName;
			Address = address;
			City = city;
			Zip = zip;
			State = state;
			Dob = dob;
			AgeGroup = ageGroup;
			AllStar = allStar;
			SchoolName = schoolName;
			Grade = grade;
			Medical = medical;
			SpecialRequests = specialRequests;
			BuddyRequest1 = buddyRequest1;
			BuddyRequest2 = buddyRequest2;
			HeadCoachRequest = headCoachRequest;
			VolunteersNeeded = volunteersNeeded;
		}

        public string FullName => FirstName + " " + LastName;
		public string FirstName { get; }
		public string LastName { get; }
		public string Address { get; }
		public string City { get; }
		public string Zip { get; }
		public string State { get; }
		public string Dob { get; }
		public string AgeGroup { get; }
		public string AllStar { get; }
		public string SchoolName { get; }
		public string Grade { get; }
		public string Medical { get; }
		public string SpecialRequests { get; }
		public string BuddyRequest1 { get; }
		public string BuddyRequest2 { get; }
		public string HeadCoachRequest { get; }
		public string VolunteersNeeded { get; }
		// TODO: Convert DOB to Age
		public int Age { get; set; }
		// TODO: Convert AllStar to IsAllStar
		public bool IsAllStar { get; set; }

	}
}
