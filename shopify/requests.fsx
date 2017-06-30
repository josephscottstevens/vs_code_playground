#load "..\packages/FsLab/FsLab.fsx"
open FSharp.Data

let url = "https://testfakebusiness.myshopify.com/admin/orders.json"
let user = "7ddfed25fb5df262b1549d200e96b645"
let pass = "fca889a624cd6e5c591c5567d588397a"

let responseStr = Http.RequestString(url, headers = [ HttpRequestHeaders.Accept HttpContentTypes.Json; HttpRequestHeaders.BasicAuth user pass ])
System.Windows.Forms.Clipboard.SetText(responseStr)
