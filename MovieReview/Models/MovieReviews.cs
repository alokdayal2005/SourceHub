using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieReview.Models
{
    public class MovieReviews
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        [Required]
        [StringLength(200)]
        public string ReviewerComments { get; set; }
        [Range(1,5)]
        public int ReviewerRating { get; set; }

        public int MovieId { get; set; }
    }
}