import SkillIcon from "./SkillIcon";
import { Entry } from "./types";



type SkillEntryProps = {
    entry: Entry
}


const SkillRow = ({entry}: SkillEntryProps) => {
    const skillGain = entry.XPGained !== 0 ? `+${entry.XPGained}` : "~"    
    const level = entry.Level !== entry.NewLevel ? `${entry.NewLevel} +${entry.NewLevel-entry.Level}` : entry.Level 
    return ( 
    <div style={{display: "flex", flexDirection: "row"}}>
        <SkillIcon name={entry.Name}/> 
       <div>{entry.Name} | {level} | {entry.Rank} ({entry.RankChange}) | {entry.XP} {skillGain}</div>
    </div>
    )
}

export default SkillRow;