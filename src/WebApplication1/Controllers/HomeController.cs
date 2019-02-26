using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetImage()
        {
            var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            var code = new QrCode();
            qrEncoder.TryEncode($"hello qrcode{DateTime.Now.ToString()}", out code);
            const int modelSizeInPixels = 4;

            var render = new GraphicsRenderer(new FixedModuleSize(modelSizeInPixels, QuietZoneModules.Two), Brushes.Black, Brushes.White);

            var ms = new MemoryStream();
            render.WriteToStream(code.Matrix, ImageFormat.Jpeg, ms);
            return new ImageResult(Image.FromStream(ms));
        }
    }
}