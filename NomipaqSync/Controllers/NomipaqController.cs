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
    [Route("nomipaq/syncronize")]
    public class SyncronizeController : Controller
    {


        // GET: api/Nomipaq
        [HttpGet]
        public async Task<string> Get()
        {
            // return new string[] { "value1", "value2" };
            return await Nomipaq.Syncronize();
        }

    }

    [Produces("application/json")]
    [Route("nomipaq/transfer")]
    public class TransferController : Controller
    {


        // GET: api/Nomipaq
        [HttpGet]
        public async Task<string> Get()
        {
            // return new string[] { "value1", "value2" };
            return await Nomipaq.Transfer();
        }

    }

}
