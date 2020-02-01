module Day1.Part1

open System

let input = System.IO.File.ReadAllText "Input" |> fun s -> s.Trim()
           
let looped = input + string (input |> Seq.head)

let pairs = looped |> Seq.pairwise

let numbersWithEqualSuccessor = pairs
                                |>  Seq.filter (fun (x,y) -> x.Equals(y) )
                                |> Seq.map(fun (x, y) -> x)
                        
let answer = numbersWithEqualSuccessor
             |> Seq.map (fun c ->  string c |> Int32.Parse)
             |> Seq.sum
             
let main argv =
    printfn "%d" answer
    0