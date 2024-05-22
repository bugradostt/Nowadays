using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nowadays.Entity.Entities
{
    public class EmployeeIssueEntity
    {
        [Key]
        public int Id { get; set; }

        public string EmployeeId { get; set; }
        public string IssueId { get; set; }

    }
}