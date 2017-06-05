#load "..\packages/FsLab/FsLab.fsx"
open FSharp.Data
open System.Linq
open System
let Priorities = CsvProvider<"C:\Temp\priorities.txt", IgnoreErrors=true>.GetSample()

let x = DateTime.Now

let priority =
  query {
    for t in Priorities.Rows do
    select (t.DueTime - DateTime.Now)
    where (not t.IsComplete)
  }
  |> Seq.map (fun (n:TimeSpan) -> n.TotalMinutes)
  |> Seq.sort
  |> Seq.toList

query {
  for t in Priorities.Rows do
  select (t.DueTime.ToShortDateString(), t.StartTime.ToShortDateString())
}
|> Seq.toList  