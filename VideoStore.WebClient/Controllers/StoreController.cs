using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Services.Interfaces;
using VideoStore.Services.MessageTypes;
using VideoStore.WebClient.ViewModels;

namespace VideoStore.WebClient.Controllers
{
    public class StoreController : Controller
    {
        private ICatalogueService CatalogueService
        {
            get
            {
                return ServiceFactory.Instance.CatalogueService;
            }
        }

        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListMedia()
        {
            return View(new CatalogueViewModel());
        }

        public ActionResult MediaDetail(int media)
        {
            return View(new MediaDetailViewModel(media));
        }

        public ActionResult WriteReview(UserCache pUser, int media)
        {
            ViewBag.Media = CatalogueService.GetMediaById(media);
            return View(new WriteReviewViewModel(pUser.Model));
        }

        public ActionResult ListMediaWebAPI()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WriteReview(WriteReviewViewModel pReviewViewModel, UserCache pUser, int media)
        {
            ViewBag.Media = CatalogueService.GetMediaById(media);
            pReviewViewModel.Update(pUser.Model);

            if (!ModelState.IsValid)
            {
                return View(pReviewViewModel);
            }
            
            CatalogueService.CreateReview(pReviewViewModel.ToReview(pUser.Model, ViewBag.Media));

            return RedirectToAction("MediaDetail", new {media=media});
        }
    }
}
