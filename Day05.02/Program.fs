module Program

open System
open System.IO
open System.Text.RegularExpressions

let hasSameLetterWithOneSeparator input =
    let regex = Regex("(.).\1")
    input |> regex.IsMatch

let hasLetterPair input =
    let regex = Regex("(..).*\1")
    input |> regex.IsMatch

let filter input = 
    input
    |> Seq.filter hasSameLetterWithOneSeparator
    |> Seq.filter hasLetterPair

[<EntryPoint>]
let main argv = 
    File.ReadAllLines("input.txt")
    |> filter
    |> Seq.length
    |> printfn "%i"
    0
