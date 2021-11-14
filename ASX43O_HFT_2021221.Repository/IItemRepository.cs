using ASX43O_HFT_2021221.Models;
using System.Linq;

namespace ASX43O_HFT_2021221.Repository
{
    interface IItemRepository
    {
        void Create(PlayerItem i);
        void Delete(int id);
        PlayerItem Read(int id);
        IQueryable<PlayerItem> ReadAll();
        void Update(PlayerItem i);
    }
}