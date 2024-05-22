using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nowadays.Entity.Entities
{
    public class EmployeeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "nvarchar(450)")]
        public string EmployeeId { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual CompanyEntity Company { get; set; }        
        public string TcIdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthYear { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Invalidated { get; set; }
    }
}