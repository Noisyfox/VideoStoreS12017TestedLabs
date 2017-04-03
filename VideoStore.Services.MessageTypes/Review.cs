using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Services.MessageTypes
{
    public class Review : MessageType
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public double Rating { get; set; }

        public string Content { get; set; }

        public virtual User Reviewer { get; set; }

        public virtual Media Media { get; set; }
    }
}
