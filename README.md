AspNetLib
=========
AspNetLib is a fork of ASP.NET MVC 5 that splits the codebase into smaller projects for easier reuse. You can use it to add features to your own framework. Type names and namespaces are not changed, and breaking changes are kept to an absolute minimum.

Packages
--------
Packages can depend on ancestor or sibling, but not on descendant packages. For example, AspNetLib.Mvc.ModelBinding depends on AspNetLib.Mvc, not the other way around.

### AspNetLib.Mvc

Includes the core types that make up the bones of the framework, such as ControllerContext, ViewContext, ModelMetadata, ViewDataDictionary and HtmlHelper. It also includes utilities like SelectList and TagBuilder. **Anything related to controllers is NOT included**.

Depends on:

- AspNetLib.BrowserOverriding (Display modes require this)

### AspNetLib.Mvc.ModelBinding

Model binding abstractions and implementations. Includes types like IModelBinder, IValueProvider, DefaultModelBinder and BindAttribute.

Depends on:

- AspNetLib.Mvc

### AspNetLib.Mvc.DataAnnotations

Implementation classes that integrate with the System.ComponentModel.DataAnnotations namespace. If you don't use this package annotations are completely ignored for metadata and validation.

Depends on:

- AspNetLib.Mvc

### AspNetLib.Mvc.ViewEngine

View engine abstractions. Includes types like IViewEngine, IView and ViewEngines.

Depends on:

- AspNetLib.Mvc

### AspNetLib.Mvc.ViewEngine.Compilation

Classes that support compiled view engines, integrates with the System.Web.Compilation namespace. Includes types like BuildManagerViewEngine and BuildManagerCompiledView.

Depends on:

- AspNetLib.Mvc
- AspNetLib.Mvc.ViewEngine

### AspNetLib.Mvc.ViewEngine.Razor

Razor view engine. Includes types like RazorViewEngine, RazorView and WebViewPage.

Depends on:

- AspNetLib.Mvc
- AspNetLib.Mvc.ViewEngine
- AspNetLib.Mvc.ViewEngine.Compilation
- Microsoft.AspNet.WebPages

### AspNetLib.Mvc.ViewEngine.WebForm

Webform view engine. Includes types like WebFormViewEngine, WebFormView and ViewPage.

Depends on:

- AspNetLib.Mvc
- AspNetLib.Mvc.ViewEngine
- AspNetLib.Mvc.ViewEngine.Compilation

### AspNetLib.Mvc.Html

Html helpers (extension methods). Includes types in System.Web.Mvc.Html and System.Web.Mvc.Ajax namespaces.

Depends on:

- AspNetLib.Mvc
- AspNetLib.Mvc.ViewEngine

### AspNetLib.AntiXsrf

Anti-forgery feature from WebPages. Includes types like AntiForgery and HttpAntiForgeryException.

### AspNetLib.BrowserOverriding

Browser overriding feature from WebPages. Includes types like BrowserHelpers and BrowserOverrideStore.

Breaking changes
----------------

### ControllerContext and ViewContext

In ASP.NET MVC, ControllerBase depends on ControllerContext and ControllerContext depends on ControllerBase. The same for IView: IView depends on ViewContext and ViewContext depends on IView. This circular dependency is not only not necessary, it makes it hard to decouple controllers and views from the rest of the framework. For these reasons, in AspNetLib ControllerContext no longer depends on ControllerBase and ViewContext no longer depends on IView.
