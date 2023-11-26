    using System;
    using Microsoft.AspNetCore.Identity;
        
    // Interface som består av definisjoner som implementeres i SjekklisteRepository

    namespace Nsted.Interfaces
    {
        public interface IUserRepository
        {
            Task<IEnumerable<IdentityUser>> GetAll();
        }
    }


