using ASX43O_HFT_2021221.Models;
using System.Linq;

namespace ASX43O_HFT_2021221.Repository
{
    public interface IClassRepository
    {
        void Create(PlayerClass c);
        void Delete(int id);
        PlayerClass Read(int id);
        IQueryable<PlayerClass> ReadAll();
        void Update(PlayerClass c);
    }
}