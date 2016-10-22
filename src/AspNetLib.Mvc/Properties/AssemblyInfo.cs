// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Web;
using AspNetLib.Mvc;

[assembly: AssemblyTitle("AspNetLib.Mvc.dll")]
[assembly: AssemblyDescription("AspNetLib.Mvc.dll")]

[assembly: InternalsVisibleTo("AspNetLib.Mvc.DataAnnotations")]
[assembly: InternalsVisibleTo("AspNetLib.Mvc.ModelBinding")]
[assembly: InternalsVisibleTo("AspNetLib.Mvc.ViewEngine")]
[assembly: InternalsVisibleTo("AspNetLib.Mvc.ViewEngine.Compilation")]
[assembly: InternalsVisibleTo("AspNetLib.Mvc.ViewEngine.WebForm")]
[assembly: InternalsVisibleTo("AspNetLib.Mvc.ViewEngine.Razor")]
[assembly: InternalsVisibleTo("AspNetLib.Mvc.Html")]
[assembly: PreApplicationStartMethod(typeof(PreApplicationStartCode), "Start")]
