using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace WebLab1.Controllers
{
    public class WebLab1Controller : Controller
    {
        public ActionResult BrandsListView()
        {
            List<string> frogCollarBrands = getFrogCollarBrands();
            return View(frogCollarBrands);
        }

        public ActionResult SortedBrandsListView()
        {
            List<string> frogCollarBrands = getFrogCollarBrands().OrderBy(x=>x).ToList();
            return View(frogCollarBrands);
        }

        public ActionResult SortedByFirstLetterBrandsListView()
        {
            List<string> frogCollarBrands = getFrogCollarBrands().OrderBy(x => x).ToList();
            return View(frogCollarBrands);
        }

        public ActionResult MirroredLetterBrandListView()
        {
            List<string> frogCollarBrands = getFrogCollarBrands().OrderBy(x => x).ToList();
            List<string> frogCollarBrandsMirrored = getFrogCollarBrands().OrderBy(x => x).Select(x => new string(x.Reverse().ToArray())).ToList();
            List<string>[] data = { frogCollarBrands, frogCollarBrandsMirrored };
            return View(data);
        }

        public List<string> getFrogCollarBrands()
        {
            List<string> frogCollarCompanies = new List<string>
            {
            "FroggyFit",
            "AmphibianAccessories",
            "LeapingLeather",
            "RibbitGear",
            "PondPalsPro",
            "HopNShop",
            "CroakCollars",
            "FrogFashionista",
            "LilyPadLuxuries",
            "TadpoleTrends"
            };
            return frogCollarCompanies;
        }
    }
}

//\Views\WebLab1\BrandsListView.cshtml
//\Views\WebLab1\BrandsListView.cshtml

