using ASX43O_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;

namespace ASX43O_HFT_2021221.Logic
{
    public interface IPlayerCharacterLogic : ILogic<PlayerCharacter>
    {
        void LevelUp(int id);
        void ChangeName(int id, string name);
        double LevelAverage();
    }
}