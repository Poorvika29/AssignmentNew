﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.CustomHtmlHelpers
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            // Build <img> tag
            TagBuilder tb = new TagBuilder("img");
            // Add "src" attribute
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            // Add "alt" attribute
            tb.Attributes.Add("alt", alt);
           
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}