using System;
namespace Nsted.Models.ViewModels

	//Model som som spesifiserer data som er nøvendig en bruker for å logge inn
	//Modellen blir brukt i Login viewet og Login metoden i AccountControlleren
{
	public class LoginViewModel
	{
		public string Username { get; set; }

		public string Password { get; set; }

	}
}

