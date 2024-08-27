module Context

open Models.Sync
open Models.Profile
open Microsoft.EntityFrameworkCore


type DatabaseType =
    | InMemory
    | SQLite

type Context(options: DbContextOptions<Context>) = 
    inherit DbContext(options)

    [<DefaultValue>]
    val mutable Synchronisations : DbSet<Synchronisation>

    [<DefaultValue>]
    val mutable Profiles : DbSet<Profile>

    member public this.Synchronisation 
        with get() = this.Synchronisations 
        and set syncs = this.Synchronisations <- syncs 

    member public this.Profile
        with get() = this.Profiles
        and set profiles = this.Profiles <- profiles 

    member this.EnsureDatabaseCreated() =
        this.Database.EnsureCreated()

let createContext (dbType: DatabaseType) =
    let options =
        match dbType with
        | InMemory ->
            DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase("database_name")
                .Options
        | SQLite ->
            DbContextOptionsBuilder<Context>()
                .UseSqlite("Data Source=db.sqlite")
                .Options

    new Context(options)
