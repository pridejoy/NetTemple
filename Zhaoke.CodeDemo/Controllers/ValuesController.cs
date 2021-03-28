using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zhaoke.CodeDemo.Controllers
{
    public class ValuesController : Controller
    {
        private ISingTest sing; ITranTest tran; ISconTest scon; IAService aService;
        public ValuesController(ISingTest sing, ITranTest tran, ISconTest scon, IAService aService)
        {
            this.sing = sing;
            this.tran = tran;
            this.scon = scon;
            this.aService = aService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> SetTest()
        {
            sing.Age = 18;
            sing.Name = "小红";

            tran.Age = 19;
            tran.Name = "小明";

            scon.Age = 20;
            scon.Name = "小蓝";

            aService.RedisTest();


            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
