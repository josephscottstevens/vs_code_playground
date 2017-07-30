#load "../packages/FsLab/FsLab.fsx"
open Suave

startWebServer defaultConfig (Successful.OK "Hello World!")