﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BaseEntity
    {
        [MaxLength(450)]
        public string CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        [MaxLength(450)]
        public string? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
    }
}
