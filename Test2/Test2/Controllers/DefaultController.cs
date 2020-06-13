using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test2.Services;

namespace Test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IDbService _dbService;
        public DefaultController(IDbService dbService)
        {
            _dbService = dbService;
        }
    }
}