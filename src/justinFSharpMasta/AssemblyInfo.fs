﻿namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("justinFSharpMasta")>]
[<assembly: AssemblyProductAttribute("justinFSharpMasta")>]
[<assembly: AssemblyDescriptionAttribute("A self contained basic load testing tool")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"
