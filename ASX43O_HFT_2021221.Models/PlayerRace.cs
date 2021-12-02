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
    [Table("races")]
    public class PlayerRace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("race_id", TypeName = "int")]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<PlayerClass> Classes { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<PlayerCharacter> Characters { get; set; }


        public PlayerRace() : this("Unknown") { }
        public PlayerRace(string name)
        {
            Name = name;
            Characters = new HashSet<PlayerCharacter>();
            Classes = new HashSet<PlayerClass>();
        }
    }
}
