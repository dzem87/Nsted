    using System;
    using Microsoft.AspNetCore.Identity;
        
    //Interface som 

    namespace Nsted.Interfaces
    {
        public interface IUserRepository
        {
            Task<IEnumerable<IdentityUser>> GetAll();
        }
    }


