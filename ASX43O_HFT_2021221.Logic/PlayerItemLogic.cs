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

        public PlayerItem BestItem()
        {
            return (from i in itemRepo.GetAll()
                     orderby i.ReqLevel
                     select i).FirstOrDefault();
        }

        public void ChangeOwner(int id, PlayerCharacter newOwner)
        {
            itemRepo.ChangeOwner(id, newOwner);
        }

        public void ChangeReqLevel(int id, int lvl)
        {
            if (lvl >= 0)
            {
                itemRepo.ChangeReqLevel(id, lvl);
            }
            else
            {
                itemRepo.ChangeReqLevel(id, 0);
            }
        }

        public void Create(PlayerItem entity)
        {
            if (entity.Id > 0 && entity.Name != null && entity.Name != "" && entity.ReqLevel >= 0)
            {
                itemRepo.Create(entity);
            }
            else
            {
                throw new ArgumentException("Item creation failed, invalid req. level, name null or wrong id");
            }
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
            if (entity.Id > 0 && entity.Name != null && entity.Name != "" && entity.ReqLevel >= 0)
            {
                itemRepo.Update(entity);
            }
            else
            {
                throw new ArgumentException("Item update failed, invalid req. level, name null or wrong id");
            }
        }
    }
}
