using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nowadays.Entity.Entities
{
    public class EmployeeProjectEntity
    {
        [Key]
        public int Id { get; set; }

        public string EmployeeId { get; set; }
       // [ForeignKey("EmployeeId")]
        //public EmployeeEntity Employee { get; set; }

        public string ProjectId { get; set; }
        //[ForeignKey("ProjectId")]
        //public ProjectEntity Project { get; set; }
    }
}