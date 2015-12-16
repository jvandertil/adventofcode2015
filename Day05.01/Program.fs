module Program

open System.IO

let isVowel char = 
    match char with
    | 'a' -> true
    | 'e' -> true
    | 'i' -> true
    | 'o' -> true
    | 'u' -> true
    | _ -> false

let hasEnoughVowels (input : string) = 
    let vowelCount =
        input
        |> Seq.filter isVowel
        |> Seq.length

    vowelCount >= 3

let hasDoubleLetter (input : string) = 
    input
    |> Seq.pairwise
    |> Seq.filter (fun (first, second) -> first = second)
    |> Seq.tryHead
    |> Option.isSome

let containsNaughtyString (input : string) = 
    [ "ab"; "cd"; "pq"; "xy" ]
    |> Seq.filter (fun naughty -> input.Contains(naughty))
    |> Seq.tryHead
    |> Option.isSome

[<EntryPoint>]
let main argv = 
    let noNaughtyStrings input = not(containsNaughtyString(input))

    File.ReadAllLines("input.txt")
    |> Seq.filter noNaughtyStrings
    |> Seq.filter hasDoubleLetter
    |> Seq.filter hasEnoughVowels
    |> Seq.length
    |> printfn "%i"

    0
