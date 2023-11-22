using eAdvertise.Domain.Common;
using System;

namespace eAdvertise.Domain.Entities
{
    public class Image : AuditableBaseEntity
    {
        public string ImageUrl { get; set; }
        public Guid AdvertiseId { get; set; }
        public Advertise Advertise { get; set; }

        public Image Create(Guid advertiseId, string createdBy, DateTime created)
        {
            AdvertiseId = advertiseId;
            Created = created;
            CreatedBy = createdBy;
            return this;
        }
    }
}
