using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        // public int Id { get; set; }
        [Key]
        [StringLength(7)] //Contraint
        public string PassportNumber { get; set; }

        [StringLength(100)]
        public string Photo {  get; set;}

        public FullName FullName { get; set; } //hedhi naamloha bech nadhmou el code firstname w lastname hatinehom maa baadhhom


        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAdress {  get; set; }
        [RegularExpression("@[1-9]{8}")]
        public string PhoneNumber { get; set; }

       // public List<Flight> Flights { get; set; }// hedhi nahineha akhater snaana ahna el relation b class samineha Ticket

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
