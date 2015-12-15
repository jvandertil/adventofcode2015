module Program

let charToInt char = 
    match char with
    | '(' -> 1
    | ')' -> -1
    | _ -> 0

let emptyProgress = (false, -1, 0)

let detectBasement progress (index, change) = 
    let (found, foundIndex, prevFloor) = progress
    if found then progress
    else 
        let curFloor = prevFloor + change
        if curFloor < 0 then (true, index, curFloor)
        else (false, -1, curFloor)

[<EntryPoint>]
let main argv = 
    let input = System.IO.File.ReadAllText("input.txt")
    
    let (_, basement, _) = 
        input
        |> Seq.map charToInt
        |> Seq.indexed
        |> Seq.fold detectBasement emptyProgress
    printfn "%i" (basement + 1) // Compensate for zero based indexing in F#
    0
