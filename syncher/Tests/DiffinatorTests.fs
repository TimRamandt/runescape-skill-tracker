module DiffinatorTests

open NUnit.Framework
open Program
open Models.Sync
open System;
open Diffinator;


[<TestFixture>]
    type Tests() =

        [<Test>]
        member this.``calculate correct diff rank increase``() =
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


        [<Test>]
        member this.``calculate correct diff rank decrease``() =
            let baseSync = "example-response.txt"
                             |> Helpers.dummyJson 
                             |> fun data -> new Synchronisation(data, DateTime.Now.Subtract(TimeSpan.FromDays(1)))

            let compareSync = "example-response-diff-rank-decrease.txt"
                             |> Helpers.dummyJson 
                             |> fun data -> new Synchronisation(data, DateTime.Now)

            let diff = Diffinator.calculateDiff(baseSync, compareSync);

            // Assert
            Assert.AreEqual(diff[0], "3009,-564,1000000")
            Assert.AreEqual(diff[16], "120,-4,1000000")
            Assert.AreEqual(diff[29], "111,0,0")

        
