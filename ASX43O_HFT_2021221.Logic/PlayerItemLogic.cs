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

        public void Create(PlayerItem entity)
        {
            if (entity.Name != null && entity.Name != "")
            {
                if (entity.ReqLevel !>= 0)
                {
                    entity.ReqLevel = 0;
                }
                itemRepo.Create(entity);
            }
            else
            {
                throw new ArgumentException("Item creation failed, name null or empty");
            }
        }

        public void Delete(PlayerItem entity)
        {
            if (itemRepo.GetAll().Contains(entity))
            {
                itemRepo.Delete(entity);
            }
            else
            {
                throw new Exception("Given item doesn't exist");
            }
        }

        public void Delete(int id)
        {
            if (itemRepo.GetAll().Any(x => x.Id.Equals(id)))
            {
                itemRepo.Delete(id);
            }
            else
            {
                throw new Exception("Given item id doesn't exist");
            }
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
            if (entity.Id > 0 && entity.Name != null && entity.Name != "")
            {
                if (entity.ReqLevel! >= 0)
                {
                    entity.ReqLevel = 0;
                }
                itemRepo.Update(entity);
            }
            else
            {
                throw new ArgumentException("Item update failed, name null or wrong id");
            }
        }
    }
}
