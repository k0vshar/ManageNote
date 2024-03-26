﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageNote.Domain.Entity
{
    public class Note
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime TimeCreated { get; set; }
    }
}