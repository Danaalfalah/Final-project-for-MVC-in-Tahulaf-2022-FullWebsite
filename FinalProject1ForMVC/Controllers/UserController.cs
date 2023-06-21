using FinalProject1ForMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject1ForMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        public IActionResult Index()
        {
            var x1 = _context.Contactus.Where(x => x.Id == 1).SingleOrDefault();
            ViewBag.phone = x1.Phone;
            ViewBag.email = x1.Email;
            var phone = x1.Phone;
            var email = x1.Email;


            var location = _context.Locations.ToList();
            var loc = _context.Locations.Where(x => x.Id == 1).SingleOrDefault();
            ViewBag.loc1url = loc.Locationanurl;
            ViewBag.loc1name = loc.Locationname;
            var loc1url = loc.Locationanurl;
            var loc1name = loc.Locationname;

            var loc2 = _context.Locations.Where(x => x.Id == 2).SingleOrDefault();
            ViewBag.loc2url = loc2.Locationanurl;
            ViewBag.loc2name = loc2.Locationname;
            var loc2url = loc2.Locationanurl;
            var loc2name = loc2.Locationname;

            if (HttpContext.Session.GetInt32("CustomerId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("CustomerId");

                int AdminId = (int)HttpContext.Session.GetInt32("CustomerId");

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();

                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;
            }
            var categoryproduct = _context.Categoryproduct1s.ToList();
            var products = _context.Product1s.ToList();
            var categoryStore = _context.Categorystore1s.ToList();
            var store = _context.Store1s.ToList();

            var resultJoin = from p in products
                             join catp in categoryproduct on p.Categoryproductid equals catp.Categoryproductid
                             join s in store on catp.Storeid equals s.Storeid
                             join cats in categoryStore on s.Categorystoreid equals cats.Categoryid
                             select new JoinTAble2 { Categorystore1 = cats, Store1 = s, Categoryproduct1 = catp, Product1 = p };


            var result = Tuple.Create<IEnumerable<Store1>, IEnumerable<Categorystore1>, IEnumerable<Categoryproduct1>, IEnumerable<JoinTAble2>>( store, categoryStore, categoryproduct, resultJoin);
            return View(result);
            //var cus = _context.Customer1s.ToList();
            //return View();
        }



    //*********************************************************************************************************************************************************************************************************

        public IActionResult ShowProduct(int id)
        {
            if (HttpContext.Session.GetInt32("CustomerId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("CustomerId");

                int AdminId = (int)HttpContext.Session.GetInt32("CustomerId");

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();

                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;
            }
            var x1 = _context.Contactus.Where(x => x.Id == 1).FirstOrDefault();
            ViewBag.phone = x1.Phone;
            ViewBag.email = x1.Email;
            var phone = x1.Phone;
            var email = x1.Email;
            var location = _context.Locations.ToList();
            var loc = _context.Locations.Where(x => x.Id == 1).SingleOrDefault();
            ViewBag.loc1url = loc.Locationanurl;
            ViewBag.loc1name = loc.Locationname;
            var loc2 = _context.Locations.Where(x => x.Id == 2).SingleOrDefault();
            ViewBag.loc2url = loc2.Locationanurl;
            ViewBag.loc2name = loc2.Locationname;
            //var data = _context.Store1s.Where(x=>x.Categorystoreid==id).ToList();

            var categoryproduct = _context.Categoryproduct1s.ToList();
            var products = _context.Product1s.ToList();
            var categoryStore = _context.Categorystore1s.Where(x => x.Categoryid == id).ToList();
            var store = _context.Store1s.ToList();

            var resultJoin = from p in products
                             join catp in categoryproduct on p.Categoryproductid equals catp.Categoryproductid
                             join s in store on catp.Storeid equals s.Storeid
                             join cats in categoryStore on s.Categorystoreid equals cats.Categoryid
                             select new JoinTAble2 { Categorystore1 = cats, Store1 = s, Categoryproduct1 = catp, Product1 = p };

            return View(resultJoin);
        }

     //*********************************************************************************************************************************************************************************************************


        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            if (HttpContext.Session.GetInt32("CustomerId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("CustomerId");

                int AdminId = (int)HttpContext.Session.GetInt32("CustomerId");

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();

                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;
            }
            var x1 = _context.Contactus.Where(x => x.Id == 1).FirstOrDefault();
            ViewBag.phone = x1.Phone;
            ViewBag.email = x1.Email;
            var phone = x1.Phone;
            var email = x1.Email;
            var location = _context.Locations.ToList();
            var loc = _context.Locations.Where(x => x.Id == 1).SingleOrDefault();
            ViewBag.loc1url = loc.Locationanurl;
            ViewBag.loc1name = loc.Locationname;
            var loc2 = _context.Locations.Where(x => x.Id == 2).SingleOrDefault();
            ViewBag.loc2url = loc2.Locationanurl;
            ViewBag.loc2name = loc2.Locationname;

            //*********
            var categoryproduct = _context.Categoryproduct1s.ToList();
            var products = _context.Product1s.Where(x => x.Productid == id).ToList();
            var categoryStore = _context.Categorystore1s.ToList();
            var store = _context.Store1s.ToList();

            var resultJoin = from p in products
                             join catp in categoryproduct on p.Categoryproductid equals catp.Categoryproductid
                             join s in store on catp.Storeid equals s.Storeid
                             join cats in categoryStore on s.Categorystoreid equals cats.Categoryid
                             select new JoinTAble2 { Categorystore1 = cats, Store1 = s, Categoryproduct1 = catp, Product1 = p };

            return View(resultJoin);

        }

   //*********************************************************************************************************************************************************************************************************


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart([Bind("Orderitemid,Quantityitem,Productid")] Orderitem1 orderitem1)
        {
            if (HttpContext.Session.GetInt32("CustomerId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("CustomerId");

                int AdminId = (int)HttpContext.Session.GetInt32("CustomerId");

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();

                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;


                if (ModelState.IsValid)
                {


                    _context.Add(orderitem1);
                    await _context.SaveChangesAsync();
                    var i = _context.Product1s.Where(x => x.Productid == orderitem1.Productid).SingleOrDefault();
                    Order1 order = new Order1();
                    order.Customerid = AdminId;
                    order.Orderitemid = orderitem1.Orderitemid;
                    order.Descriptions = "order";
                    order.Datefrom = DateTime.Now;
                    order.Totalprice = _context.Orderitem1s.Sum(x => x.Quantityitem * i.Price);// in table 
                    ViewBag.TotalpriceAll = _context.Orderitem1s.Sum(x => x.Quantityitem * x.Product.Price); // in sub total 

                    

                    _context.Add(order);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ProductDetails",orderitem1.Productid);
                }
            }
            return View();
        }



 //*********************************************************************************************************************************************************************************************************





        public IActionResult Gallery()
        {
            if (HttpContext.Session.GetInt32("CustomerId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("CustomerId");

                int AdminId = (int)HttpContext.Session.GetInt32("CustomerId");

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();

                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;
            }
            var x1 = _context.Contactus.Where(x => x.Id == 1).FirstOrDefault();
            ViewBag.phone = x1.Phone;
            ViewBag.email = x1.Email;
            var phone = x1.Phone;
            var email = x1.Email;
            var location = _context.Locations.ToList();
            var loc = _context.Locations.Where(x => x.Id == 1).SingleOrDefault();
            ViewBag.loc1url = loc.Locationanurl;
            ViewBag.loc1name = loc.Locationname;
            var loc2 = _context.Locations.Where(x => x.Id == 2).SingleOrDefault();
            ViewBag.loc2url = loc2.Locationanurl;
            ViewBag.loc2name = loc2.Locationname;

            var categoryproduct = _context.Categoryproduct1s.ToList();
            var products = _context.Product1s.ToList();
            var categoryStore = _context.Categorystore1s.ToList();
            var store = _context.Store1s.ToList();

            var resultJoin = from p in products
                             join catp in categoryproduct on p.Categoryproductid equals catp.Categoryproductid
                             join s in store on catp.Storeid equals s.Storeid
                             join cats in categoryStore on s.Categorystoreid equals cats.Categoryid
                             select new JoinTAble2 { Categorystore1 = cats, Store1 = s, Categoryproduct1 = catp, Product1 = p };

            var include1 = _context.Categoryproduct1s.Include(p => p.Product1s).Include(p => p.Store);

            return View(resultJoin);
        }


  //*********************************************************************************************************************************************************************************************************




        public IActionResult EditProfile()
        {

            var x1 = _context.Contactus.Where(x => x.Id == 1).FirstOrDefault();
            ViewBag.phone = x1.Phone;
            ViewBag.email = x1.Email;
            var phone = x1.Phone;
            var email = x1.Email;
            var location = _context.Locations.ToList();
            var loc = _context.Locations.Where(x => x.Id == 1).SingleOrDefault();
            ViewBag.loc1url = loc.Locationanurl;
            ViewBag.loc1name = loc.Locationname;
            var loc2 = _context.Locations.Where(x => x.Id == 2).SingleOrDefault();
            ViewBag.loc2url = loc2.Locationanurl;
            ViewBag.loc2name = loc2.Locationname;


            if (HttpContext.Session.GetInt32("CustomerId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("CustomerId");

                int AdminId = (int)HttpContext.Session.GetInt32("CustomerId");
                var customer = _context.Customer1s.ToList();

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();
                ViewBag.id = cus.Customerid;
                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;
                

                var Fname = cus.Fname;
                var Lname = cus.Lname;
                

                return View(cus);


            }
            return View();

        }

        //*********************************************************************************************************************************************************************************************************



        public IActionResult ChangePassword()
        {
            var x1 = _context.Contactus.Where(x => x.Id == 1).FirstOrDefault();
            ViewBag.phone = x1.Phone;
            ViewBag.email = x1.Email;
            var phone = x1.Phone;
            var email = x1.Email;
            var location = _context.Locations.ToList();
            var loc = _context.Locations.Where(x => x.Id == 1).SingleOrDefault();
            ViewBag.loc1url = loc.Locationanurl;
            ViewBag.loc1name = loc.Locationname;
            var loc2 = _context.Locations.Where(x => x.Id == 2).SingleOrDefault();
            ViewBag.loc2url = loc2.Locationanurl;
            ViewBag.loc2name = loc2.Locationname;


            if (HttpContext.Session.GetInt32("CustomerId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("CustomerId");

                int AdminId = (int)HttpContext.Session.GetInt32("CustomerId");
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



        //*********************************************************************************************************************************************************************************************************
        //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

        public IActionResult Cart()
        {
            var x1 = _context.Contactus.Where(x => x.Id == 1).FirstOrDefault();
            ViewBag.phone = x1.Phone;
            ViewBag.email = x1.Email;
            var phone = x1.Phone;
            var email = x1.Email;
            var location = _context.Locations.ToList();
            var loc = _context.Locations.Where(x => x.Id == 1).SingleOrDefault();
            ViewBag.loc1url = loc.Locationanurl;
            ViewBag.loc1name = loc.Locationname;
            var loc2 = _context.Locations.Where(x => x.Id == 2).SingleOrDefault();
            ViewBag.loc2url = loc2.Locationanurl;
            ViewBag.loc2name = loc2.Locationname;

            if(HttpContext.Session.GetInt32("CustomerId") == null)
            {
                return NotFound();
            }


            if (HttpContext.Session.GetInt32("CustomerId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("CustomerId");

                int AdminId = (int)HttpContext.Session.GetInt32("CustomerId");
                var customer = _context.Customer1s.ToList();

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();
                ViewBag.id = cus.Customerid;
                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;
                

                var Fname = cus.Fname;
                var Lname = cus.Lname;

                var customers = _context.Customer1s.Where(x => x.Customerid == AdminId).ToList();
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

                var TotalPrice = result.Sum(x => x.Orderitem1.Quantityitem * x.Orderitem1.Product.Price);
                ViewBag.TotalPrice = TotalPrice;

                var delivery = _context.Deliveryinfos.Where(x => x.Id == 1).SingleOrDefault();
                ViewBag.deliverycharge = delivery.Deliverycharge;
                ViewBag.deliveryfree = delivery.Deliveryfreeabove;
                ViewBag.delivery3 = delivery.Numberofdaydelivery;

                if(delivery.Deliveryfreeabove < TotalPrice)
                {
                    ViewBag.deliverycharge = 0;
                    ViewBag.total = TotalPrice;
                    ViewBag.totalOrder = TotalPrice;

                }
                else if(delivery.Deliveryfreeabove > TotalPrice)
                {
                    ViewBag.deliverycharge = delivery.Deliverycharge;
                    ViewBag.total = TotalPrice;
                    ViewBag.totalOrder = (delivery.Deliverycharge + TotalPrice);

                }

                return View(result);
            }
          
            return View();

        }

        // POST: Customer1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var omit = await _context.Order1s.FindAsync(id);
            _context.Order1s.Remove(omit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Cart");
        }


        //[HttpPost] 
        //public IActionResult Cart(int productId,[Bind("Quantityitem")] Orderitem1 orderitem1)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    _context.Add(orderitem1);
        //    //     _context.SaveChangesAsync();
        //    //    //Userlogin1 userLogin = new Userlogin1();
        //    //    //userLogin.Username = Username;
        //    //    //userLogin.Password = Password;
        //    //    //userLogin.Roleid = 2;//customer role id
        //    //    //userLogin.Customerid = customer.Customerid;
        //    //    //_context.Add(userLogin);
        //    //    //await _context.SaveChangesAsync();
        //    //    return RedirectToAction("Cart", "User");
        //    //}
        //    //if (HttpContext.Session.GetInt32("CustomerId") != null)
        //    //{
        //    //    ViewBag.AdminId = HttpContext.Session.GetInt32("CustomerId");

        //    //    int AdminId = (int)HttpContext.Session.GetInt32("CustomerId");

        //    //    var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();


        //    //    ViewBag.FName = cus.Fname;
        //    //    ViewBag.LName = cus.Lname;
        //    //var order = _context.Orderitem1s.ToList();
        //    //var products = _context.Product1s.Where(x => x.Productid == productId).ToList();
        //    //var categoryproduct = _context.Categoryproduct1s.ToList();
        //    //var categoryStore = _context.Categorystore1s.ToList();
        //    //var store = _context.Store1s.ToList();

        //    //var resultJoin = from p in products
        //    //                 join catp in categoryproduct on p.Categoryproductid equals catp.Categoryproductid
        //    //                 join s in store on catp.Storeid equals s.Storeid
        //    //                 join cats in categoryStore on s.Categorystoreid equals cats.Categoryid
        //    //                 select new JoinTAble2 { Categorystore1 = cats, Store1 = s, Categoryproduct1 = catp, Product1 = p };
        //    //var resultJoinOrderItem=from o in 


        //    //return View(resultJoin);

        //    return View();


        //}







        //var customers = _context.Customer1s.ToList();
        //var order = _context.Order1s.ToList();
        //var orderitem = _context.Orderitem1s.ToList();
        //var categoryproduct = _context.Categoryproduct1s.ToList();
        //var products = _context.Product1s.ToList();
        //var categoryStore = _context.Categorystore1s.ToList();
        //var store = _context.Store1s.ToList();


        //// join table 
        //var result = from c in customers
        //                 //order
        //             join o in order on c.Customerid equals o.Customerid
        //             join oi in orderitem on o.Orderitemid equals oi.Orderitemid
        //             //cart
        //             //join oi in orderitem on c.Customerid equals oi.Customerid

        //             join p in products on oi.Productid equals p.Productid
        //             join catp in categoryproduct on p.Categoryproductid equals catp.Categoryproductid
        //             join st in store on catp.Storeid equals st.Storeid
        //             join cats in categoryStore on st.Categorystoreid equals cats.Categoryid
        //             select new JoinTable { Customer1 = c, Order1 = o, Orderitem1 = oi, Product1 = p, Categoryproduct1 = catp, Store1 = st, Categorystore1 = cats };

        ////            var model = Tuple.Create<IEnumerable<Customer1>, IEnumerable<Product1>, IEnumerable<Orderitem1>,IEnumerable<Order1>, IEnumerable<Categoryproduct1>, IEnumerable<Store1>, IEnumerable<Categorystore1>, IEnumerable<JoinTable>>(customers, products, orderitem,order, categoryproduct, store, categoryStore, result);

        //var model = Tuple.Create<IEnumerable<Customer1>, IEnumerable<Product1>>(customers, products);
        //    return View(model);



        public IActionResult AboutUS()

        {
            if (HttpContext.Session.GetInt32("CustomerId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("CustomerId");

                int AdminId = (int)HttpContext.Session.GetInt32("CustomerId");

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();

                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;

                var x1 = _context.Contactus.Where(x => x.Id == 1).FirstOrDefault();
                ViewBag.phone = x1.Phone;
                ViewBag.email = x1.Email;

                var location = _context.Locations.ToList();
                var loc = _context.Locations.Where(x => x.Id == 1).SingleOrDefault();
                ViewBag.loc1url = loc.Locationanurl;
                ViewBag.loc1name = loc.Locationname;
                var loc2 = _context.Locations.Where(x => x.Id == 2).SingleOrDefault();
                ViewBag.loc2url = loc2.Locationanurl;
                ViewBag.loc2name = loc2.Locationname;



                var ourstory = _context.Ourstories.ToList();
                var ourstory1 = _context.Ourstories.Where(x => x.Id == 1).SingleOrDefault();
                ViewBag.story = ourstory1.Story;
                //////////////////////////////////////////////
                var delivery = _context.Deliveryinfos.Where(x => x.Id == 1).SingleOrDefault();
                ViewBag.deliverycharge = delivery.Deliverycharge;
                ViewBag.deliveryfree = delivery.Deliveryfreeabove;
                ViewBag.delivery3 = delivery.Numberofdaydelivery;
                /////////////////////////////////////////////////
                var worktime = _context.Worktimes.Where(x => x.Id == 1).SingleOrDefault();
                ViewBag.sunopen = worktime.SunThursdayopen;
                ViewBag.sunclose = worktime.SunThursdayclose;
                ViewBag.friopen = worktime.FriSatopen;
                ViewBag.friclose = worktime.FriSatclose;

                return View();
            }
            return View();
        }






        public IActionResult ContactUs()
        {

            if (HttpContext.Session.GetInt32("CustomerId") == null)
            {
                return NotFound();
            }

            if (HttpContext.Session.GetInt32("CustomerId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("CustomerId");

                int AdminId = (int)HttpContext.Session.GetInt32("CustomerId");

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();

                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;
          

            var x1 = _context.Contactus.Where(x => x.Id == 1).FirstOrDefault();
            ViewBag.phone = x1.Phone;
            ViewBag.email = x1.Email;

            var location = _context.Locations.ToList();
            var loc = _context.Locations.Where(x => x.Id == 1).SingleOrDefault();
            ViewBag.loc1url = loc.Locationanurl;
            ViewBag.loc1name = loc.Locationname;
            var loc2 = _context.Locations.Where(x => x.Id == 2).SingleOrDefault();
            ViewBag.loc2url = loc2.Locationanurl;
            ViewBag.loc2name = loc2.Locationname;


            var social = _context.Socialmedia1s.ToList();


            return View(social);  }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs([Bind("Id,Fname,Lname,Email,Phone,Message")] Contactusform contactusform)
        {

            //ViewBag.; 
            if (ModelState.IsValid)
            {
                _context.Add(contactusform);
                await _context.SaveChangesAsync();
                return View();
            }
            return View();
        }








        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", "Auth");
        }





        public IActionResult Invoice()
        {
              var x1 = _context.Contactus.Where(x => x.Id == 1).FirstOrDefault();
            ViewBag.phone = x1.Phone;
            ViewBag.email = x1.Email;
            var phone = x1.Phone;
            var email = x1.Email;
            var location = _context.Locations.ToList();
            var loc = _context.Locations.Where(x => x.Id == 1).SingleOrDefault();
            ViewBag.loc1url = loc.Locationanurl;
            ViewBag.loc1name = loc.Locationname;
            var loc2 = _context.Locations.Where(x => x.Id == 2).SingleOrDefault();
            ViewBag.loc2url = loc2.Locationanurl;
            ViewBag.loc2name = loc2.Locationname;

            if(HttpContext.Session.GetInt32("CustomerId") == null)
            {
                return NotFound();
            }


            if (HttpContext.Session.GetInt32("CustomerId") != null)
            {
                ViewBag.AdminId = HttpContext.Session.GetInt32("CustomerId");

                int AdminId = (int)HttpContext.Session.GetInt32("CustomerId");
                var customer = _context.Customer1s.ToList();

                var cus = _context.Customer1s.Where(x => x.Customerid == AdminId).SingleOrDefault();
                ViewBag.id = cus.Customerid;
                ViewBag.FName = cus.Fname;
                ViewBag.LName = cus.Lname;
                

                var Fname = cus.Fname;
                var Lname = cus.Lname;

                var customers = _context.Customer1s.Where(x => x.Customerid == AdminId).ToList();
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


                var TotalPrice = result.Sum(x => x.Orderitem1.Quantityitem * x.Orderitem1.Product.Price);
                ViewBag.TotalPrice = TotalPrice;

                var delivery = _context.Deliveryinfos.Where(x => x.Id == 1).SingleOrDefault();
                ViewBag.deliverycharge = delivery.Deliverycharge;
                ViewBag.deliveryfree = delivery.Deliveryfreeabove;
                ViewBag.delivery3 = delivery.Numberofdaydelivery;

                if (delivery.Deliveryfreeabove < TotalPrice)
                {
                    ViewBag.deliverycharge = 0;
                    ViewBag.total = TotalPrice;
                    ViewBag.totalOrder = TotalPrice;

                }
                else if (delivery.Deliveryfreeabove > TotalPrice)
                {
                    ViewBag.deliverycharge = delivery.Deliverycharge;
                    ViewBag.total = TotalPrice;
                    ViewBag.totalOrder = (delivery.Deliverycharge + TotalPrice);

                }


                return View(result);


            }
            return View();
        }


    }
}
