using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Models
{
    [Table("classes")]
    public class PlayerClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("class_id", TypeName = "int")]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<PlayerRace> Races { get; set; }

        /*
        [NotMapped]
        public virtual ICollection<PlayerSkill> Skills { get; set; }
        */

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<PlayerCharacter> Characters { get; set; }


        public PlayerClass() : this("Unknown") { }
        public PlayerClass(string name)
        {
            Name = name;
            Characters = new HashSet<PlayerCharacter>();
            //Skills = new HashSet<PlayerSkill>();
            Races = new HashSet<PlayerRace>();
        }
    }
}
