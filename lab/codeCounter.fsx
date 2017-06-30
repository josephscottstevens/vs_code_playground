open System
open System.IO
let folder = """D:\reports\PortalTest\PortalTest\"""
let rec allFilesUnder baseFolder =
    seq { yield! Directory.GetFiles(baseFolder)           
          for subdir in Directory.GetDirectories(baseFolder) do 
              yield! allFilesUnder subdir } 

let readLines (filePath : string) = 
    seq { use sr = new StreamReader (filePath)     
          while not sr.EndOfStream do         
          yield sr.ReadLine () }

let countLines filePath =
    readLines filePath
    |> Seq.filter (fun line -> 
        (not (String.IsNullOrWhiteSpace(line))) && (not (line.TrimStart().StartsWith("//"))))
    |> Seq.length

let countWords filePath =
    Seq.sumBy Seq.length (readLines filePath
    |> Seq.filter (fun line -> (not (String.IsNullOrWhiteSpace(line))) && (not (line.TrimStart().StartsWith("//"))))
    |> Seq.map (fun t -> t.Split([|'#';'.';',';';';':';'!';'?';'`';' ';'"';'\'';'“';'”';'(';')';'+';'-'|], StringSplitOptions.RemoveEmptyEntries)))

let words func filter = 
    allFilesUnder folder
    |> Seq.filter (fun file -> file.EndsWith(filter))
    |> Seq.toArray
    |> Array.Parallel.map func
    |> Array.sum

let markupLines = words countLines ".liquid"
let markupWords = words countWords ".liquid"
let codeLines = words countLines ".fs"
let codeWords = words countWords ".fs"

// FSharp Project - done
// val markupLines : int = 252
// val markupWords : int = 954
// val codeLines : int = 293
// val codeWords : int = 1435

// CSharp Project - 90% complete
// val markupLines : int = 921
// val markupWords : int = 4085
// val codeLines : int = 1413
// val codeWords : int = 4605