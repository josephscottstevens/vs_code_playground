#r "../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
open FSharp.Data
1
let trending = HtmlProvider<"https://www.rottentomatoes.com/top/bestofrt/top_100_science_fiction__fantasy_movies/">.GetSample()
let x = 
    trending.Tables.``Best of Rotten Tomatoes``.Rows
    |> Seq.map (fun t -> t.Title)