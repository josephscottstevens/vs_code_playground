open System.IO
open System.Text.RegularExpressions

let root = """C:\Projects\NavCare\HC360-Integration-BillingEnhancements\trunk\Care-24-7\Care-24-7-MVC\"""
let csproj = File.ReadAllText(root + "Care-24-7-MVC.csproj")

let pattern = """Include=\"([-\w\\\. ]+)\" ?"""

File.Exists(root + """App_Start\BundleConfig.cs""")

let matches = 
  Regex.Matches(csproj, pattern)
  |> Seq.cast<Match>
  |> Seq.map (fun t -> t.Groups.[1].Value)
  |> Seq.filter (fun t -> File.Exists(root + t) = false)
  |> Seq.toList