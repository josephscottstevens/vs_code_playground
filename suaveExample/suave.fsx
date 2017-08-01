#r "../packages/Suave/lib/net40/Suave.dll"
#r "../packages/Suave.Experimental/lib/net40/Suave.Experimental.dll"
#r "../packages/SQLProvider/lib/FSharp.Data.SqlProvider.dll"
open Suave.Html
open FSharp.Data.Sql


let pageTemplate inner =
  html [] [
    head [] [
      title [] "Little HTML DSL"
      link [ "rel", "https://instabt.com/instaBT.ico" ]
      script [ "type", "text/javascript"; "src", "js/jquery-2.1.0.min.js" ] []
      script [ "type", "text/javascript" ] (rawText "$().ready(function () { setup(); });" )
    ]
    body [] [
      inner
    ]
  ]
  |> htmlToString