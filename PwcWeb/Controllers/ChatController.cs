using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PwcWeb.Models;
using PwcWeb.Models.Response;
using PwcWeb.Models.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwcWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private MyDBContext db;
        public ChatController(MyDBContext context)
        {
            db = context;
        }
        [HttpGet("[action]")]
        public IEnumerable<MessageViewModel> Message()
        {
            List<MessageViewModel> lst = (from d in db.Message
                                          orderby d.Id descending
                                          select new MessageViewModel
                                          {
                                              Id = d.Id,
                                              Name = d.Name,
                                              Text = d.Text
                                          }).ToList();
            return lst;
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody] MessageViewModel model)
        {
            MyResponse oR = new MyResponse();
            try
            {
                Message oMessage = new Message();
                oMessage.Name = model.Name;
                oMessage.Text = model.Text;
                db.Message.Add(oMessage);
                db.SaveChanges();
                oR.Success = 1;
            }
            catch (Exception ex)
            {
                oR.Success = 0;
                oR.Message = ex.ToString();
            }
            return oR;
        }
    }
}
