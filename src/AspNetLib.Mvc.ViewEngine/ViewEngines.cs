// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Web.Mvc
{
    public static class ViewEngines
    {
        private static readonly ViewEngineCollection _engines = new ViewEngineCollection
        {
#if ASPNETMVC
            new WebFormViewEngine(),
            new RazorViewEngine(),
#endif
        };

        public static ViewEngineCollection Engines
        {
            get { return _engines; }
        }
    }
}
