using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Models
{
    public class ItemsByRaceResult
    {
        public PlayerRace Race { get; set; }
        public IEnumerable<PlayerItem> Items { get; set; }

        public ItemsByRaceResult(PlayerRace race, IEnumerable<PlayerItem> items)
        {
            this.Race = race;
            this.Items = items;
        }
    }
}
