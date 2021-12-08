using ASX43O_HFT_2021221.Models;
using ASX43O_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Logic
{
    public class PlayerItemLogic : IPlayerItemLogic
    {
        IItemRepository itemRepo;

        public PlayerItemLogic(IItemRepository itemRepo)
        {
            this.itemRepo = itemRepo;
        }

        public void ChangeOwner(int id, PlayerCharacter newOwner)
        {
            itemRepo.ChangeOwner(id, newOwner);
        }

        public void ChangeReqLevel(int id, int lvl)
        {
            itemRepo.ChangeReqLevel(id, lvl);
        }

        public void Create(PlayerItem entity)
        {
            itemRepo.Create(entity);
        }

        public void Delete(PlayerItem entity)
        {
            itemRepo.Delete(entity);
        }

        public void Delete(int id)
        {
            itemRepo.Delete(id);
        }

        public IEnumerable<PlayerItem> GetAll()
        {
            return itemRepo.GetAll();
        }

        public PlayerItem GetOne(int id)
        {
            return itemRepo.GetOne(id);
        }

        public void Update(PlayerItem entity)
        {
            itemRepo.Update(entity);
        }
    }
}
