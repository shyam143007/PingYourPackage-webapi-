﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PingYourPackage.Domain.Models
{
    public class Shipment : IEntity
    {
        [Key]
        public Guid Key { get; set; }

        public Guid AffiliateKey { get; set; }
        public Guid ShipmentKey { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiverName { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiverSurName { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiverAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiverZipCode { get; set; }
        [Required]

        [StringLength(50)]
        public string ReceiverCity { get; set; }
        [Required]

        [StringLength(50)]
        public string ReceiverCountry { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiverTelephoneNumber { get; set; }

        [Required]
        [StringLength(320)]
        public string ReceiverEmail { get; set; }

        public DateTime CreatedOn { get; set; }

        public Affiliate Affiliate { get; set; }

        public ShipmentType ShipmentType { get; set; }

        public virtual ICollection<ShipmentState> ShipmentStates { get; set; }

        public Shipment()
        {
            ShipmentStates = new HashSet<ShipmentState>();
        }
    }
}