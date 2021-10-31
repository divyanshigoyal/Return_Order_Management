using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Billing : BaseEntity
    {
        public ProcessResponse ProcessResponse { get; set; }
        public int ProcessResponseId { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditLimit { get; set; }
    }
}