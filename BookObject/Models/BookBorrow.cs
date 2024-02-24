using System;
using System.Collections.Generic;

namespace BookObject.Models
{
    public partial class BookBorrow
    {
        public string BookBorrowId { get; set; }
        public string BookId { get; set; }
        public string MemberId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual BookManagementMember Member { get; set; } = null!;
    }
}
