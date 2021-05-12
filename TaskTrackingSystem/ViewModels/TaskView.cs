﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackingSystem.ViewModels
{
    public class TaskView
    {
        [Required]
        public string TaskName { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public BLL.Enums.StatusDTO Status { get; set; }
        public string Description { get; set; }
    }
}
