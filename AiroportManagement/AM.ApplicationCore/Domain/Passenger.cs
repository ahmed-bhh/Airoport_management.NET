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
        [MinLength(3, ErrorMessage = "3 caractere minimum")]
        [MaxLength(25, ErrorMessage = "25 caractere maximum")]



        public string FirstName { get; set; }

        public string LastName { get; set;}
        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAdress {  get; set; }
        [RegularExpression("@[1-9]{8}")]
        public string PhoneNumber { get; set; }

        public List<Flight> Flights { get; set; }
    }
}
