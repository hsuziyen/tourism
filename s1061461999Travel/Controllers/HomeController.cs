using s1061461999Travel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using s1061461999Travel.Models.ViewModels;
using System.Data;

namespace s1061461999Travel.Controllers
{
    public class HomeController : Controller
    {
        private TravelDBEntities db = new TravelDBEntities();
        public ActionResult Index()
        {
            return View();
            //return RedirectToAction("TravelHome","Home");
            //return Redirect("~/Home/MyTest3");
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

        public ActionResult Ex1()
        {
            return View();
        }

        public ActionResult Img()
        {
            return View();
        }

        public ActionResult TravelHome()
        {
            return View();
        }

        public ActionResult MyTest1()
        {
            string s = "<h2 style='color:red;'>";
            s += "回傳文字資料";
            s += "</h2>";
            return Content(s);
        }
        public string MyTest2()
        {
            string s = "";
            for (int i = 20; i < 50; i += 5)
                s += string.Format("<p style='font-size:{0}px;'>字型{0}", i);
            return s;
        }

        public ActionResult MyTest3()
        {
            
            return View();
        }

        public ActionResult MyLogin()
        {
            return PartialView();
        }

        public ActionResult DemoInput()
        {
            return View();
        }
        public ActionResult CheckInput(string name)
        {
            ViewBag.Name = name;
            if (string.IsNullOrEmpty(name))
            {
                TempData["Msg"] = "姓名不得空白";
                TempData["Msg2"] = "不得空白";
                return RedirectToAction("DemoInput","Home");
            }            
            return View();
        }

        public ActionResult DemoQueryString(int id,string name,int score)
        {
            string s = "<h1>";
            s+="id:"+int.Parse(Request.QueryString["id"])+"<br/>";
            s += "name:"+Request.QueryString["name"]+"&nbsp;";
            s += "score:" + int.Parse(Request.QueryString["score"]);
            s += "</h1>";
            return Content(s);
        }

        public ActionResult DemoRouteData(int id,string name,int score)
        {
            string s = "<h1>";
            s += "id:" + id + "<br/>";
            s += "name:" + name;
            s += "score:" + score;
            s += "</h1>";
            return Content(s);
        }

        public ActionResult MemberApply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberApply(string account,string password, string name,string email,
            string phone, string edu,string[] interest)
        {
            ViewBag.account = account;
            ViewBag.password = password;
            ViewBag.name = name;
            ViewBag.email = email;
            ViewBag.phone = phone;
            ViewBag.edu = edu;
            ViewBag.interest = interest;
            return View();
        }

        [HttpPost]
        public ActionResult MemberApplyClass(Member member)
        {
            return View(member);
        }

        public ActionResult Member()
        {            
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Member(HttpPostedFileBase photo,Member member)
        {
            string s = "<h3>";
            if (photo != null)
            {
                string fileExtName = Path.GetExtension(photo.FileName).ToLower();
                if (photo.ContentLength > 0 && (fileExtName==".jpg" || fileExtName==".png"))
                {
                    string fileName = Path.GetFileName(photo.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Upload/"), fileName);
                    photo.SaveAs(path);                   
                    s += fileName+","+photo.ContentLength/1024+"KB<br/>";
                    member.Photo = fileName;
                }
                else
                {
                    TempData["Msg"]= "請上傳圖形檔: jpg or png";
                    return View(member);
                }
            }
            ViewBag.Account = member.Account;
            s += member.BirthDay + "<br/>";
            s += "</h3>";
            //return Content(s);
            member.Name = "王小華";
            member.Edu = "大學";
            member.Interest =new string[]{ "路跑", "彈琴"};
            return View(member);
        }

        public ActionResult IsUserExists(string Account)
        {
            string[] users = new string[]{"ken","tammy","tony" };
            bool check = false;
            if (Array.IndexOf(users, Account) == -1)
                check = true;
            return Json(check, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NightMarket()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult NightMarket(HttpPostedFileBase photo,NightMarket nightMarket)
        {
            if (photo != null)
            {
                string fileExtName = Path.GetExtension(photo.FileName).ToLower();
                if (photo.ContentLength > 0 && (fileExtName == ".jpg" || fileExtName == ".png"))
                {
                    string fileName = Path.GetFileName(photo.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Upload/"), fileName);
                    photo.SaveAs(path);
                    nightMarket.Photo = fileName;
                }
                else
                {
                    TempData["Msg"] = "請上傳圖形檔: jpg or png";
                    return View(nightMarket);
                }
            }
            ViewBag.Name = nightMarket.Name;            
            return View(nightMarket);
        }

        public ActionResult Book()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Book(HttpPostedFileBase Image, Book book)
        {
            if (Image != null)
            {
                string fileExtName = Path.GetExtension(Image.FileName).ToLower();
                if (Image.ContentLength > 0 && (fileExtName == ".jpg" || fileExtName == ".png"))
                {
                    string fileName = Path.GetFileName(Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Upload/"), fileName);
                    Image.SaveAs(path);
                    book.Image = fileName;
                }
                else
                {
                    TempData["Msg"] = "請上傳圖形檔:jpg or png";                    
                }
            }
            ViewBag.ISBN = book.ISBN;
            return View(book);
        }

        public ActionResult CheckPrice(int Price)
        {
            bool check = false;
            if (Price >= 300)
                check = true;
            return Json(check, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SpotList(int AreaId=1)
        {
            ViewBag.AreaName = db.Areas.Find(AreaId).AreaName;
            SpotAreaVM spotAreaVM = new SpotAreaVM()
            {
                Areas = db.Areas.OrderBy(o => o.AreaId).ToList(),
                Spots=db.Spots.Where(o=>o.AreaId==AreaId).ToList()
            };
            return View(spotAreaVM);
        }

        public ActionResult SpotShow(int SpotId = 1)
        {            
            Spot spot = db.Spots.Find(SpotId);
            SpotView spotView = new SpotView()
            {
                SpotItem = spot,
                Images = db.Images.Where(o => o.SpotId == SpotId).ToList()
            };
            return View(spotView);
        }

        public ActionResult SpotManager()
        {
            List<Area> areas = db.Areas.ToList();
            List<Spot> spots = db.Spots.ToList();
            List<Image> images = db.Images.ToList();
            ManagerVM managerVM = new ManagerVM()
            {
                Areas = areas,
                Spots = spots,
                Images = images
            };
            return View(managerVM);
        }

        public ActionResult AddSpot(int AreaId)
        {
            ViewBag.AreaName = db.Areas.Find(AreaId).AreaName;
            ViewBag.Area = new SelectList(db.Areas, "AreaId", "AreaName", AreaId);
            string s = "<h3>";
            s += AreaId + "<br/>";
            s += "</h3>";
            //return Content(s);
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddSpot(HttpPostedFileBase[] file,string[] imageDescription, Spot spot)
        {
            string[] urls = new string[file.Length];
            Image[] images = new Image[file.Length];            
            int i = 0; 

            foreach(HttpPostedFileBase f in file)
            {
                if(f!=null)
                {
                    string fileExtName = Path.GetExtension(f.FileName).ToLower();
                    if(f.ContentLength>0 && (fileExtName==".jpg" || fileExtName == ".png"))
                    {
                        urls[i] = Path.Combine(Server.MapPath("~/Images/"), f.FileName);
                        f.SaveAs(urls[i]);
                        images[i] = new Image()
                        {
                            ImageName = f.FileName,
                            Description=imageDescription[i],
                            SpotId=spot.SpotId
                        };
                        db.Images.Add(images[i]);
                        i++;
                    }
                }
            }
            db.Spots.Add(spot);
            db.SaveChanges();
            TempData["Msg"] = "景點新增成功";

            string s = "<h3>";
            //s += AreaId + "<br/>";
            s += "</h3>";
            //return Content(s);

            return RedirectToAction("SpotManager", "Home");
        }

        public ActionResult EditSpot(int SpotId)
        {
            Spot spot = db.Spots.Find(SpotId);
            List<Image> images = db.Images.Where(o => o.SpotId == SpotId).ToList();
            ViewBag.Area = new SelectList(db.Areas, "AreaId", "AreaName", spot.AreaId);
            if (images.Count > 0)
            {
                ViewBag.Images = images;
            }
            return View(spot);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditSpot(HttpPostedFileBase[] file, string[] imageDescription, int[] ImageId, Spot spot)
        {
            string[] urls = new string[file.Length];
            Image image;
            int i = 0;

            string s = "<h3>";
            foreach (HttpPostedFileBase f in file)
            {
                s += ImageId[i] + "<br/>";
                    image = db.Images.Find(ImageId[i]);
                if (f != null)
                {
                    string fileExtName = Path.GetExtension(f.FileName).ToLower();
                    if (f.ContentLength > 0 && (fileExtName == ".jpg" || fileExtName == ".png"))
                    {
                        urls[i] = Path.Combine(Server.MapPath("~/Images/"), f.FileName);
                        f.SaveAs(urls[i]);
                        image.ImageName = f.FileName;
                    }
                }
                image.Description = imageDescription[i];
                db.Entry(image).State = System.Data.Entity.EntityState.Modified;            
                i++;
            }
            db.Entry(spot).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            TempData["Msg"] = "景點修改成功";
            s += "</h3>";
            return RedirectToAction("SpotManager", "Home");
            
            //return Content(s);
        }


        public ActionResult DeleteSpot(int SpotId)
        {
            Spot spot = db.Spots.Find(SpotId);
            var images = db.Images.Where(o => o.SpotId == SpotId).ToList();
            Image image;
            if (images.Count > 0)
            {
                foreach(var data in images)
                {
                    image = db.Images.Find(data.ImageId);
                    db.Images.Remove(image);
                }                
            }
            db.Spots.Remove(spot);
            db.SaveChanges();
            TempData["Msg"] = "景點刪除成功";
            return RedirectToAction("SpotManager", "Home");
        }

        public ActionResult ProductList(int CategoryId = 1)
        {
            string CategoryName;
            ProductCategoryVM productCategoryVM;
            using (var dbProduct=new NorthwindEntities())
            {
                CategoryName = dbProduct.產品類別.Find(CategoryId).類別名稱;
                productCategoryVM= new ProductCategoryVM()
                {
                    Category = dbProduct.產品類別.ToList(),
                    Product = dbProduct.產品資料.Where(o => o.類別編號 == CategoryId).ToList()
                };
            }
            ViewBag.CategoryName=CategoryName;
            return View(productCategoryVM);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}