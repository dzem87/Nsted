using Nsted.Models;

namespace Nsted.Repositories

{
    public interface IKundeRepository
    {
        //Hente ut alle kunder
        Task<IEnumerable<Kunde>> GetAllAsync();

        //Get single 
    }
}
