#load "..\packages/FsLab/FsLab.fsx"
open FSharp.Charting
open Deedle
open FSharp.Data
open XPlot.GoogleCharts
open XPlot.GoogleCharts.Deedle

type NugetStats = HtmlProvider<"https://www.nuget.org/packages/FSharp.Data">

// load the live package stats for FSharp.Data

let rawStats = NugetStats().Tables.``Version History``


// helper function to analyze version numbers from nuget
let getMinorVersion v = System.Text.RegularExpressions.Regex(@"\d.\d").Match(v).Value

query {
  for t in rawStats.Rows do
  where (t.Downloads > 1000m)
  select t.Downloads
}
|> Seq.toList

let stats = 
  rawStats.Rows
  |> Seq.groupBy (fun r -> getMinorVersion r.Version)
  |> Seq.map (fun (k, xs) -> k, xs |> Seq.sumBy (fun x -> x.Downloads))
      
Chart.Bar stats