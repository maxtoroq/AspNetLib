// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.ComponentModel;
using System.Web.Mvc;

namespace AspNetLib.Mvc.ViewEngine.Razor
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class PreApplicationStartCode
    {
        private static bool _startWasCalled;

        public static void Start()
        {
            // Guard against multiple calls. All Start calls are made on same thread, so no lock needed here
            if (_startWasCalled)
            {
                return;
            }
            _startWasCalled = true;

            System.Web.WebPages.Razor.PreApplicationStartCode.Start();
            System.Web.WebPages.PreApplicationStartCode.Start();
            Mvc.PreApplicationStartCode.Start();

            ViewEngines.Engines.Insert(0, new RazorViewEngine());
        }
    }
}
