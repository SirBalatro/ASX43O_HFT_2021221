using ASX43O_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASX43O_HFT_2021221.Repository;

namespace ASX43O_HFT_2021221.Logic
{
    public class PlayerClassLogic : IPlayerClassLogic
    {
        IClassRepository repo;
        public PlayerClassLogic(IClassRepository repo)
        {
            this.repo = repo;
        }

        public void Create(PlayerClass entity)
        {
            if ( entity.Name != null && entity.Name != "")
            {
                repo.Create(entity);
            }
            else
            {
                throw new ArgumentException("Class creation failed, name invalid");
            }
        }

        public void Delete(PlayerClass entity)
        {
            if (repo.GetAll().Contains(entity))
            {
                repo.Delete(entity);
            }
            else
            {
                throw new Exception("Given class doesn't exist");
            }
        }

        public void Delete(int id)
        {
            if (repo.GetAll().Any(x => x.Id.Equals(id)))
            {
                repo.Delete(id);
            }
            else
            {
                throw new Exception("Given class id doesn't exist");
            }
        }

        public IEnumerable<PlayerClass> GetAll()
        {
            return repo.GetAll();
        }

        public PlayerClass GetOne(int id)
        {
            return repo.GetOne(id);
        }

        public void Update(PlayerClass entity)
        {
            if (entity.Id > 0 && entity.Name != null && entity.Name != "")
            {
                repo.Update(entity);
            }
            else
            {
                throw new ArgumentException("Class update failed, id or name invalid");
            }
        }
    }
}
