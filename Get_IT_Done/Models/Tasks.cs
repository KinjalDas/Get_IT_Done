﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Get_IT_Done.Models
{
    public class Tasks
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastModified { get; set; }
    }
}