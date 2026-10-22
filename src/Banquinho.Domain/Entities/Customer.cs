using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Banquinho.Domain.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; } = Guid.NewGuid();
        public required string FullName { get; set; }
        public required string CPF { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LastLoginAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public ICollection<Account> Accounts { get; set; } = new List<Account>();

        // Empresas (PJ) das quais este cliente é o representante legal
        public ICollection<Enterprise> RepresentedEnterprises { get; set; } = new List<Enterprise>();


    }
}
