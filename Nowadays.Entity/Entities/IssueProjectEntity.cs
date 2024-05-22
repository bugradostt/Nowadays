using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nowadays.Entity.Entities
{
    public class IssueProjectEntity
    {
        [Key]
        public int Id { get; set; }

        public string IssueId { get; set; }
        public string ProjectId { get; set; }
        
    }
}