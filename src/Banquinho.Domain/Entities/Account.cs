using System;
using System.Collections.Generic;
using System.Text;

namespace Banquinho.Domain.Entities
{
    public class Account
    {
        public Guid AccountId { get; set; }

        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool Status { get; set; } = true;



        public Customer? customer { get; set; }
        public Guid? CustomerId { get; set; } 

        public Enterprise? enterprise { get; set; }
        public Guid? EnterpriseId { get; set; }
        



    }
}
