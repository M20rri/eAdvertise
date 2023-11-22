using eAdvertise.Domain.Common;
using System;
using System.Collections.Generic;

namespace eAdvertise.Domain.Entities
{
    public abstract class Advertise : AuditableBaseEntity
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public List<Image> Images { get; set; }
        public bool IsPremium { get; set; }

        public Advertise Create(string createdBy, DateTime created)
        {
            Created = created;
            CreatedBy = createdBy;
            return this;
        }
    }
}
