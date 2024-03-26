module SkillEntry

type Entry = {
   Name: string; 
   Rank: int; 
   Level: int; 
   XP: int64 
 }

let skills = [| "total"; 
                "attack"; 
                "defence"; 
                "strength"; 
                "constitution";
                "ranger"; 
                "prayer"; 
                "magic"; 
                "cooking"; 
                "woodcutting"; 
                "fletching"; 
                "fishing"; 
                "firemaking"; 
                "crafting"; 
                "smithing"; 
                "mining"; 
                "herblore"; 
                "agility"; 
                "thieving"; 
                "slayer"; 
                "farming"; 
                "runecrafting"; 
                "hunter"; 
                "construction"; 
                "summoning"; 
                "dungeoneering"; 
                "divination"; 
                "invention"; 
                "archaeology"; 
                "necromancy"; 
                |]
