
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment2.Models
{
    public class Client
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]

        public DateTime BirthDate { get; set; }

        public string FullName
        {
            get
            {
                return LastName + "," + FirstName;
            }
        }

        public ICollection<Subscription> Subscriptions { get; set; }

    }
}
