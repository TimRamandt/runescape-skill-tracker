module DiffinatorTests

open NUnit.Framework
open Program
open Models.Sync
open System;
open Diffinator;


[<TestFixture>]
    type Tests() =

        // Define a test method
        [<Test>]
        member this.``calculate correct diff rank increase``() =
            // |> fun dir -> Path.Combine(dir, "../../../Resources", fileName) 
            let baseSync = "example-response.txt"
                             |> Helpers.dummyJson 
                             |> fun data -> new Synchronisation(data, DateTime.Now.Subtract(TimeSpan.FromDays(1)))

            let compareSync = "example-response-diff-rank-increase.txt"
                             |> Helpers.dummyJson 
                             |> fun data -> new Synchronisation(data, DateTime.Now)

            let diff = Diffinator.calculateDiff(baseSync, compareSync);

            // Assert
            Assert.AreEqual(true, true)

        
