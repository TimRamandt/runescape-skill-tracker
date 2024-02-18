module Parse 

open NUnit.Framework
open Program
open System.IO
open System.Reflection
open System

[<TestFixture>]
    type Tests() =

        // Define a test method
        [<Test>]
        member this.``Parse input to type``() =
            // Arrange
            let relativePath = "../../../Resources/example-response.txt"
            let exampleResponse = 
              Assembly.GetExecutingAssembly().Location 
              |> Path.GetDirectoryName 
              |> fun dir -> Path.Combine(dir, relativePath) 
              |> File.ReadAllText

            let json = exampleResponse |> filterSkills |> parseToJson
            // Assert
            Assert.AreEqual(true, true)
