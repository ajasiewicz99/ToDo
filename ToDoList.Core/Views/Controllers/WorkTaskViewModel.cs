﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Core
{
    public class WorkTaskViewModel : BaseView
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsSelected { get; set; }
    }
}
