﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieReview.Tests.UnitTests
{
   class FakeController :ControllerContext
    {
        private HttpContextBase _ctx = new FakeHttpContext();

        public override System.Web.HttpContextBase HttpContext
        {
            get
            {
                return _ctx;
            }
            set
            {
                _ctx = value;
            }
        }
    }

   class FakeHttpContext : HttpContextBase
    {
        HttpRequestBase _request = new FakeHttpRequest();

        public override HttpRequestBase Request
        {
            get
            {
                return _request;
            }          
        }
    }

   class FakeHttpRequest : HttpRequestBase
   {
       public override string this[string key]
       {
           get
           {
               return null;
           }
       }

       public override NameValueCollection Headers
       {
           get
           {
               return new NameValueCollection();
           }
       }
   }
}
