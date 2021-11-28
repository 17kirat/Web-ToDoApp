using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ToDoApp.Models
{
    public class ToDos
    {
        [Key]
        [Required]
        public string Title { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToDoID { get; set; }
        public bool IsDone { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? DueDate { get; set; }

    }
}
