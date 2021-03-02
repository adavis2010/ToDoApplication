using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoApplication {
    public class ToDo {

        public int Id { get; set; }
        [StringLength(80), Required]

        public string Description { get; set; }

        public DateTime? Due { get; set; }
        [StringLength(80), Required]

        public string Note { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public override string ToString() {
            return $"{Id,5}| {"Description",-30}| {"Due",6:MMM dd}, {"Category.Name",-30}|";

        }
         
        public static string Header() {
           return $"{"Id",5}| {"Description",-30}| {"Due",6:MMM dd}, {"Category.Name",-30}|"                 
        }



    }
}
