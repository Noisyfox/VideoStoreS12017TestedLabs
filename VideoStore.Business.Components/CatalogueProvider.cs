using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Transactions;
using VideoStore.Business.Components.Interfaces;
using VideoStore.Business.Entities;

namespace VideoStore.Business.Components
{
    public class CatalogueProvider : ICatalogueProvider
    {
        public List<Entities.Media> GetMediaItems(int pOffset, int pCount)
        {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                return (from MediaItem in lContainer.Media.Include("Stocks")
                       orderby MediaItem.Id
                       select MediaItem).Skip(pOffset).Take(pCount).ToList();
            }
        }


        public Media GetMediaById(int pId)
        {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                return lContainer.Media.Include("Stocks").First(p => p.Id == pId); 
            }
        }

        public List<Review> GetReviews(int pId)
        {
            using (var lContainer = new VideoStoreEntityModelContainer())
            {
                return lContainer.Reviews.Include("Reviewer.LoginCredential").Include("Media.Stocks").Where(p => p.Media.Id == pId).ToList();
            }
        }

        public void CreateReview(Review review)
        {
            using (var lScope = new TransactionScope())
            using (var lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.Entry(review.Media).State = EntityState.Unchanged;
                lContainer.Entry(review.Reviewer).State = EntityState.Unchanged;
                ;
                lContainer.Reviews.Add(review);
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }
    }
}
