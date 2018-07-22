module PlayerModel

//API:
//http://services.runescape.com/m=hiscore/index_lite.ws?player=X
//X = player name

type Player = 
    {Name: string
     Skills: Skill list}

and Skill = 
    {Name: string
     Rank: int
     Level: int
     TotalXP: int}



