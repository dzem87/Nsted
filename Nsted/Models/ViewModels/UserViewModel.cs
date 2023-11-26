using System;

//Modellen blir brukt til å overføre data mellom AdminUsersControlleren og List viewet

namespace Nsted.Models.ViewModels
{
	public class UserViewModel
	{
		public List<User> Users { get; set; }

		public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AdminRoleCheckbox { get; set; }
    }
}

