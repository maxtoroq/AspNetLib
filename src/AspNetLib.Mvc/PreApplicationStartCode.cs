// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.ComponentModel;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.WebPages;
using System.Web.WebPages.Scope;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace AspNetLib.Mvc
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

            // Turn off the string resource behavior which would not work in our simple base page
            PageParser.EnableLongStringsAsResources = false;

            ScopeStorage.CurrentProvider = new AspNetRequestScopeStorageProvider();

            DynamicModuleUtility.RegisterModule(typeof(WebPageHttpModule));

            ViewContext.GlobalScopeThunk = () => ScopeStorage.CurrentScope;
        }
    }
}
