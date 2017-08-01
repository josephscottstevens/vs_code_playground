#r "../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
open FSharp.Data
open System.Linq
open System
let Priorities = CsvProvider<"C:\Temp\priorities.txt", IgnoreErrors=true>.GetSample()

let priority =
  query {
    for t in Priorities.Rows do
    where (t.IsComplete = 1)
    select (t.DueTime - DateTime.Now)
  }
  |> Seq.map (fun (n:TimeSpan) -> n.TotalMinutes)
  |> Seq.sort
  |> Seq.toList

query {
  for t in Priorities.Rows do
  select (t.DueTime.ToShortDateString(), t.StartTime.ToShortDateString())
}
|> Seq.toList  