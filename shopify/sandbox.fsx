#load "..\packages/FsLab/FsLab.fsx"
open FSharp.Data

type OrdersType = JsonProvider<"""C:\Repos\vs_code_playground\shopify\orders.json""">
let Orders = OrdersType.Load("""C:\Repos\vs_code_playground\shopify\orders.json""").Orders

query {
    for t in Orders do
    select t.Email
}
|> Seq.toList

query {
    for t in Orders do
    select t.Confirmed
}
|> Seq.toList