using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Models
{
    [Table("characters")]
    public class PlayerCharacter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("character_id", TypeName = "int")]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [ForeignKey(nameof(Race))]
        public int RaceId { get; set; }
        [NotMapped]
        public virtual PlayerRace Race { get; set; }

        [ForeignKey(nameof(Class))]
        public int ClassId { get; set; }
        [NotMapped]
        public virtual PlayerClass Class { get; set; }

        public int CharacterLevel { get; set; }

        /*
        [NotMapped]
        public virtual ICollection<PlayerSkill> Skills { get; set; }
        */

        [NotMapped]
        public virtual ICollection<PlayerItem> Items { get; set; }

        public PlayerCharacter()
        {
            //Skills = new HashSet<PlayerSkill>();
            Items = new HashSet<PlayerItem>();
            CharacterLevel = 0;
        }

    }
}
