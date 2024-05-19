using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nowadays.Entity.Entities
{
    public class ProjectEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "nvarchar(450)")]
        public string ProjectId { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual CompanyEntity Company { get; set; }        
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Invalidated { get; set; }
    }
}