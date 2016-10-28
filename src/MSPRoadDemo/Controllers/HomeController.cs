using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using MSPRoadDemo.Models;
using MSPRoadDemo.VkApi;

namespace MSPRoadDemo
{
    public class HomeController : Controller
    {
        [("In")]
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Generate(DrawingRequest request, IVkApi vkApi)
        {
            var notparseIds = request.Post.Split(new [] {"wall"}, StringSplitOptions.None)[1];
            var ids = notparseIds.Split('_');
            int ownerid;
            int postid;
            if (!int.TryParse(ids[0], out ownerid))
            {
                return BadRequest();
            }
            if (!int.TryParse(ids[1], out postid))
            {
                return BadRequest();
            }

            var reposts = await vkApi.GetReposts(ownerid, postid);
            var peoples = new List<string>();
            for (int i = 0; i < request.Count; i++)
            {
                
            }
            return View();

        }
    }
}
