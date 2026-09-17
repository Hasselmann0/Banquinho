using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Banquinho.Domain.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string? CNPJ { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public ICollection<Account> Accounts { get; set; } = new List<Account>();


    }
}
