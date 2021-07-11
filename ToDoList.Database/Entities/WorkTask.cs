using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Database
{
   public class WorkTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
