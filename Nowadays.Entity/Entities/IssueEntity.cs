using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nowadays.Entity.Entities
{
    public class IssueEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "nvarchar(450)")]
        public string IssueId { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string  Detail { get; set; }
        public string ProjectId { get; set; } 
        [ForeignKey("ProjectId")]
        public virtual ProjectEntity Project { get; set; }        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Invalidated { get; set; }
    }
}