// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
module Program

open System
open System.IO
open Microsoft.VisualBasic.FileIO


let firstNameIndex = 0
let lastNameIndex = 1
let addressNameIndex = 2
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
    let mutable addresses = []
    let mutable schools = []
    let mutable buddies = []
    let mutable coaches = []

    let mutable count = -2

    parser.ReadFields |> ignore 
    parser.ReadFields |> ignore

    while not parser.EndOfData do
        let playerFields = parser.ReadFields ()
        count <- count + 1
        if count > 0 then do
            names <- List.append names [ [| playerFields.[firstNameIndex] + "," + playerFields.[lastNameIndex]; playerFields.[firstNameIndex] + " " + playerFields.[lastNameIndex]; sprintf "First%d" count; sprintf "Last%d" count; sprintf "First%d,Last%d" count count; sprintf "First%d Last%d" count count |] ]
            addresses <- List.append addresses [ playerFields.[addressNameIndex] ]
            schools <- List.append schools [ playerFields.[schoolNameIndex] ]
            buddies <- List.append buddies [ playerFields.[buddy1Index] ]
            buddies <- List.append buddies [ playerFields.[buddy2Index] ]
            coaches <- List.append coaches [ playerFields.[headCoachIndex] ]

    parser.Dispose |> ignore

    let distinctFullNames = 
        List.concat [ buddies; names |> List.map (fun x -> x.[1])]
        |> List.distinct
        |> List.filter (fun x -> not (String.IsNullOrEmpty x) )
        |> List.map (fun x -> x, names |> List.tryFind (fun z -> z.[1] = x ) )
        |> List.sortBy (fun x -> match snd x with | Some y -> 1 | None -> 0) 
        |> List.mapi (fun i x -> [| fst x; (match snd x with | Some y -> y.[5] | None -> sprintf "First%d Last%d" (count + i + 1) (count + i + 1)) |] ) 


    let distinctAddresses = 
        addresses
        |> List.distinct
        |> List.filter (fun x -> not (String.IsNullOrEmpty x) )
        |> List.sortByDescending (fun x -> x.Length )
        |> List.mapi (fun i x -> [| x; sprintf "Address%d" (i + 1) |])

    let distinctSchools = 
        schools
        |> List.distinct
        |> List.filter (fun x -> not (String.IsNullOrEmpty x) )
        |> List.sortByDescending (fun x -> x.Length )
        |> List.mapi (fun i x -> [| x; sprintf "School%d" (i + 1) |])

    let distinctCoaches = 
        coaches
        |> List.distinct 
        |> List.filter (fun x -> not (String.IsNullOrEmpty x) )
        |> List.sortByDescending (fun x -> x.Length )
        |> List.mapi (fun i x -> [| x; sprintf "Coach%d" (i + 1) |])
     
    let mutable toSanitize = File.ReadAllText filePath

    for i = 0 to distinctFullNames.Length - 1 do
        toSanitize <- toSanitize.Replace (distinctFullNames.[i].[0], distinctFullNames.[i].[1])
    for i = 0 to distinctAddresses.Length - 1 do
        toSanitize <- toSanitize.Replace (distinctAddresses.[i].[0], distinctAddresses.[i].[1])
    for i = 0 to distinctSchools.Length - 1 do
        toSanitize <- toSanitize.Replace (distinctSchools.[i].[0], distinctSchools.[i].[1])
    for i = 0 to distinctCoaches.Length - 1 do
        toSanitize <- toSanitize.Replace (distinctCoaches.[i].[0], distinctCoaches.[i].[1])
    for i = 0 to names.Length - 1 do
        toSanitize <- toSanitize.Replace (names.[i].[0], names.[i].[4])

        ()

    File.WriteAllText (filePathOut, toSanitize)

    0 // return an integer exit code
