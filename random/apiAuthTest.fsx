#r "../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
open System
open FSharp.Data
open FSharp.Data.JsonExtensions
open FSharp.Data.HttpRequestHeaders

let url = "https://gsgus.zendesk.com/api/v2/"
let user = "john.kaltz@gsgus.com/token"                  // The user name parameter is email/token
let pass = "IDq5qR9tcq4DXp8tm56jAv6hUQpkpVkgHTL701FH"    // The password parameter is apiToken

let authHeaders = 
    [ 
        Accept HttpContentTypes.Json;
        AcceptLanguage "en_US"
        BasicAuth "clientId" "secret";
        "grant_type", "client_credentials"
    ]
let getResponseString =
    
    Http.RequestString(url, headers = authHeaders)