using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entities
{
    [Table("Tasks")]
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
                
        public int ParentTaskId { get; set; }

        [ForeignKey("ParentTaskId")]
        public virtual ParentTask ParentTask { get; set; }
        
        public string TaskName { get; set; }
        public int Priority { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        public string Status { get; set; }
    }
}
