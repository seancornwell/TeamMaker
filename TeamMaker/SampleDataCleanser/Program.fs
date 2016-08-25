// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
module Program

open System.IO
open Microsoft.VisualBasic.FileIO


[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    let filePath = "D:\Desktop\SamplePlayersCsv.csv"

    use parser = new TextFieldParser (filePath)
    parser.Delimiters <- [|","|]
    parser.HasFieldsEnclosedInQuotes <- true
    parser.ReadLine |> ignore

    let mutable info = []

    while not parser.EndOfData do
        let playerFields = parser.ReadFields ()
        info <- List.append info [ [playerFields.[0], playerFields.[1], playerFields.[9], playerFields.[13], playerFields.[14], playerFields.[15] ] ]

    //let a = File.ReadAllText filePath
    let b =
        info
        |> List.map (fun x -> info |> List.map (fun y -> (x, y)))
        |> List.concat
        |> List.map (fun (x, y) -> x + y)

    File.WriteAllText (filePath, b)

    0 // return an integer exit code
