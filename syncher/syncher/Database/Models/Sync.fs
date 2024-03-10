module Models.Sync

open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema
open System

// A synchronisation just holds some json and a date when the sync occurres 
type Synchronisation(data: string, createdAt: DateTime) =
    [<Key; DatabaseGenerated(DatabaseGeneratedOption.Identity)>]
    member val Id = 0 with get, set
    member val data = data with get, set
    member val createdAt = createdAt with get, set
