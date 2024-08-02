//I ~~stole~~ borrowed the idea from Jagex
import icon_strip from "./assets/skill-icon-strip.png"

const SkillIcon = ({name}: {name: string}) => {
    //formulea to get these numbers (appart from attack which start at -1px):
    //for example defence is the 7th element (n), I did: (n-1)*31(width)+(n) => 6*31+7 = 191
    const iconPosition: {[key: string]: string } = {
        total: "-929px",
        attack: "-1px",
        defence: "-193px",
        strength: "-97px",
        constitution: "-33px",
        ranger: "-289px", //to do fix typo
        prayer: "-385px",
        magic: "-481px",
        cooking: "-353px",
        woodcutting: "-545px",
        fletching: "-513px",
        fishing: "-257px",
        firemaking: "-449px",
        crafting: "-417px",
        smithing: "-161px",
        mining: "-65px",
        herblore: "-225px",
        agility: "-129px",
        thieving: "-321px",
        slayer: "-609px",
        farming: "-641px",
        runecrafting: "-577px",
        hunter: "-705px",
        construction: "-673px",
        summoning: "-737px",
        dungeoneering: "-769px",
        divination: "-801px",
        invention: "-833px",
        archaeology: "-865px",
        necromancy: "-897px",

    };
    return (
        <div style={{
        backgroundImage: `url(${icon_strip})`,
        width: '31px',
        height: '37px', 
        backgroundRepeat: 'no-repeat',
        backgroundPosition: `${iconPosition[name]} center` 
       }}>
       </div>
    )
}

export default SkillIcon