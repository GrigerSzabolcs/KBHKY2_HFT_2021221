using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBHKY2_HFT_2021221.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int BasePrice { get; set; }
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        [NotMapped]
        public virtual Brand Brand { get; set; }
        [NotMapped]
        public virtual ICollection<Owner> Owners { get; set; }
        public Car()
        {
            Owners = new HashSet<Owner>();
        }

    }
}
