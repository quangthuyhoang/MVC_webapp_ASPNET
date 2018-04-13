using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Destination
    {
        public int ID { get; set; }
        public string Location { get; set; }
        [Display(Name = "Visit Date")]
        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
        public string Description { get; set; }
        [Display(Name = "Excursion Cost")]
        [DataType(DataType.Currency)]
        public decimal ExcursionCost { get; set; }
    }
}
