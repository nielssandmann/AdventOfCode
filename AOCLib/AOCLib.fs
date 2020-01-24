namespace AOCLib

open System

module AOCLib =

    let readLines filePath = System.IO.File.ReadLines(filePath)
    
    let parseline (line : string) = 
        line.Split(' ', '\t') 
        |> Seq.map (fun v -> Int32.Parse v)

    let parseFile filePath = filePath
                             |> readLines
                             |> Seq.map parseline