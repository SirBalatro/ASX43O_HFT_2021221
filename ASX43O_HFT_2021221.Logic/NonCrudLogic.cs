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
        public IEnumerable<PlayerClass> UsedClasses()
        {
            var q = from c in classRepo.GetAll()
                    join ch in charRepo.GetAll() on c.Id equals ch.ClassId
                    select c;
            return q;
        }

        public IEnumerable<ItemsByRaceResult> ItemsByRace()
        {
            var q = from r in raceRepo.GetAll()
                    join ch in charRepo.GetAll() on r.Id equals ch.RaceId
                    join i in itemRepo.GetAll() on ch.Id equals i.OwnerId
                    group i by new {r, ch.Items} into grp
                    select new ItemsByRaceResult(grp.Key.r,grp.Key.Items);
            return q.ToList();
        }


    }
}
