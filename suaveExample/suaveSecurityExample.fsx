#load "suave.fsx"

open System
open System.Net
open Suave
open Suave.Logging
open Suave.Logging.Message
open Suave.Cookie
open Suave.State.CookieStateStore
open Suave.Operators
open Suave.Successful
open Suave.Filters
open Suave.RequestErrors
open Suave.Authentication
open Suave.Html

let homePage =  
  p [] (text "Hello world.")
  |> pageTemplate
let goodbyePage = 
  p [] (text "Goodbye world.")
  |> pageTemplate

let app =
    choose[
      path "/" >=> OK "root"
      path "/auth" >=> authenticated Session false >=> OK "authed"
      path "/deauth" >=> deauthenticate >=> OK "deauthed"
      path "/protected" >=> authenticate Session false
                               (fun () -> Choice2Of2(FORBIDDEN "please authenticate"))
                               (fun _ ->  Choice2Of2(BAD_REQUEST "did you fiddle with our cipher text?"))
                               (OK "You have reached the place of your dreams!")
    ]
startWebServer defaultConfig app