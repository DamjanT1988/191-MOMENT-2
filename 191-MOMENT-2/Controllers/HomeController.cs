using _191_MOMENT_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Runtime.Intrinsics.X86;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using System.Reflection;

namespace _191_MOMENT_2.Controllers
{
    //use controlles base class from AspNetCore library
    public class HomeController : Controller
    {
        //--CONSTRUCTORS
       

        //--VIEWS AND ROUTES ACTIONS

        //control route directly with [Route]
        //name same view folder as controller name standard = Home -> Home, then no
        //specification is needed
        [Route("/")]
        //to page/view
        public IActionResult Index()
        {
            //set cookie and session value
            HttpContext.Response.Cookies.Append("UserToken", "753951");
            HttpContext.Session.SetString("Session1", "the user has visited start page!");

            //read text from file, store in a variable as JSON-string
            var jsonString = System.IO.File.ReadAllText(Directory.GetCurrentDirectory().ToString() + "/productstorage.json");
            //convert to list based on model, to loop through, then input json string
            var jsonObject = JsonConvert.DeserializeObject<List<ProductModel>>(jsonString);

            //reverse order
            jsonObject.Reverse();

            //return list to edit
            ViewBag.MyList = jsonObject;

            //must return av view
            return View(new ProductModel { product_title = "Test 1" });
        }

        //[Route("/add")]
        [HttpGet("/add")]
        //to page/view
        public IActionResult Add()
        {
            //get session value
            string userToken = HttpContext.Request.Cookies["UserToken"];
            ViewBag.cookiecontent = userToken;
            ViewBag.sessioncontent = HttpContext.Session.GetString("Session1");
            
            return View();
        }

        //[Route("/edit")]
        [HttpGet("/edit")]
        //to page/view
        public IActionResult Edit()
        {
            //read text from file, store in a variable as JSON-string
            var jsonString = System.IO.File.ReadAllText(Directory.GetCurrentDirectory().ToString() + "/productstorage.json");
            //convert to list based on model, to loop through, then input json string
            var jsonObject = JsonConvert.DeserializeObject<List<ProductModel>>(jsonString);

            //reverse order
            jsonObject.Reverse();

            ViewData["List"] = jsonObject;

            return View();
        }



        //--HTTPS ACTIONS
        
        //listen only to post calls
        [HttpPost("/add")]
        //use product model at post
        public IActionResult Add(ProductModel model)
        {


            //control if form´is correctly filled
            if (ModelState.IsValid)
            {
                //correct filled
                //read text from file, store in a variable as JSON-string
                var jsonString = System.IO.File.ReadAllText(Directory.GetCurrentDirectory().ToString() + "/productstorage.json");
                //convert to list based on model, to loop through, then input json string
                var jsonObject = JsonConvert.DeserializeObject<List<ProductModel>>(jsonString);

                //control
                if (jsonObject != null)
                {
                    //add json object at bottom of list
                    jsonObject.Add(model);
                    //write the JSON list to a file
                    System.IO.File.WriteAllText(@Directory.GetCurrentDirectory().ToString() + "/productstorage.json", JsonConvert.SerializeObject(jsonObject, Formatting.Indented));
                    //clear form
                    ModelState.Clear();
                
                }

            }

            return View();
        }

        //listen only to post calls
        [HttpPost("/edit")]
        //use product model at post
        public IActionResult Edit(ProductModel model)
        {
            //control if form´is correctly filled
            if (ModelState.IsValid)
            {
                //correct filled
                //read text from file, store in a variable as JSON-string
                var jsonString = System.IO.File.ReadAllText(Directory.GetCurrentDirectory().ToString() + "/productstorage.json");
                //convert to list based on model, to loop through, then input json string
                var jsonObject = JsonConvert.DeserializeObject<List<ProductModel>>(jsonString);

                //control
                if (jsonObject != null)
                {
                    //add json object at bottom of list
                    jsonObject.Add(model);
                    //write the JSON list to a file
                    System.IO.File.WriteAllText(@Directory.GetCurrentDirectory().ToString() + "/productstorage.json", JsonConvert.SerializeObject(jsonObject, Formatting.Indented));

                    //correct filled
                    //read text from file, store in a variable as JSON-string
                    var jsonString2 = System.IO.File.ReadAllText(Directory.GetCurrentDirectory().ToString() + "/productstorage.json");
                    //convert to list based on model, to loop through, then input json string
                    var jsonObject2 = JsonConvert.DeserializeObject<List<ProductModel>>(jsonString2);

                    //reverse order
                    jsonObject2.Reverse();

                    //return list
                    ViewData["List"] = jsonObject2;
                }

            }

            return View();
        }



        //--ERROR MANAGEMENT

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}