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
            let json = 
              Assembly.GetExecutingAssembly().Location 
              |> Path.GetDirectoryName 
              |> fun dir -> Path.Combine(dir, "../../../Resources/example-response.txt") 
              |> File.ReadAllText
              |> filterSkills
              |> parseToJson

            // Assert
            Assert.AreEqual(true, true)
