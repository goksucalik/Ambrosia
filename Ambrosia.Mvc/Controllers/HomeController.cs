using Ambrosia.Entities.Concrete;
using Ambrosia.Entities.Dtos;
using Ambrosia.Mvc.Models;
using Ambrosia.Services.Abstract;
using Ambrosia.Shared.Utilities.Helpers.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;

namespace Ambrosia.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IMailService _mailService;
        private readonly IToastNotification _toastNotification;
        private readonly IWritableOptions<AboutUsPageInfo> _aboutUsPageInfoWriter;

        public HomeController(IProductService productService, IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo, IMailService mailService, IToastNotification toastNotification,IWritableOptions<AboutUsPageInfo> aboutUsPageInfoWriter)
        {
            _productService = productService;
            _aboutUsPageInfo = aboutUsPageInfo.Value;
            _aboutUsPageInfoWriter = aboutUsPageInfoWriter;
            _mailService = mailService;
            _toastNotification = toastNotification;
          
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Anasayfa";
            var model = new CombinedViewModel
            {
                AboutUsPageInfo = _aboutUsPageInfo

            };
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> About()
        {
            var model = new CombinedViewModel
            {
                AboutUsPageInfo = _aboutUsPageInfo
            };
            return View(model);
            //throw new Exception("Hata");
          
        }
        [HttpGet]
        public IActionResult Contact()
        {
            //throw new Exception("Hata");
            return View();
        }
        [HttpPost]
        public IActionResult Contact(EmailSendDto emailSendDto)
        {
            if (ModelState.IsValid)
            {
                var result = _mailService.SendContactEmail(emailSendDto);
                _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                {
                    Title = "Başarılı İşlem!"
                });
                return View();
            }
            return View(emailSendDto);
        }
        [HttpGet]
        public IActionResult Basket()
        {
            return View();
        }
    }
}
