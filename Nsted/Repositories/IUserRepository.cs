using System;
using Microsoft.AspNetCore.Identity;

namespace Nsted.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<IdentityUser>> GetAll();
	}
}


