﻿module Program

open System.IO

type Position = int32 * int32

type Presents = int32

type Town = Map<Position, Presents>

let deliverPresent (town : Town) position = 
    if town.ContainsKey(position) then 
        let house = town.Item(position)
        town |> Map.add position (house + 1)
    else town |> Map.add position 1

let followInstruction (town, position) instruction = 
    let (x, y) = position
    
    let newPosition = 
        match instruction with
        | '>' -> (x + 1, y)
        | '<' -> (x - 1, y)
        | '^' -> (x, y + 1)
        | 'v' -> (x, y - 1)
        | _ -> failwith "Invalid character encountered"
    
    let newTown = deliverPresent town newPosition
    (newTown, newPosition)

[<EntryPoint>]
let main argv = 
    let initialPosition = (0, 0)
    let instructions = 
        File.ReadAllText("input.txt") 
        |> Seq.indexed

    let removeIndex (index, instruction) = instruction
    
    let santaInstructions = 
        instructions
        |> Seq.filter (fun (index, instruction) -> index % 2 = 0)
        |> Seq.map removeIndex
    
    let roboInstructions = 
        instructions
        |> Seq.filter (fun (index, instruction) -> index % 2 = 1)
        |> Seq.map removeIndex
    
    let town = deliverPresent Map.empty initialPosition
    let (result, _) = santaInstructions |> Seq.fold followInstruction (town, initialPosition)
    let (result, _) = roboInstructions |> Seq.fold followInstruction (result, initialPosition)

    let moreThanOnePresent = result |> Map.filter (fun pos presents -> presents >= 1)
    printfn "%i" moreThanOnePresent.Count
    0
