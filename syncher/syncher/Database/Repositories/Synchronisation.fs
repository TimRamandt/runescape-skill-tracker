module SyncDb 

open Context
open Models.Sync
open Microsoft.EntityFrameworkCore

type Repository(ctx: Context) =
    member this.Ctx = ctx

    member this.getSynchronisationsAsync(): Async<Synchronisation[]> =
        async {
            let! syncs = this.Ctx.Synchronisations.ToArrayAsync() |> Async.AwaitTask
            return syncs
        }
    
    member this.addSynchronisationAsync(sync: Synchronisation) =
        this.Ctx.Synchronisations.AddAsync(sync).AsTask() |> Async.AwaitTask |> ignore 
        this.Ctx.SaveChangesAsync() |> Async.AwaitTask   
