#load "suave.fsx"

open Suave
open Suave.Operators
open Suave.Filters
open Suave.Html
let homePage =  
  p [] (text "Hello world!!")
  |> pageTemplate
let goodbyePage = 
  p [] (text "Goodbye world.")
  |> pageTemplate

let app =
    choose [
        path "/"        >=> Successful.OK homePage
        path "/goodbye" >=> Successful.OK goodbyePage
    ]

startWebServer defaultConfig app