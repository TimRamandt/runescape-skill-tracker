module SyncRepository 

open Context
open Models.Sync
open Microsoft.EntityFrameworkCore

let ctx = new Context()
ctx.EnsureDatabaseCreated() |> ignore

let getSynchronisationsAsync(): Async<Synchronisation[]> =
    async {
        let! syncs = ctx.Synchronisations.ToArrayAsync() |> Async.AwaitTask
        return syncs
    }

let addSynchronisationAsync(sync: Synchronisation) =
    ctx.Synchronisations.AddAsync(sync).AsTask() |> Async.AwaitTask |> ignore 
    ctx.SaveChangesAsync() |> Async.AwaitTask   
