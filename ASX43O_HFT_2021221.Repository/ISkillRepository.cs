using ASX43O_HFT_2021221.Models;
using System.Linq;

namespace ASX43O_HFT_2021221.Repository
{
    public interface ISkillRepository
    {
        void Create(PlayerSkill s);
        void Delete(int id);
        PlayerSkill Read(int id);
        IQueryable<PlayerSkill> ReadAll();
        void Update(PlayerSkill s);
    }
}