import { useState, useEffect } from 'react'
import SkillRow from './SkillRow';
import { SkillEntry } from './types';

function App() {
  const [skills, setSkills] = useState<SkillEntry[]>()
    useEffect(() => {
      const startState = async() => {
        const response = await fetch("http://localhost:5268/", {method: "GET"}) 
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        setSkills(await response.json());
      }
      startState()
    }, []);
  return (
    <>
      {skills?.map(s => <SkillRow entry={s}/>)}
    </>
  )
}

export default App
