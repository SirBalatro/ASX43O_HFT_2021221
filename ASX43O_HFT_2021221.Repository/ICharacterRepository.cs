using ASX43O_HFT_2021221.Models;
using System.Linq;

namespace ASX43O_HFT_2021221.Repository
{
    public interface ICharacterRepository
    {
        void Create(PlayerCharacter player);
        void Delete(int id);
        PlayerCharacter Read(int id);
        IQueryable<PlayerCharacter> ReadAll();
        void Update(PlayerCharacter character);
    }
}