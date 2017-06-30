#load "..\packages/FsLab/FsLab.fsx"
open FSharp.Data


let url = "https://testfakebusiness.myshopify.com/admin/orders.json"
let user = "7ddfed25fb5df262b1549d200e96b645"
let pass = "fca889a624cd6e5c591c5567d588397a"
let responseStr = Http.RequestString(url, headers = [ HttpRequestHeaders.Accept HttpContentTypes.Json; HttpRequestHeaders.BasicAuth user pass ])

type OrdersType = JsonProvider<"""C:\Repos\vs_code_playground\shopify\orders.json""">
let Orders = OrdersType.Load(responseStr)

query {
    for t in Orders do
    select t.Confirmed
}
|> Seq.toList