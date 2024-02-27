module Models.Sync

open System.ComponentModel.DataAnnotations
open System

// A synchronisation just holds some json and a date when the sync occurres 
type Synchronisation(id: int, data: string, createdAt: DateTime) =
    [<Key>]
    member val Id = id with get, set
    member val data = data with get, set
    member val createdAt = createdAt with get, set
