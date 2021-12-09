using ASX43O_HFT_2021221.Models;
using System.Collections.Generic;

namespace ASX43O_HFT_2021221.Logic
{
    public interface INonCrudLogic
    {
        PlayerCharacter CharacterWithBestItem();
        PlayerCharacter CharacterWithItem(int ItemId);
        IEnumerable<PlayerItem> ItemsUsedByClass(int ClassId);
        IEnumerable<ItemsByRaceResult> ItemsByRace();
        IEnumerable<PlayerClass> UsedClasses();
    }
}