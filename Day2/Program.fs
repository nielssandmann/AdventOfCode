open  AOCLib

let findMinAndMax xs =
  let min = Seq.min xs
  let max = Seq.max xs
  (min, max)
  
let findFactors x xs = 
    xs |> List.filter (fun p -> (p % x) = 0)
       |> List.map (fun p -> ( p, x ))


let rec findDivisors (xs:seq<int>) =
  let ordered = xs |> Seq.toList |> List.sort 
  match ordered with
               | [] -> []
               | x::ys -> (findFactors x ys) @ (findDivisors ys)
 
let part1 = AOCLib.parseFile "Input" 
                              |> Seq.map findMinAndMax
                              |> Seq.map (fun (min,max) ->  max - min)
                              |> Seq.sum
 
let part2 = AOCLib.parseFile "Input"
               |> Seq.map findDivisors
               |> Seq.map List.head
               |> Seq.map (fun (f,m) -> f/m)
               |> Seq.sum
  
[<EntryPoint>]
let main argv = 
    let result = part2
                   
    
    printf "%d" result  
    0 // return an integer exit code
