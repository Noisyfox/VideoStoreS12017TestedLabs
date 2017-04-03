using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoStore.Services.Interfaces;
using VideoStore.Services.MessageTypes;

namespace VideoStore.WebClient.ViewModels
{
    public class MediaDetailViewModel
    {
        private ICatalogueService CatalogueService
        {
            get
            {
                return ServiceFactory.Instance.CatalogueService;
            }
        }

        public Media Media { get; }

        public List<Review> Reviews { get; }

        public double AverageRating { get; }

        public MediaDetailViewModel(int id)
        {
            Media = CatalogueService.GetMediaById(id);
            Reviews = CatalogueService.GetReviews(Media);
            AverageRating = Reviews.Select(r => r.Rating).DefaultIfEmpty(0).Average();
        }
    }
}