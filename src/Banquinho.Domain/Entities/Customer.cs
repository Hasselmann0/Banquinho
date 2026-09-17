using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Banquinho.Domain.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(150, ErrorMessage = "O nome não pode passar de 150 caracteres.")]
        public string FullName { get; set; }

        [StringLength(11), Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF { get; set; }

        [StringLength(254), Required(ErrorMessage = "O Email é obrigatório.")]
        public string Email { get; set; }
        
        [StringLength(64), Required(ErrorMessage = "A Senha é obrigatória.")]
        public string Password { get; set; }
        
        public string PasswordHash { get; set; }

        [StringLength(14), Required]
        public string? CNPJ { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public ICollection<Account> Accounts { get; set; } = new List<Account>();


    }
}
