using Ordering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stroopwafels.Models
{
    public class OrderDetailsViewModel
    {
        [Required]
        [Display(Name = "Naam")]
        public string Naam { get; set; }

        [Required]
        [Display(Name = "Delivery Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DeliveryDate { get; set; }

        public IList<OrderRow> OrderRows { get; set; }

        public OrderDetailsViewModel()
        {
            this.OrderRows = new List<OrderRow>
            {
                new OrderRow(0, StroopwafelType.Gewoon),
                new OrderRow(0, StroopwafelType.Suikervrij),
                new OrderRow(0, StroopwafelType.Super)
            };
        }
    }
}