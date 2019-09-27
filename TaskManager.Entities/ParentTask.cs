using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entities
{
    [Table("ParentTask")]
    public class ParentTask
    {
        [Key]
        public int ParentTaskId { get; set; }
        public string ParentTaskName { get; set; }
    }
}
