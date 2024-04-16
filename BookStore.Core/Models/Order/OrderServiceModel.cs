using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Order
{
    public class OrderServiceModel
    {
        public string Buyer { get; set; } = string.Empty;
        public string Book { get; set; } = string.Empty;
    }
}
