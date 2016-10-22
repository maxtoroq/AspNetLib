// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace System.Web.Mvc
{
    [SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable", Justification = "It is not anticipated that users will need to serialize this type.")]
    [SuppressMessage("Microsoft.Design", "CA1035:ICollectionImplementationsHaveStronglyTypedMembers", Justification = "It is not anticipated that users will call FormCollection.CopyTo().")]
    [FormCollectionBinder]
    public sealed class FormCollection : NameValueCollection, IValueProvider
    {
        public FormCollection()
        {
        }

        public FormCollection(NameValueCollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            Add(collection);
        }

        internal FormCollection(
#if ASPNETMVC
                ControllerBase controller,
#else
                ControllerContext controllerContext,
#endif
                Func<NameValueCollection> validatedValuesThunk,
                Func<NameValueCollection> unvalidatedValuesThunk)
        {
            Add(
#if ASPNETMVC
                controller == null || controller.ValidateRequest ?
#else
                controllerContext.ValidateRequest ?
#endif
                validatedValuesThunk()
                : unvalidatedValuesThunk()
            );
        }

        public ValueProviderResult GetValue(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            string[] rawValue = GetValues(name);
            if (rawValue == null)
            {
                return null;
            }

            string attemptedValue = this[name];
            return new ValueProviderResult(rawValue, attemptedValue, CultureInfo.CurrentCulture);
        }

        public IValueProvider ToValueProvider()
        {
            return this;
        }

        #region IValueProvider Members

        bool IValueProvider.ContainsPrefix(string prefix)
        {
            return ValueProviderUtil.CollectionContainsPrefix(AllKeys, prefix);
        }

        ValueProviderResult IValueProvider.GetValue(string key)
        {
            return GetValue(key);
        }

        #endregion

        private sealed class FormCollectionBinderAttribute : CustomModelBinderAttribute
        {
            // since the FormCollectionModelBinder.BindModel() method is thread-safe, we only need to keep
            // a single instance of the binder around
            private static readonly FormCollectionModelBinder _binder = new FormCollectionModelBinder();

            public override IModelBinder GetBinder()
            {
                return _binder;
            }

            // this class is used for generating a FormCollection object
            private sealed class FormCollectionModelBinder : IModelBinder
            {
                public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
                {
                    if (controllerContext == null)
                    {
                        throw new ArgumentNullException("controllerContext");
                    }

                    return new FormCollection(
#if ASPNETMVC
                                              controllerContext.Controller,
#else
                                              controllerContext,
#endif
                                              () => controllerContext.HttpContext.Request.Form,
                                              () => controllerContext.HttpContext.Request.Unvalidated.Form);
                }
            }
        }
    }
}
