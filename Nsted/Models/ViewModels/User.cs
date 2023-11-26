using System;
namespace Nsted.Models.ViewModels
{
    //Model som blir brukt i UserViewModel

	public class User
	{
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}

