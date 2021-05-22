using System;

namespace AppBuku.Models
{
    public class ReviewBuku
    {
        public int Id { get; set; }

        public DateTime WaktuInsert { get; set; }

        public int BukuId { get; set; }

        public string UserId { get; set; }

        public string Nama { get; set; }

        public int Rating { get; set; }

        public string IsiReview { get; set; }

    }
}
