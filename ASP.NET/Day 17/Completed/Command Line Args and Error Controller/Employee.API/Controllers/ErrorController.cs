﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Controllers
{
 
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/api/error")]
        public IActionResult Error() => Problem();
    }
}
