#r "../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
open FSharp.Data
1
let trending = HtmlProvider<"https://github.com/search?q=trending&ref=opensearch">.GetSample()
let x = 
    trending.Tables.``Basic search``.Rows
    |> Seq.map (fun t -> t.``Finds repositories with…``)
    |> Seq.toList