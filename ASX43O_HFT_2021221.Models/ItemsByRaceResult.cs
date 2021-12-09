using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Models
{
    public class ItemsByRaceResult
    {
        public PlayerRace race { get; set; }
        public IEnumerable<PlayerItem> items { get; set; }

        public ItemsByRaceResult(PlayerRace race, IEnumerable<PlayerItem> items)
        {
            this.race = race;
            this.items = items;
        }
    }
}
