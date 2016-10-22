// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.ComponentModel;
using System.Web.Mvc;

namespace AspNetLib.Mvc.DataAnnotations
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

            Mvc.PreApplicationStartCode.Start();

            ModelMetadataProviders.Current = new CachedDataAnnotationsModelMetadataProvider();
            ModelValidatorProviders.Providers.Insert(0, new DataAnnotationsModelValidatorProvider());
        }
    }
}
