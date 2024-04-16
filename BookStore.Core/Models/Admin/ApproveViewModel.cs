using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Admin
{
    public class ApproveViewModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; } = string.Empty;

        public string BookDescription { get; set; } = string.Empty;
    }
}
