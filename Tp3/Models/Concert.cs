

using System.ComponentModel.DataAnnotations;

namespace Tp3.Models
{
    public class Concerts
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Type is required.")]
        public string Type { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        public Concerts(int id, string name, string type, DateTime date)
        {
            Id = id;
            Name = name;
            Type = type;
            Date = date;
        }

        public Concerts()
        {
        }
    }

}
    

    

