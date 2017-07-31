#r "../packages/Suave/lib/net40/Suave.dll"
#r "../packages/Suave.Experimental/lib/net40/Suave.Experimental.dll"
open Suave
open Suave.Operators
open Suave.Successful
open Suave.Filters
open Suave.Html

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
let homePage = 
  p [] (text "Hello world.")
  |> pageTemplate

let goodbyePage = 
  p [] (text "Goodbye world.")
  |> pageTemplate

let app =
    choose [
        path "/"        >=> OK homePage
        path "/goodbye" >=> OK goodbyePage
    ]

startWebServer defaultConfig app