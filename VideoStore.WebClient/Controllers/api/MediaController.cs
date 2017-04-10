using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoStore.Services.Interfaces;
using VideoStore.Services.MessageTypes;

namespace VideoStore.WebClient.Controllers
{
    public class MediaController : ApiController
    {
        private ICatalogueService CatalogueService
        {
            get
            {
                return ServiceFactory.Instance.CatalogueService;
            }
        }

        public IEnumerable<Media> GetAllMedia()
        {
            return CatalogueService.GetMediaItems(0, int.MaxValue);
        }
    }
}
