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

        public MediaDetailViewModel(int id)
        {
            Media = CatalogueService.GetMediaById(id);
        }
    }
}