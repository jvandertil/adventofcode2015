module Program

open System
open System.IO

type Rectangle = 
    { length : int32
      width : int32
      height : int32 }

let parseInput (line : string) = 
    let parts = 
        line.Split('x')
        |> Seq.map Int32.Parse
        |> Seq.toArray
    
    let rect = 
        { length = parts.[0]
          width = parts.[1]
          height = parts.[2] }
    
    rect

let getFacePerimeters rect = 
    [ rect.length + rect.height
      rect.width + rect.length
      rect.height + rect.width ]
    |> List.map ((*) 2)

let getVolume rect = rect.length * rect.height * rect.width

[<EntryPoint>]
let main argv = 
    let calcRibbonLength rect = (getFacePerimeters rect |> List.min) + (getVolume rect)

    File.ReadAllLines("input.txt")
    |> Seq.map parseInput
    |> Seq.map calcRibbonLength
    |> Seq.sum
    |> printfn "%i"

    0
