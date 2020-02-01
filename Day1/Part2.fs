module Day1.Part2

open System

let input = System.IO.File.ReadAllText "Input" |> fun s -> s.Trim()
           
let look_ahead = input.Length / 2

let compare_to = (input + input) |> Seq.skip look_ahead

let pairs = input |> Seq.zip compare_to

let numbersWithEqualSuccessor = pairs
                                |>  Seq.filter (fun (x,y) -> x.Equals(y) )
                                |> Seq.map(fun (x, y) -> x)
                        
let answer = numbersWithEqualSuccessor
             |> Seq.map (fun c ->  string c |> Int32.Parse)
             |> Seq.sum
             
[<EntryPointAttribute>]
let main argv =
    printfn "%d" answer
    0
    
