using Ambrosia.Entities.Concrete;
using Ambrosia.Entities.Dtos;

namespace Ambrosia.Mvc.Models
{
    public class CombinedViewModel
    {
        public EmailSendDto EmailSendDto { get; set; }
        public WebSiteInfo WebsiteInfo { get; set; }
        public AboutUsPageInfo AboutUsPageInfo { get; set; }
    }
}
