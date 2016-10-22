// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Globalization;
using System.IO;
using System.Text;
using System.Web.Mvc.Properties;

namespace System.Web.Mvc.Html
{
    public static class RenderPartialExtensions
    {
        // Renders the partial view with the parent's view data and model
        public static void RenderPartial(this HtmlHelper htmlHelper, string partialViewName)
        {
            RenderPartialInternal(htmlHelper, partialViewName, htmlHelper.ViewData, null /* model */, htmlHelper.ViewContext.Writer, ViewEngines.Engines);
        }

        // Renders the partial view with the given view data and, implicitly, the given view data's model
        public static void RenderPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData)
        {
            RenderPartialInternal(htmlHelper, partialViewName, viewData, null /* model */, htmlHelper.ViewContext.Writer, ViewEngines.Engines);
        }

        // Renders the partial view with an empty view data and the given model
        public static void RenderPartial(this HtmlHelper htmlHelper, string partialViewName, object model)
        {
            RenderPartialInternal(htmlHelper, partialViewName, htmlHelper.ViewData, model, htmlHelper.ViewContext.Writer, ViewEngines.Engines);
        }

        // Renders the partial view with a copy of the given view data plus the given model
        public static void RenderPartial(this HtmlHelper htmlHelper, string partialViewName, object model, ViewDataDictionary viewData)
        {
            RenderPartialInternal(htmlHelper, partialViewName, viewData, model, htmlHelper.ViewContext.Writer, ViewEngines.Engines);
        }

        internal static void RenderPartialInternal(HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData, object model, TextWriter writer, ViewEngineCollection viewEngineCollection)
        {
            if (String.IsNullOrEmpty(partialViewName))
            {
                throw Error.ParameterCannotBeNullOrEmpty("partialViewName");
            }

            ViewDataDictionary newViewData = null;

            if (model == null)
            {
                if (viewData == null)
                {
                    newViewData = new ViewDataDictionary(htmlHelper.ViewData);
                }
                else
                {
                    newViewData = new ViewDataDictionary(viewData);
                }
            }
            else
            {
                if (viewData == null)
                {
                    newViewData = new ViewDataDictionary(model);
                }
                else
                {
                    newViewData = new ViewDataDictionary(viewData) { Model = model };
                }
            }

            ViewContext newViewContext = new ViewContext(htmlHelper.ViewContext, htmlHelper.ViewContext.View, newViewData, htmlHelper.ViewContext.TempData, writer);
            IView view = FindPartialView(newViewContext, partialViewName, viewEngineCollection);
            view.Render(newViewContext, writer);
        }

        internal static IView FindPartialView(ViewContext viewContext, string partialViewName, ViewEngineCollection viewEngineCollection)
        {
            ViewEngineResult result = viewEngineCollection.FindPartialView(viewContext, partialViewName);
            if (result.View != null)
            {
                return result.View;
            }

            StringBuilder locationsText = new StringBuilder();
            foreach (string location in result.SearchedLocations)
            {
                locationsText.AppendLine();
                locationsText.Append(location);
            }

            throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture,
                                                              MvcResources.Common_PartialViewNotFound, partialViewName, locationsText));
        }
    }
}
