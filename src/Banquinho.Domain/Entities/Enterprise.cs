using System;
using System.Collections.Generic;
using System.Text;

namespace Banquinho.Domain.Entities
{
    public class Enterprise
    {
        public Guid EnterpriseId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
