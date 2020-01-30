open System

let input = 347991
    
type Direction = Right | Up | Left | Down 

type Position = { x : int; y : int}

let manhattanDistance c1 c2 = abs (c2.x - c1.x) + abs (c2.y - c1.y)

let directions =
    let directionOrder = seq { while true do yield! [ Right; Up; Left; Down;]}
    let directionRepeats  = seq { for x in 1..Int32.MaxValue do yield x; yield x}
    
    let repeatedDirections = Seq.zip directionOrder directionRepeats
    seq { for (direction, repeat) in repeatedDirections do
          for _ in 1..repeat do yield direction}
    
let walk coordinate direction =
  match direction with
    | Right -> { coordinate with x = coordinate.x + 1}
    | Up -> { coordinate with y = coordinate.y - 1}
    | Left -> { coordinate with x = coordinate.x - 1}
    | Down -> { coordinate with y = coordinate.y + 1}
    
  
let part1 =
    let neccessarySteps = input - 1
    let initialPosition = { x = 0; y = 0 }
    
    let endPosition = directions 
                    |> Seq.take neccessarySteps
                    |> Seq.fold walk initialPosition 
                        
    manhattanDistance initialPosition endPosition                    
    
type Memory = { 
    mm : Map<Position,int>
}

let emptyState = {mm = Map.empty }

(*
let part2 =
    let initialPosition = { x = 0; y = 0 }
    let coordinates = Seq.fold walk initialPosition directions
    
    let numbersWritten = seq { for x in 1..Int32.MaxValue do yield x}
    numbersWritten |> Seq.filter (fun n -> n < input)
                   |> Seq.head
    *) 
    
[<EntryPoint>]
let main argv = 
    
    printf "%A" part1
    0 // return an integer exit code
