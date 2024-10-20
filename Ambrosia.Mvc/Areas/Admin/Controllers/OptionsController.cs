using Ambrosia.Entities.Concrete;
using Ambrosia.Services.Abstract;
using Ambrosia.Shared.Utilities.Helpers.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;

namespace Ambrosia.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class OptionsController : Controller
    {
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IWritableOptions<AboutUsPageInfo> _aboutUsPageInfoWriter;
        private readonly IToastNotification _toastNotification;
        public OptionsController(IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo, IWritableOptions<AboutUsPageInfo> aboutUsPageInfoWriter, IToastNotification toastNotification)
        {
            _aboutUsPageInfoWriter = aboutUsPageInfoWriter;
            _toastNotification = toastNotification;
            _aboutUsPageInfo = aboutUsPageInfo.Value;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult About()
        {
            return View(_aboutUsPageInfo);
        }
        [HttpPost]
        public IActionResult About(AboutUsPageInfo aboutUsPageInfo)
        {
            if (ModelState.IsValid)
            {
                _aboutUsPageInfoWriter.Update(x =>
                {
                    x.Header = aboutUsPageInfo.Header;
                    x.IntroHeader = aboutUsPageInfo.IntroHeader;
                    x.IntroContent = aboutUsPageInfo.IntroContent;
                    x.VisionHeader = aboutUsPageInfo.VisionHeader;
                    x.VisionContent = aboutUsPageInfo.VisionContent;
                    x.MissionHeader = aboutUsPageInfo.MissionHeader;
                    x.MissionContent = aboutUsPageInfo.MissionContent;
                    x.SeoAuthor = aboutUsPageInfo.SeoAuthor;
                    x.SeoDescription = aboutUsPageInfo.SeoDescription;
                    x.SeoTags = aboutUsPageInfo.SeoTags;
                });
                _toastNotification.AddSuccessToastMessage("Hakkımızda Sayfası başarıyla güncellenmiştir.", new ToastrOptions
                {
                    Title = "Başarılı İşlem!"
                });
                return View(aboutUsPageInfo);

            }
            return View(aboutUsPageInfo);
        }
    }
}
