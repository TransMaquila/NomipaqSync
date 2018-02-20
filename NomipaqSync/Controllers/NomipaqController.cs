using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NomipaqSync.Models;

namespace NomipaqSync.Controllers
{
    [Produces("application/json")]
    [Route("api/Syncronize")]
    public class SyncronizeController : Controller
    {


        // GET: api/Nomipaq
        [HttpGet]
        public int Get()
        {
            // return new string[] { "value1", "value2" };
            return Nomipaq.Syncronize();
        }

    }

    [Produces("application/json")]
    [Route("api/transfer")]
    public class TransferController : Controller
    {


        // GET: api/Nomipaq
        [HttpGet]
        public int Get()
        {
            // return new string[] { "value1", "value2" };
            return Nomipaq.Transfer(7, 2018);
        }

    }

}
