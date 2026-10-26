namespace Banquinho.Domain.Entities
{
    public class Enterprise
    {
        public Guid EnterpriseId { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string CNPJ { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Representante legal (PF) — é quem faz login e opera a empresa
        public Guid LegalRepresentativeId { get; set; }
        public Customer? LegalRepresentative { get; set; }


        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
