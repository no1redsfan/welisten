// <copyright file="HtmlHelpers.cs" company="University of Cincinnati">
// Copyright (c) 2012. All rights reserved.
// </copyright>
// <author>Jimmy McDonough</author>
// <summary>The HtmlHelpers.cs source file. Created: 10/05/2012 9:50 AM
// Last modified: 10/05/2012 9:54 AM
// </summary> 

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace WeListen.Web.Helpers
{
    /// <summary>
    /// Contains helper methods for <see cref="HtmlHelper"/>.
    /// </summary>
    public static class HtmlHelpers
    {
        /// <summary>
        /// Creates a HTML image tag.
        /// </summary>
        /// <param name="helper">The HtmlHelper.</param>
        /// <param name="imagePath">The relative image path.</param>
        /// <param name="alt">The alt text for the image.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>
        /// A HTML image tag.
        /// </returns>
        public static MvcHtmlString Image(this HtmlHelper helper, string imagePath, string alt,
                                          object htmlAttributes = null)
        {
            UrlHelper url = new UrlHelper(helper.ViewContext.RequestContext);
            var imageBuilder = new TagBuilder("img");
            imageBuilder.MergeAttribute("src", url.Content(imagePath));
            imageBuilder.MergeAttribute("alt", alt);
            imageBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(imageBuilder.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        /// Creates a link for a CSS file.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="fileName">The file.</param>
        /// <returns>A CSS link tag.</returns>
        public static MvcHtmlString Css(this HtmlHelper helper, string fileName)
        {
            return Css(helper, fileName, "screen");
        }

        /// <summary>
        /// Creates a link for a CSS file.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="fileName">The file.</param>
        /// <param name="media">The media type.</param>
        /// <returns>A CSS link tag.</returns>
        public static MvcHtmlString Css(this HtmlHelper helper, string fileName, string media)
        {
            if (!fileName.EndsWith(".css"))
            {
                fileName += ".css";
            }

            var url = new UrlHelper(helper.ViewContext.RequestContext);
            TagBuilder builder = new TagBuilder("link");
            builder.MergeAttribute("rel", "stylesheet");
            builder.MergeAttribute("type", "text/css");
            builder.MergeAttribute("href", url.Content(fileName));
            builder.MergeAttribute("media", media);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        /// Creates a script tag for the given JavaScript file name.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>A script tag for the JavaScript file name.</returns>
        public static MvcHtmlString Script(this HtmlHelper helper, string fileName)
        {
            var url = new UrlHelper(helper.ViewContext.RequestContext);
            TagBuilder builder = new TagBuilder("script");
            builder.MergeAttribute("type", "text/javascript");
            builder.MergeAttribute("src", url.Content(fileName));
            return MvcHtmlString.Create(builder.ToString());
        }

        /// <summary>
        /// Retrieves a single strongly-typed value from the ViewData.
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <returns>A strongly-typed value.</returns>
        public static T GetViewDataValue<T>(this HtmlHelper helper, string name)
        {
            if (helper.ViewData[name] != null)
            {
                try
                {
                    return (T) helper.ViewData[name];
                }
                catch (InvalidCastException)
                {
                    return default(T);
                }
            }

            return default(T);
        }

        /// <summary>
        /// Retrieves a strongly-typed IEnumerable object from the ViewData.
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <returns>A strongly-typed IEnumerable object.</returns>
        public static IEnumerable<T> GetViewDataEnumerableValue<T>(this HtmlHelper helper, string name)
        {
            if (helper.ViewData[name] != null)
            {
                try
                {
                    return (IEnumerable<T>) helper.ViewData[name];
                }
                catch (InvalidCastException)
                {
                    return new List<T>();
                }
            }

            return new List<T>();
        }

        /// <summary>
        /// Retrieves a strongly-typed IList object from the ViewData.
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <returns>A strongly-typed IList object.</returns>
        public static IList<T> GetViewDataListValue<T>(this HtmlHelper helper, string name)
        {
            if (helper.ViewData[name] != null)
            {
                try
                {
                    return (IList<T>) helper.ViewData[name];
                }
                catch (InvalidCastException)
                {
                    return new List<T>();
                }
            }

            return new List<T>();
        }
    }
}