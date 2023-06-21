using FinalProject1ForMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;

namespace FinalProject1ForMVC.Controllers
{
    public class AdminController : Controller
    {
       
            private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }


        // i am set session in auth login **
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("AdminId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("AdminId");

                int AdminId = (int)HttpContext.Session.GetInt32("AdminId");

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();
                ViewBag.id = cus.Customerid;
                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;
                var fname = cus.Fname;
                var lname = cus.Lname;
            }
            // viewbag and viewdata
            ViewBag.Users = _context.Customer1s.Count();//count number of customer
            ViewBag.Products = _context.Product1s.Count();// count number of product
            ViewBag.Sales = _context.Order1s.Count();// sum sale 
            //ViewData["Users"] = _context.Customer1s.Count(); // same the first one but using viewdata
            //ViewData["Sale"] = _context.Product1s.Sum(x => x.Sale);

            //ViewBag.customers = _context.Customer1s.ToList();// generate variable have list of customers

            //
            //generate variable have list of row from database
            //var Customers = _context.Customer1s.ToList();
            //var Products = _context.Product1s.ToList();
            var customers = _context.Customer1s.ToList();
            var order = _context.Order1s.ToList();
            var orderitem = _context.Orderitem1s.ToList();
            var categoryproduct = _context.Categoryproduct1s.ToList();
            var products = _context.Product1s.ToList();
            var categoryStore = _context.Categorystore1s.ToList();
            var store = _context.Store1s.ToList();


            // join table 
            var result = from c in customers
                             //order
                         join o in order on c.Customerid equals o.Customerid
                         join oi in orderitem on o.Orderitemid equals oi.Orderitemid
                         //cart
                         //join oi in orderitem on c.Customerid equals oi.Customerid

                         join p in products on oi.Productid equals p.Productid
                         join catp in categoryproduct on p.Categoryproductid equals catp.Categoryproductid
                         join st in store on catp.Storeid equals st.Storeid
                         join cats in categoryStore on st.Categorystoreid equals cats.Categoryid
                         select new JoinTable { Customer1 = c, Order1 = o, Orderitem1 = oi, Product1 = p, Categoryproduct1 = catp, Store1 = st, Categorystore1 = cats };

            //            var model = Tuple.Create<IEnumerable<Customer1>, IEnumerable<Product1>, IEnumerable<Orderitem1>,IEnumerable<Order1>, IEnumerable<Categoryproduct1>, IEnumerable<Store1>, IEnumerable<Categorystore1>, IEnumerable<JoinTable>>(customers, products, orderitem,order, categoryproduct, store, categoryStore, result);


            


            var model = Tuple.Create<IEnumerable<Customer1>, IEnumerable<Product1>,IEnumerable<JoinTable> >(customers, products,result);
            return View(model);

        }

        public IActionResult USerProfile()
        {
            if (HttpContext.Session.GetInt32("AdminId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("AdminId");

                int AdminId = (int)HttpContext.Session.GetInt32("AdminId");

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();
                
                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;

                var Fname = cus.Fname;
                var Lname = cus.Lname;
                var id = cus.Customerid;

                return View(cus);


            }
            return View();
        }



        public IActionResult ChangePassword()
        {
            if (HttpContext.Session.GetInt32("AdminId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("AdminId");

                int AdminId = (int)HttpContext.Session.GetInt32("AdminId");
                var customer = _context.Customer1s.ToList();

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();
                ViewBag.id = cus.Customerid;
                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;
                var changepass = _context.Userlogin1s.Where(x => x.Customerid == AdminId).SingleOrDefault();

                var Fname = cus.Fname;
                var Lname = cus.Lname;


                return View(changepass);


            }
            return View();
        }


        //[HttpPost]
        //public IActionResult UserProfile(int id)
        //{
        //    int AdminId = (int)HttpContext.Session.GetInt32("AdminId");
        //    var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();
            
        //    return RedirectToAction("Edit", "Customer1", id);
        //}
        //**************************************************************************


        //[HttpGet]
        //        public IActionResult UserProfile()
        //        {
        //            if (HttpContext.Session.GetInt32("AdminId") != null)
        //            {
        //                ViewBag.AdminId = HttpContext.Session.GetInt32("AdminId");

        //                int AdminId = (int)HttpContext.Session.GetInt32("AdminId");

        //                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();

        //                ViewBag.FName = cus.Fname;
        //                ViewBag.LName = cus.Lname;

        //                var Fname = cus.Fname;
        //                var Lname = cus.Lname;

        //                return View(cus);
        //            }

        //            return View();
        //        }
        //        [HttpPost]
        //        public IActionResult USerProfile()
        //        {
        //                int AdminId = (int)HttpContext.Session.GetInt32("AdminId");
        //                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();
        //                return RedirectToAction("Edit", "Customer1", cus);  
        //        }


        //*******************************************************************

        //[HttpPost]
        //public IActionResult UserProfile()
        //{
        //    int AdminId = (int)HttpContext.Session.GetInt32("AdminId");
        //    var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();
        //    ViewBag.FName = cus.Fname;
        //    ViewBag.LName = cus.Lname;

        //    var Fname = cus.Fname;
        //    var Lname = cus.Lname;


        //    //var cus = _context.Customers.Where(x => x.Id == id).SingleOrDefault();
        //    return RedirectToAction("Edit", "Customer1", cus);
        //}
        //***********************************************************************************


        //[HttpGet]
        //public IActionResult changePassword()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult changePassword()
        //{
        //    int AdminId = (int)HttpContext.Session.GetInt32("AdminId");
        //    var cus = _context.Userlogin1s.Where(x => x.Customerid == AdminId).SingleOrDefault();
        //    ViewBag.username = cus.Username;
        //    ViewBag.pass = cus.Password;

        //    var username = cus.Username;
        //    var pass = cus.Password;


        //    //var cus = _context.Customers.Where(x => x.Id == id).SingleOrDefault();
        //    return RedirectToAction("Edit", "Userlogin1", cus);
        //}







        public IActionResult JoinTable()
        {
            if (HttpContext.Session.GetInt32("AdminId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("AdminId");

                int AdminId = (int)HttpContext.Session.GetInt32("AdminId");

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();

                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;
              
            }
            var customers = _context.Customer1s.ToList();
            var order = _context.Order1s.ToList();
            var orderitem = _context.Orderitem1s.ToList();
            var categoryproduct = _context.Categoryproduct1s.ToList();
            var products = _context.Product1s.ToList();
            var categoryStore = _context.Categorystore1s.ToList();
            var store = _context.Store1s.ToList();


            var result = from c in customers
                             //order
                         join o in order on c.Customerid equals o.Customerid
                         join oi in orderitem on o.Orderitemid equals oi.Orderitemid
                         //cart
                         //join oi in orderitem on c.Customerid equals oi.Customerid

                         join p in products on oi.Productid equals p.Productid
                         join catp in categoryproduct on p.Categoryproductid equals catp.Categoryproductid
                         join st in store on catp.Storeid equals st.Storeid
                         join cats in categoryStore on st.Categorystoreid equals cats.Categoryid
                         select new JoinTable { Customer1 = c, Order1 = o, Orderitem1 = oi, Product1 = p, Categoryproduct1 = catp, Store1 = st, Categorystore1 = cats };

            return View(result);
        }


        public IActionResult Search()
        {
            if (HttpContext.Session.GetInt32("AdminId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("AdminId");

                int AdminId = (int)HttpContext.Session.GetInt32("AdminId");

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();

                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;
                var fname = cus.Fname;
                var lname = cus.Lname;
            }
            var modelContext = _context.Order1s.Include(p => p.Orderitem).Include(p=>p.Customer).ToList();
            return View(modelContext);

        }
        [HttpPost]
        public IActionResult Search(DateTime? startDate, DateTime? endDate)
        {
           
            var modelContext = _context.Order1s.Include(p => p.Orderitem).Include(p => p.Customer).ToList();
            
            if (startDate == null && endDate == null)
            {
                return View(modelContext);
            }
            else if (startDate != null && endDate == null)
            {
                var result = modelContext.Where(x => x.Datefrom.Value.Date == startDate);
                return View(result);
            }
            else if (startDate == null && endDate != null)
            {
                var result = modelContext.Where(x => x.Datefrom.Value.Date == endDate);
                return View(result);
            }
            else
            {
                var result = modelContext.Where(x => x.Datefrom.Value.Date >= startDate && x.Datefrom.Value.Date <= endDate);
                return View(result);
            }
        }




        public IActionResult Report()
        {
          
            var customers = _context.Customer1s.ToList();
            var order = _context.Order1s.ToList();
            var orderitem = _context.Orderitem1s.ToList();
            var categoryproduct = _context.Categoryproduct1s.ToList();
            var products = _context.Product1s.ToList();
            var categoryStore = _context.Categorystore1s.ToList();
            var store = _context.Store1s.ToList();


            var result = from c in customers
                             //order
                         join o in order on c.Customerid equals o.Customerid
                         join oi in orderitem on o.Orderitemid equals oi.Orderitemid
                         //cart
                         //join oi in orderitem on c.Customerid equals oi.Customerid

                         join p in products on oi.Productid equals p.Productid
                         join catp in categoryproduct on p.Categoryproductid equals catp.Categoryproductid
                         join st in store on catp.Storeid equals st.Storeid
                         join cats in categoryStore on st.Categorystoreid equals cats.Categoryid
                         select new JoinTable { Customer1 = c, Order1 = o, Orderitem1 = oi, Product1 = p, Categoryproduct1 = catp, Store1 = st, Categorystore1 = cats };

            ViewBag.TotalQuantity = _context.Order1s.Sum(x => x.Orderitem.Quantityitem);
            ViewBag.TotalPrice = _context.Order1s.Sum(x => x.Orderitem.Quantityitem * x.Orderitem.Product.Price);
            var modelContext = _context.Order1s.Include(p => p.Orderitem).Include(p => p.Orderitem.Product).ToList();
            var model = Tuple.Create<IEnumerable<JoinTable>, IEnumerable<Order1>>(result, modelContext);
            return View(model);
        }


        [HttpPost]
        public IActionResult Report(DateTime? startDate, DateTime? endDate)
        {
            var customers = _context.Customer1s.ToList();
            var order = _context.Order1s.ToList();
            var orderitem = _context.Orderitem1s.ToList();
            var categoryproduct = _context.Categoryproduct1s.ToList();
            var products = _context.Product1s.ToList();
            var categoryStore = _context.Categorystore1s.ToList();
            var store = _context.Store1s.ToList();


            var result = from c in customers
                             //order
                         join o in order on c.Customerid equals o.Customerid
                         join oi in orderitem on o.Orderitemid equals oi.Orderitemid
                         //cart
                         //join oi in orderitem on c.Customerid equals oi.Customerid

                         join p in products on oi.Productid equals p.Productid
                         join catp in categoryproduct on p.Categoryproductid equals catp.Categoryproductid
                         join st in store on catp.Storeid equals st.Storeid
                         join cats in categoryStore on st.Categorystoreid equals cats.Categoryid
                         select new JoinTable { Customer1 = c, Order1 = o, Orderitem1 = oi, Product1 = p, Categoryproduct1 = catp, Store1 = st, Categorystore1 = cats };

            var modelContext = _context.Order1s.Include(p => p.Customer).Include(p => p.Orderitem).ToList();

            if (startDate == null && endDate == null)
            {
                var model = Tuple.Create<IEnumerable<JoinTable>, IEnumerable<Order1>>(result, modelContext);
                ViewBag.TotalQuantity = modelContext.Sum(x => x.Orderitem.Quantityitem);
                ViewBag.TotalPrice = modelContext.Sum(x => x.Orderitem.Quantityitem * x.Orderitem.Product.Price);
                return View(model);
            }
            else if (startDate != null && endDate == null)
            {

                var result1 = modelContext.Where(x => x.Datefrom.Value.Date == startDate);
                //ViewBag.TotalQuantity = result1.Sum(x => x.Orderitem.Quantityitem);
                ViewBag.TotalPrice = result1.Sum(x => x.Orderitem.Quantityitem * x.Orderitem.Product.Price);
                var model = Tuple.Create<IEnumerable<JoinTable>, IEnumerable<Order1>>(result, modelContext);

                return View(model);
            }
            else if (startDate == null && endDate != null)
            {
                var result1 = modelContext.Where(x => x.Datefrom.Value.Date == endDate);
                ViewBag.TotalQuantity = result1.Sum(x => x.Orderitem.Quantityitem);
                ViewBag.TotalPrice = result1.Sum(x => x.Orderitem.Quantityitem * x.Orderitem.Product.Price);
                var model = Tuple.Create<IEnumerable<JoinTable>, IEnumerable<Order1>>(result, modelContext);

                return View(model);
            }
            else
            {
                var result1 = modelContext.Where(x => x.Datefrom.Value.Date >= startDate && x.Datefrom.Value.Date <= endDate);
                ViewBag.TotalQuantity = result1.Sum(x => x.Orderitem.Quantityitem);
                ViewBag.TotalPrice = result1.Sum(x => x.Orderitem.Quantityitem * x.Orderitem.Product.Price);
                var model = Tuple.Create<IEnumerable<JoinTable>, IEnumerable<Order1>>(result, modelContext);

                return View(model);
            }
        }





        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("login","Auth");
        }




        public IActionResult SendEmail()
        {
            return View();
        }

        //send email 
        [HttpPost]
        public IActionResult SendEmail(string to,string subj, string body)
        {

            //obj from mime kit for send email
            MimeMessage msg = new MimeMessage();

            //define the sender ("Name","email address")
            MailboxAddress from = new MailboxAddress("dana abd", "alfalahdana3@outlook.com");
            //add to email into from (the sender )
            msg.From.Add(from);

            //define the reseiver 
            MailboxAddress too = new MailboxAddress("Dana Abd", to);
            msg.To.Add(too);

            //define the subject 
            //msg.Subject = "purchases invoice";
            
            msg.Subject = subj;


            BodyBuilder bodyBuilder = new BodyBuilder();
            //bodyBuilder.HtmlBody = "<h1 style=\"color:red\"> hello dana</h1>" + "Welcome " + "<p> this message for your order purchases invoice"+"<h4 style=\"color:yellow\">best regaeds</h4>";
            bodyBuilder.HtmlBody = body;
            msg.Body = bodyBuilder.ToMessageBody();

            //you should using .net.mail
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.office365.com", 587, false );
                client.Authenticate("alfalahdana3@outlook.com", "dodo77199");
                client.Send(msg);
                client.Disconnect(true);

                //https://github.com/jstedfast/MailKit    &&    https://gist.github.com/wattanar/e8cee974456fd80d9ce649d951f36608     link for mailkit code 
            }

            ViewBag.alertMessage ="Email sending";
            return View();
        }







        



        //home pages Action




    }
}
