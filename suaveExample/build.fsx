// include Fake libs
#r "../packages/FAKE/tools/FakeLib.dll"

open Fake

// Directories
let wait() = System.Console.Read() |> ignore

let runServer () =
    fireAndForget (fun startInfo ->
        startInfo.WorkingDirectory <- "suaveExample"
        startInfo.FileName <- FSIHelper.fsiPath
        startInfo.Arguments <- "--define:RELOAD app.fsx")


Target "Watch" (fun _ ->
  use watcher = !! "suaveExample/*.fsx" |> WatchChanges (fun changes ->
      tracefn "%A" changes
      killAllCreatedProcesses()
      runServer()
  )
  runServer()
  wait()
)
runServer()