using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MyToDoList.Models
{
    public class ToDos
    {
        [Key]
        [Required]
        public string Title { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToDoID { get; set; }
        public bool IsCompleted { get; set; }
        
        public DateTime? CompletedOn { get; set; }

        
        [Display(Name ="Due Date")]
        public DateTime? DueDate { get; set; }

        public string Description { get; set; }
    }
}
