#r "../packages/Suave/lib/net40/Suave.dll"
open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful

let x = 
    request (fun r -> OK (r.rawQuery))
let sample : WebPart = 
    path "/" >=> x

startWebServer defaultConfig sample