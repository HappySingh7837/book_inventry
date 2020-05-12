using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Inventory.App_Code;
using Inventory.Models;
namespace Inventory.api
{
    public class UserController : ApiController
    {
        ClsUsers users = new ClsUsers();
        List<ModelBooks> lstUser = new List<ModelBooks>();
        String Message { get; set; }
        ModelBooks modelUsers { get; set; }

        [HttpPost]
        public String Create(ModelBooks modelBooks)
        {
            users.Create(modelBooks);
            return users.Message;
        }

        [HttpGet]
        public List<ModelBooks> Get()
        {
            lstUser = new List<Models.ModelBooks>();
            lstUser = users.Get("");
            Message = users.Message;
            return lstUser;
        }
        [HttpGet]
        public List<ModelBooks> Get(String Search)
        {
            lstUser = new List<Models.ModelBooks>();
            lstUser = users.Get(Search);
            Message = users.Message;
            return lstUser;
        }
        public string Delete(Int32 BookID)
        {
            users.Delete(BookID);
            return users.Message;
        }
    }
}
