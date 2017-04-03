using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoStore.Services.Interfaces;
using VideoStore.Services.MessageTypes;

namespace VideoStore.WebClient.ViewModels
{
    public class WriteReviewViewModel
    {
        public WriteReviewViewModel()
        {
        }

        public WriteReviewViewModel(User user)
        {
            Update(user);
        }

        public void Update(User user)
        {
            Date = DateTime.Now.ToString("d");
            Reviewer = user.Name;
            Location = $"{user.Country}, {user.City}";
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Display(Name = "Date")]
        public string Date { get; set; }

        
        [Display(Name = "Reviewer")]
        public string Reviewer { get; set; }

        
        [Display(Name = "Location")]
        public string Location { get; set; }


        [Required]
        [Display(Name = "Rating")]
        [Range(0, 5, ErrorMessage = "Rating must between 0-5")]
        public int Rating { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Review")]
        public string Content { get; set; }

        public Review ToReview(User user, Media media)
        {
            return new Review()
            {
                Title = Title,
                Date = DateTime.Now,
                Reviewer = user,
                Rating = Rating,
                Content = Content,
                Media = media
            };
        }
    }
}