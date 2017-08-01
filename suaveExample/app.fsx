#load "suave.fsx"

open Suave
open Suave.Operators
open Suave.Filters
open Suave.Html
open FSharp.Data.Sql

type Sql = SqlDataProvider<ConnectionString = """Data Source=localhost;Initial Catalog=NavcareDB;Integrated Security=True;""",
                           DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER,
                           UseOptionTypes = true>
let ctx = Sql.GetDataContext()

let homePage =
  div ["class", "bob"] [
    p [] (text "hello world for real this time")
  ]
  |> pageTemplate

let tester patientId =
  let x =
    query {
      for t in ctx.Ptn.Patients do
      where (t.Id = patientId)
      select t.StaffName.Value
    }
    |> Seq.head
  Successful.OK x

let app =
    choose [
        path "/"        >=> Successful.OK homePage
        path "/maybe"   >=> Successful.OK "hello ... goodbye world?"
        path "/goodbye" >=> Successful.OK "goodbye world"
        pathScan "/search/%d" tester
    ]

startWebServer defaultConfig app