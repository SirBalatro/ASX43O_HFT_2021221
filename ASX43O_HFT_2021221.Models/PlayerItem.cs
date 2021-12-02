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
    [Table("inventory")]
    public class PlayerItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("item_id",TypeName ="int")]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }

        public int ReqLevel { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual PlayerCharacter Owner { get; set; }

        public PlayerItem()
        {
            ReqLevel = 0;
        }

    }
}
