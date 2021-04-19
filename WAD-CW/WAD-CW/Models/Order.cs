using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_CW.Models
{
    public class Order : IValidatableObject
    {
        //[Required]
        //[MinLength(3)]
        //[DisplayName("Order Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Order Received at:")]
        public DateTime OrderGetTime { get; set; }

        [Required]
        [MinLength(2)]
        [DisplayName("Receiver Name")]
        public string ClientName {get; set;}

        [Required]
        [Phone]
        [DisplayName("Receiver Phone")]
        public string ClientPhone { get; set; }

        [Required]
        [MinLength(2)]
        [DisplayName("Receiver Address")]
        public string ClientAddress { get; set; }

        [Required]
        [DisplayName("Parcel Priority")]
        public Priority Priority { get; set; }

        [DisplayName("Parcel Weight (killograms):")]
        public string Weight { get; set; }

        public int? CourierId { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateTime.Now.AddYears(1) <= OrderGetTime)
            {
                yield return new ValidationResult("Incorrect date was choosen", new[] { "OrderGetTime" });
            } 
        }

        public virtual Courier Courier { get; set; }
    }

    public enum Priority
    {
        High,
        Medium,
        Low
    }
}
