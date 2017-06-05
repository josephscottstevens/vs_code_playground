#load "..\packages/FsLab/FsLab.fsx"
open FSharp.Data
open System.Linq

type ICD10DXCodes = CsvProvider<"C:\Temp\ICD10_DX_Codes.csv">

let ICD10 = new ICD10DXCodes()

let x =
  query {
    for t in ICD10.Rows do
    groupBy t.``NF EXCLUDE`` into g
    select g.Key
  }
  |> Seq.toList