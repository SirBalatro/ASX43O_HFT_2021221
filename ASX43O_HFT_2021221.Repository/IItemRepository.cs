using ASX43O_HFT_2021221.Models;
using System.Linq;

namespace ASX43O_HFT_2021221.Repository
{
    public interface IItemRepository : IRepository<PlayerItem>
    {
        void ChangeOwner(int id, PlayerCharacter newOwner);
        void ChangeReqLevel(int id, int lvl);
    }
}