module Helpers
open Program
open System.IO
open System.Reflection


let dummyJson(fileName: string) =
    Assembly.GetExecutingAssembly().Location 
    |> Path.GetDirectoryName 
    |> fun dir -> Path.Combine(dir, "../../../Resources", fileName) 
    |> File.ReadAllText
    |> filterSkills
    |> parseToJson
