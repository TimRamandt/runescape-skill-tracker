open System
open System.Net
open System.IO

// Learn more about F# at http://fsharp.org

//F# try-outs, references to later course
//open System

//let Greeting greeting name = greeting + " from " + name

//[<EntryPoint>]
//let main argv =
//    Greeting "Hello" "Tim" |> printfn "%s"

//    Console.ReadKey()
//    0 // return an integer exit code

let FetchData name = 
    let url = "http://services.runescape.com/m=hiscore/index_lite.ws?player=" + name
    let request = HttpWebRequest.Create(url)
    let response = request.GetResponse() 
    let stream = response.GetResponseStream()
    let reader = new StreamReader(stream) 
       
    reader.ReadToEnd()
 
[<EntryPoint>]
let main argv = 
    printfn "Bored on RuneScape? This commandline app will determine what skill you should train next."
    printfn "Let's start. Enter your Runescape Name"
    let name = Console.ReadLine()
    FetchData name |> printfn "%s"
    Console.ReadKey()
    0