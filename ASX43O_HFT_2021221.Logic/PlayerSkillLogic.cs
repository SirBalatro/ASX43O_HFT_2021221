using ASX43O_HFT_2021221.Models;
using ASX43O_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Logic
{
    public class PlayerSkillLogic : IPlayerSkillLogic
    {
        ISkillRepository repo;
        public PlayerSkillLogic(ISkillRepository repo)
        {
            this.repo = repo;
        }
        public void Create(PlayerSkill entity)
        {
            repo.Create(entity);
        }

        public void Delete(PlayerSkill entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IQueryable<PlayerSkill> GetAll()
        {
            return repo.GetAll();
        }

        public PlayerSkill GetOne(int id)
        {
            return repo.GetOne(id);
        }

        public void Update(PlayerSkill entity)
        {
            repo.Update(entity);
        }
    }
}
