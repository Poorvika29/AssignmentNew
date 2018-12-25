using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Common;

namespace WebApi.Controllers
{
    public class Part77Controller : Controller
    {
        // GET: Part77
        [TrackExecutionTimeP77]
        public string Index()
        {
            return "Index Action Invoked";
        }

        [TrackExecutionTimeP77]
        public string Welcome()
        {
            throw new Exception("Exception ocuured");
        }
    }
}