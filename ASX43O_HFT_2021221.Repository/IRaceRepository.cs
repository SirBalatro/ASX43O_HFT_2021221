using ASX43O_HFT_2021221.Models;
using System.Linq;

namespace ASX43O_HFT_2021221.Repository
{
    interface IRaceRepository
    {
        void Create(PlayerRace race);
        void Delete(int id);
        PlayerRace Read(int id);
        IQueryable<PlayerRace> ReadAll();
        void Update(PlayerRace race);
    }
}