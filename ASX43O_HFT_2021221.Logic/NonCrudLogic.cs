using ASX43O_HFT_2021221.Models;
using ASX43O_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Logic
{
    public class NonCrudLogic : INonCrudLogic
    {

        private ICharacterRepository charRepo;
        private IRaceRepository raceRepo;
        private IClassRepository classRepo;
        private IItemRepository itemRepo;

        public NonCrudLogic(ICharacterRepository charRepo, IRaceRepository raceRepo, IClassRepository classRepo, IItemRepository itemRepo)
        {
            this.charRepo = charRepo;
            this.raceRepo = raceRepo;
            this.classRepo = classRepo;
            this.itemRepo = itemRepo;
        }

        public PlayerCharacter CharacterWithBestItem()
        {
            var q = (from x in charRepo.GetAll()
                     join y in itemRepo.GetAll() on x.Id equals y.OwnerId
                     orderby y.ReqLevel descending
                     select x).FirstOrDefault();
            return q;
        }
        public PlayerCharacter CharacterWithItem(int ItemId)
        {
            var q = (from c in charRepo.GetAll()
                     join i in itemRepo.GetAll() on c.Id equals i.OwnerId
                     where i.Id.Equals(ItemId)
                     select c).FirstOrDefault();
            return q;
        }
        public IEnumerable<PlayerItem> ItemsUsedByClass(int ClassId)
        {
            var q = from character in charRepo.GetAll()
                    join item in itemRepo.GetAll() on character.Id equals item.OwnerId
                    where character.ClassId.Equals(ClassId)
                    select item;
            return q;
        }
        public IEnumerable<PlayerClass> UnusedClasses()
        {
            var q = from cl in classRepo.GetAll()
                    where cl.Characters.Count().Equals(0)
                    select cl;
            return q;
        }
    }
}
