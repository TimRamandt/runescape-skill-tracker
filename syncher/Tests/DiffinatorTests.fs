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
            Assert.AreEqual(diff[0], "3009,271,4000003")
            Assert.AreEqual(diff[12], "99,0,0")
            Assert.AreEqual(diff[29], "112,841,4000003")

        
