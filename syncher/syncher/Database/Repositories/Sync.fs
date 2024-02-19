module SyncRepository 

open Context
open Models.Sync
open Microsoft.EntityFrameworkCore

let ctx = new Context()

let getSyncs(ctx : Context) =
    async {
        let! syncs = ctx.Syncs.ToArrayAsync() |> Async.AwaitTask
        return syncs
    }

let addSync(sync: Sync) =
    async {
        ctx.Syncs.AddAsync(sync).AsTask() |> Async.AwaitTask |> ignore
    }
