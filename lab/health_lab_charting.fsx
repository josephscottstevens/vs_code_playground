#load "..\packages/FsLab/FsLab.fsx"
open FSharp.Data

type HealthSource = JsonProvider<"https://www.healthdata.gov/api/3/action/package_show?id=c16c2f1b-6401-45de-be67-86ff81e5c683">
let health = HealthSource.GetSample()

for t in health.Result do
{
    select t.Name
}