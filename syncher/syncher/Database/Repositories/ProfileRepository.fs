module ProfileRepository

open Context
open Models.Profile
open Microsoft.EntityFrameworkCore

type Repository(ctx: Context) =
    member this.Ctx = ctx

    member this.getLatestProfileAsync(): Async<Profile> =
        async {
            let! profiles = this.Ctx.Profiles.ToArrayAsync() |> Async.AwaitTask
            return profiles |> Array.last 
        }

    member this.getProfilesAsync(): Async<Profile[]> =
        async {
            let! profiles = this.Ctx.Profiles.ToArrayAsync() |> Async.AwaitTask
            return profiles
        }

    member this.addProfileAsync(profile: Profile) =
        this.Ctx.Profile.AddAsync(profile).AsTask() |> Async.AwaitTask |> ignore 
        this.Ctx.SaveChangesAsync() |> Async.AwaitTask   

