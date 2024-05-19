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
        public string Name { get; set; }

    }
}