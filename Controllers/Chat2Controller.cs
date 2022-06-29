using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Xml;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ChatBotCenterAPI.Controllers
{
    public class Chat2Controller : Controller
    {
        //public Chat2Controller(IConfiguration _config, IHttpContextAccessor _context)
        //{
        //    string xx = "";
        //}

        private static readonly HttpClient client = new HttpClient();

        public class ClsParamGetListChat
        {
            public string symbol_name { get; set; } = "";
        }

        [HttpPost("[controller]/GetListChat")]
        public async Task<IActionResult> GetListChat([FromBody] ClsParamGetListChat param)
        {
            var responseString = "";

            try
            {
                var values = new Dictionary<string, string>
                  {
                      { "key", "@eft" },
                      { "cmd", "005" },
                      { "param", param.symbol_name }
                  };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("https://demo.efinancethai.com/smartWS/service.asmx/ReturnValue", content);

                var strRet = await response.Content.ReadAsStringAsync();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(strRet);
                strRet = doc.InnerText;

                if (strRet != "") {
                    var arrStr = strRet.Split(";");
                    Dictionary<string, string> Dict = new Dictionary<string, string>();
                    Dict.Add("symbol_name", arrStr[0]);
                    Dict.Add("value", arrStr[1]);

                    responseString = JsonConvert.SerializeObject(Dict);
                }
                

            }
            catch (Exception ex)
            {

            }
            return Ok(responseString);
        }
    }
}
