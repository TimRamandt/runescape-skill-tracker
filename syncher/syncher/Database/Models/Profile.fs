module Models.Profile

open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema


// currently no OSRS support but adding it as an option for the future
type Game = 
  | RS3 = 0
  | OSRS = 1

type Profile(name: string, game: Game) =
    [<Key; DatabaseGenerated(DatabaseGeneratedOption.Identity)>]
    member val Id = 0 with get, set
    member val Name = name with get, set
    member val Game = game with get, set

