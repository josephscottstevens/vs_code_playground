#load "..\packages/FsLab/FsLab.fsx"
open FSharp.Data

let wbReq = "https://www.healthdata.gov/api/3/action/package_show?id=c16c2f1b-6401-45de-be67-86ff81e5c683"

let docAsync = WorldBank.AsyncLoad(wbReq)