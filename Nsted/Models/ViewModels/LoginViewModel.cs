using System;
namespace Nsted.Models.ViewModels

	//Model som som spesifiserer data som er nøvendig for en bruker for å logge inn
	//Modellen blir brukt i Login viewet og Login metoden i AccountControlleren
{
	public class LoginViewModel
	{
		// Egenskap som representerer brukernavn for innlogging.
		public string Username { get; set; }

		// Egenskap som representerer passordet for innlogging.
		public string Password { get; set; }

	}
}

