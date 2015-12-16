module Program

open System
open System.Text
open System.Security.Cryptography

let stringToBytes (x : string) = Encoding.ASCII.GetBytes(x)

let calcHashOfString (hashAlg : HashAlgorithm) (key : byte []) (input : obj) = 
    let toHash = 
        Array.concat [ key
                       (stringToBytes (input.ToString())) ]
    hashAlg.ComputeHash(toHash)

let isAdventCoin (hash : byte []) = hash.[0] = 0uy && hash.[1] = 0uy && hash.[2] = 0uy

[<EntryPoint>]
let main argv = 
    let secret = stringToBytes "iwrupvqb"
    let hashAlg = System.Security.Cryptography.MD5.Create()
    let calcHash input = calcHashOfString hashAlg secret input
    
    let (_, firstCoin) = 
        seq { 0..Int32.MaxValue }
        |> Seq.map (fun number -> ((calcHash number), number))
        |> Seq.filter (fun (hash, number) -> isAdventCoin hash)
        |> Seq.head
    printfn "%i" firstCoin
    0
