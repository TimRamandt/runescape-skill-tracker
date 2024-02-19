module Models.Sync

open System

// A sync just holds some json and a date when the sync occurres 
[<CLIMutable>]
type Sync = {
    id: int;
    data: string; 
    createdAt: DateTime
}
