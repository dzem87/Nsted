using System;
namespace Nsted.Models.ViewModels
{
    //Model som blir brukt i UserViewModel

	public class User
	{
        // Unik ID for brukeren.
        public Guid Id { get; set; }
        
        // Brukernavn for brukeren.
        public string Username { get; set; }
        
        // E-postadresse knyttet til brukeren.
        public string Email { get; set; }
    }
}

