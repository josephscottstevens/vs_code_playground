#r "../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
open FSharp.Data

type JsonType = JsonProvider<"rows.json">
let json = JsonType.Load("https://data.mo.gov/api/views/8zvy-7azn/rows.json")

let x = json.Meta.View.DownloadCount