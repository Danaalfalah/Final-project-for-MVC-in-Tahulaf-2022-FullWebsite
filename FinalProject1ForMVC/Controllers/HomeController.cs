using FinalProject1ForMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject1ForMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModelContext _context;
        public HomeController(ILogger<HomeController> logger, ModelContext context)
        {
            _logger = logger;
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
            //var contactus = _context.Contactus.ToList();

            var slide = _context.Slidehomes.ToList();
            var store = _context.Store1s.ToList();
            var categorystore = _context.Categorystore1s.ToList();
            var categoryproduct = _context.Categoryproduct1s.ToList();
            var socialmedia = _context.Socialmedia1s.ToList();


            ////////////////// join table 2bfor gallarey 
            //var categoryproduct = _context.Categoryproduct1s.ToList();
            var products = _context.Product1s.ToList();
            var categoryStore = _context.Categorystore1s.ToList();
            //var store = _context.Store1s.ToList();

            var contactusform = _context.Contactusforms.ToList();



            var result = Tuple.Create<IEnumerable<Slidehome>, IEnumerable<Store1>, IEnumerable<Categorystore1>, IEnumerable<Categoryproduct1>, IEnumerable<Socialmedia1>,IEnumerable<Contactusform>>(slide, store, categorystore, categoryproduct, socialmedia, contactusform);
            return View(result);

        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        public IActionResult AboutUS()

        {
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





        public IActionResult ContactUs()
        {

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


            return View(social);
        }
        [HttpPost]
        
        public async Task<IActionResult> ContactUs([Bind("Id,Fname,Lname,Email,Phone,Message")] Contactusform contactusform)
        {

            //ViewBag.; 
            if (ModelState.IsValid)
            {
                _context.Add(contactusform);
                await _context.SaveChangesAsync();
                var social = _context.Socialmedia1s.ToList();
                return View(social);
            }
            return View();
        }







        public IActionResult Gallery()
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

            var categoryproduct = _context.Categoryproduct1s.ToList();
            var products = _context.Product1s.ToList();
            var categoryStore = _context.Categorystore1s.ToList();
            var store = _context.Store1s.ToList();

            var resultJoin = from p in products
                             join catp in categoryproduct on p.Categoryproductid equals catp.Categoryproductid
                             join s in store on catp.Storeid equals s.Storeid
                             join cats in categoryStore on s.Categorystoreid equals cats.Categoryid
                             select new JoinTAble2 {Categorystore1=cats ,Store1 = s, Categoryproduct1 = catp, Product1 = p };

            var include1 = _context.Categoryproduct1s.Include(p => p.Product1s).Include(p => p.Store);

            return View(resultJoin);
        }
        //************************************************
        //[HttpPost]
        //public IActionResult Gallery(string searchString)
        //{
            
        //    return View();

        //}
        //****************************************************


        ////// for contactus message
        //// GET: Contactusforms/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Contactusforms/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Fname,Lname,Email,Phone,Message")] Contactusform contactusform)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(contactusform);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(contactusform);
        //}





        public IActionResult cart()
        {
            if (HttpContext.Session.GetInt32("CustomerId") == null)
            {
                return RedirectToAction("login","Auth");
            }

                
            
            ////*******
            //var x1 = _context.Contactus.Where(x => x.Id == 1).FirstOrDefault();
            //ViewBag.phone = x1.Phone;
            //ViewBag.email = x1.Email;
            //var phone = x1.Phone;
            //var email = x1.Email;
            //var location = _context.Locations.ToList();
            //var loc = _context.Locations.Where(x => x.Id == 1).SingleOrDefault();
            //ViewBag.loc1url = loc.Locationanurl;
            //ViewBag.loc1name = loc.Locationname;
            //var loc2 = _context.Locations.Where(x => x.Id == 2).SingleOrDefault();
            //ViewBag.loc2url = loc2.Locationanurl;
            //ViewBag.loc2name = loc2.Locationname;

            return View();
        }

//****************************************************************************************************
        public IActionResult ShowProduct(int id)
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


        [HttpPost]
        public IActionResult ShowProduct(int id,string search)
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

            if(search !=null)
            {

                var search1 = resultJoin.Where(x => x.Categorystore1.Categoryname.Contains(search));
                var search2= resultJoin.Where(x => x.Store1.Storename.Contains(search));
                var search3 = resultJoin.Where(x => x.Categoryproduct1.Categoryproductname.Contains(search));
                var search4 = resultJoin.Where(x => x.Product1.Productname.Contains(search));
             
                //if(search1.Contains(search))
               
                ////var searchResult = resultJoin.Where(x => x.Categorystore1.Categoryname.Contains(search) = search1);
                //    return View(searchResult); 
            }
            
            return View(resultJoin);


          
           
        }





        public IActionResult ProductDetails( int id)
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




    }
}
