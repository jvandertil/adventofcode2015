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

let surfaceAreas rect = 
    [ (rect.length * rect.width)
      (rect.width * rect.height)
      (rect.height * rect.length) ]

let getSmallestSideArea areaParts = areaParts |> List.min

let calcSurfaceArea areaParts = 
    areaParts
    |> List.sum
    |> (*) 2

[<EntryPoint>]
let main argv = 
    let calcRequiredPaperForPresent areaParts = (calcSurfaceArea areaParts) + (getSmallestSideArea areaParts)
    
    let requiredPaper = 
        File.ReadAllLines("input.txt")
        |> Seq.map parseInput
        |> Seq.map surfaceAreas
        |> Seq.map calcRequiredPaperForPresent
        |> Seq.sum

    printfn "%i" requiredPaper
    0
