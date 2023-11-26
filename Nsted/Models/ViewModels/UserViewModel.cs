using System;

//Modellen blir brukt til å overføre data mellom AdminUsersControlleren og List viewet

namespace Nsted.Models.ViewModels
{
	public class UserViewModel
	{
		
		// Liste av brukere som overføres til eller fra viewet.
		public List<User> Users { get; set; }
		
		// Brukernavn til en enkelt bruker.
		public string Username { get; set; }
		
		// E-postadresse til en enkelt bruker.
        public string Email { get; set; }
        
        // Passord til en enkelt bruker.
        public string Password { get; set; }
        
        // Checkbox som indikerer om brukeren har administratortilgang eller ikke.
        public bool AdminRoleCheckbox { get; set; }
    }
}

