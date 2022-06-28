using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotCenterAPI.Controllers
{
    public class Chat2Controller : Controller
    {
        //public Chat2Controller(IConfiguration _config, IHttpContextAccessor _context)
        //{
        //    string xx = "";
        //}

        public class ClsParamGetListChat
        {
            public string user_id { get; set; } = "";
        }

        [HttpPost("[controller]/GetListChat")]
        public async Task<IActionResult> GetListChat([FromBody] ClsParamGetListChat param)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return Ok("hello");
        }
    }
}
