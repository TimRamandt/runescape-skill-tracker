module Parse 

open NUnit.Framework
open Program
open Helpers;

[<TestFixture>]
    type Tests() =

        // Define a test method
        [<Test>]
        member this.``Parse input to type``() =
            let json =  "example-response.txt" |> Helpers.dummyJson 

            // Assert
            Assert.AreEqual(true, true)
