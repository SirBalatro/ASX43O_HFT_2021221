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
            repo.Create(entity);
        }

        public void Delete(PlayerClass entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
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
            repo.Update(entity);
        }
    }
}
