using Banquinho.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banquinho.Domain.Entities
{
    public class Account
    {
        public Guid AccountId { get; set; } = Guid.NewGuid();
        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public AccountType AccountType { get; set; }
        public decimal Balance { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool Status { get; set; } = true;


        public Customer? Customer { get; set; }
        public Guid? CustomerId { get; set; } 

        public Enterprise? Enterprise { get; set; }
        public Guid? EnterpriseId { get; set; }



    }
}
