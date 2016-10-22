AspNetLib
=========
AspNetLib is a fork of ASP.NET MVC 5 that splits the codebase into smaller projects for easier reuse. You can use it to add features to your own framework. Type names and namespaces are not changed, and breaking changes are kept to an absolute minimum.

Packages
--------
Packages can depend on ancestor or sibling, but not on descendant packages. For example, AspNetLib.Mvc.ModelBinding depends on AspNetLib.Mvc, not the other way around.

### AspNetLib.Mvc

Includes the core types that make up the bones of the framework, such as ControllerContext, ViewContext, ModelMetadata, ViewDataDictionary and HtmlHelper. It also includes utilities like SelectList and TagBuilder. *Anything related to controllers is NOT included*.

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

View engine classes.

Depends on:

- AspNetLib.Mvc

### AspNetLib.Mvc.ViewEngine.Compilation

Classes that support compiled view engines, integrates with the System.Web.Compilation namespace.

Depends on:

- AspNetLib.Mvc
- AspNetLib.Mvc.ViewEngine

### AspNetLib.Mvc.ViewEngine.Razor

Razor view engine.

Depends on:

- AspNetLib.Mvc
- AspNetLib.Mvc.ViewEngine
- AspNetLib.Mvc.ViewEngine.Compilation
- Microsoft.AspNet.WebPages

### AspNetLib.Mvc.ViewEngine.WebForm

Webform view engine.

Depends on:

- AspNetLib.Mvc
- AspNetLib.Mvc.ViewEngine
- AspNetLib.Mvc.ViewEngine.Compilation

### AspNetLib.Mvc.Html

Html helpers.

Depends on:

- AspNetLib.Mvc
- AspNetLib.Mvc.ViewEngine

### AspNetLib.AntiXsrf

Anti-forgery classes from WebPages.

### AspNetLib.BrowserOverriding

Browser overriding feature from WebPages.