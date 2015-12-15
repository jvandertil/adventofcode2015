module Program

open System.IO

let charToInt char = 
    match char with
    | '(' -> 1
    | ')' -> -1
    | _ -> 0

[<EntryPoint>]
let main argv = 
    let input = File.ReadAllText("input.txt")
    
    let floor = 
        input
        |> Seq.map charToInt
        |> Seq.sum
    printfn "%i" floor
    0
