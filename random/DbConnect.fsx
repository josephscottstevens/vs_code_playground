#r "../packages/SQLProvider/lib/FSharp.Data.SqlProvider.dll"
open FSharp.Data.Sql

let [<Literal>] connectionString = """Data Source=DESKTOP-4VK9UDT;Initial Catalog=NavcareDB;Integrated Security=True;"""

type sql = SqlDataProvider<ConnectionString = connectionString,
                           DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER,
                           UseOptionTypes = true,
                           IndividualsAmount = 10>

let ctx = sql.GetDataContext()

let x = ctx.Ptn.Patients.Individuals.``10``.CcmStopReasons

query {
    for ptn in ctx.Ptn.Patients do
    for med in ptn.``ptn.Medications by Id`` do
    where (ptn.UserId = "fdefa492-73d0-4223-9d2c-ec40464d6890")
    select (ptn.UserId, med.Strength)
}
|> Seq.toList