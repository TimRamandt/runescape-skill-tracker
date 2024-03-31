module SynchronisationTests

open NUnit.Framework
open Models.Sync
open Context
open System;
open SyncDb

open Moq

[<TestFixture>]
    type Tests() =

        [<Test>]
        member this.``Test SyncRepo getSynchronisationsAsync``() =
            let context = createContext DatabaseType.InMemory
            context.EnsureDatabaseCreated() |> ignore
            let syncRepo = SyncDb.Repository(context)

            syncRepo.addSynchronisationAsync(new Synchronisation(data="sync1", createdAt = DateTime.Now)) |> ignore
            syncRepo.addSynchronisationAsync(new Synchronisation(data="sync2", createdAt = DateTime.Now)) |> ignore

            let fetchedSyncs = syncRepo.getSynchronisationsAsync() |> Async.RunSynchronously

            // Assert
            Assert.AreEqual(fetchedSyncs.Length, 2);
            Assert.AreEqual(fetchedSyncs[0].data, "sync1");
            Assert.AreEqual(fetchedSyncs[1].data, "sync2");
            





