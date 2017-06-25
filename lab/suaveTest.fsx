#load "..\packages/FsLab/FsLab.fsx"
open FSharp.Data
open Suave

startWebServer defaultConfig (Successful.OK "Hello World!")