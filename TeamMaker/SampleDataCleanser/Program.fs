// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
module Program

open System
open System.IO
open Microsoft.VisualBasic.FileIO


let firstNameIndex = 0
let lastNameIndex = 1
let schoolNameIndex = 9
let buddy1Index = 13
let buddy2Index = 14
let headCoachIndex = 15


let sanitizeNames ( dirtyStr : string ) ( names : string array ) =
    let z = Array.get names 0

    let a = dirtyStr.Replace (z, "")

    ()

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    let filePath = "D:\Desktop\SamplePlayersCsv.csv"
    let filePathOut = "D:\Desktop\SamplePlayersCsv_Output.csv"

    let parser = new TextFieldParser (filePath)
    parser.Delimiters <- [|","|]
    parser.HasFieldsEnclosedInQuotes <- true

    let mutable names = []
    let mutable schools = []
    let mutable buddy1s = []
    let mutable buddy2s = []
    let mutable coaches = []

    let mutable count = -2

    parser.ReadFields |> ignore 
    parser.ReadFields |> ignore

    while not parser.EndOfData do
        let playerFields = parser.ReadFields ()
        count <- count + 1
        if count > 0 then do
            names <- List.append names [ [| playerFields.[firstNameIndex] + "," + playerFields.[lastNameIndex]; playerFields.[firstNameIndex] + " " + playerFields.[lastNameIndex]; sprintf "First%d" count; sprintf "Last%d" count; sprintf "First%d,Last%d" count count |] ]
            schools <- List.append schools [ playerFields.[schoolNameIndex] ]
            buddy1s <- List.append buddy1s [ [| playerFields.[buddy1Index] |] ]
            buddy2s <- List.append buddy2s [ [| playerFields.[buddy2Index] |] ]
            coaches <- List.append coaches [ [| playerFields.[headCoachIndex] |] ]

    parser.Dispose |> ignore


    let distinctSchools = 
        List.distinct schools
        |> List.filter (fun x -> not (String.IsNullOrEmpty x) )
        |> List.sortByDescending (fun x -> x.Length )
        |> List.mapi (fun i x -> [| x; sprintf "School %d" (i + 1) |])
     
    let mutable toSanitize = File.ReadAllText filePath

    for i = 0 to names.Length - 1 do
        toSanitize <- toSanitize.Replace (names.[i].[0], names.[i].[4])
    for i = 0 to distinctSchools.Length - 1 do
        toSanitize <- toSanitize.Replace (distinctSchools.[i].[0], distinctSchools.[i].[1])
//        toSanitize <- toSanitize.Replace (buddy1s.[i].[0], names.[i].[4])
//        toSanitize <- toSanitize.Replace (buddy2s.[i].[0], names.[i].[4])
//        toSanitize <- toSanitize.Replace (coaches.[i].[0], names.[i].[4])

        ()

    File.WriteAllText (filePathOut, toSanitize)

    0 // return an integer exit code
