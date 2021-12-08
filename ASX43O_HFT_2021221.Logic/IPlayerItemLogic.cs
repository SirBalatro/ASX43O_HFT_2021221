using ASX43O_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Logic
{
    public interface IPlayerItemLogic : ILogic<PlayerItem>
    {
        void ChangeReqLevel(int id, int lvl);
        void ChangeOwner(int id, PlayerCharacter newOwner);
        PlayerItem BestItem();
    }
}
