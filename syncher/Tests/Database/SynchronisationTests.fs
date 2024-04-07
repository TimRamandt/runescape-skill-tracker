module SynchronisationTests

open NUnit.Framework
open Models.Sync
open Context
open SyncDb
open System;

open Moq

[<TestFixture>]
    type Tests() =
        let createContext = 
           let context = createContext DatabaseType.InMemory
           context.EnsureDatabaseCreated() |> ignore
           context

        [<SetUp>]
        member this.beforeEach() =
            let context = createContext
            context.Synchronisation.RemoveRange(context.Synchronisation)

        [<Test>]
        member this.``Test SyncRepo getSynchronisationsAsync``() =
            let syncRepo = createContext |> SyncDb.Repository

            syncRepo.addSynchronisationAsync(new Synchronisation(data="sync day before yesterday", createdAt = DateTime.Now.Subtract(TimeSpan.FromDays(2)))) |> Async.RunSynchronously |> ignore
            syncRepo.addSynchronisationAsync(new Synchronisation(data="sync yesterday", createdAt = DateTime.Now.Subtract(TimeSpan.FromDays(1)))) |> Async.RunSynchronously |> ignore
            syncRepo.addSynchronisationAsync(new Synchronisation(data="sync today", createdAt = DateTime.Now)) |> Async.RunSynchronously |> ignore

            let fetchedSyncs = syncRepo.getSynchronisationsAsync() |> Async.RunSynchronously

            // Assert
            Assert.AreEqual(fetchedSyncs.Length, 3);



        [<Test>]
        member this.``Test SyncRepo findSynchronisationByDateAsync``() =
            let syncRepo = createContext |> SyncDb.Repository
            let today = DateTime.Now

            syncRepo.addSynchronisationAsync(new Synchronisation(data="sync yesterday", createdAt = today.Subtract(TimeSpan.FromDays(1)))) |> Async.RunSynchronously |> ignore
            syncRepo.addSynchronisationAsync(new Synchronisation(data="sync today", createdAt = today)) |> Async.RunSynchronously |> ignore

            //let todaySync = 
            //   syncRepo.findSynchronisationByDateAsync(new DateTime(year= DateTime.Now.Year, month= DateTime.Now.Month, day=DateTime.Now.Day)) 
            //   |> Async.RunSynchronously
            
            let todaySync = 
               syncRepo.findSynchronisationByDateAsync(today) 
               |> Async.RunSynchronously


            Assert.AreEqual("sync today", todaySync.Value.data)





