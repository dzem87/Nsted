using System;
using Microsoft.AspNetCore.Identity;

namespace Nsted.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}


