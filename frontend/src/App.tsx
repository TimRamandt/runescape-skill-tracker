import { useState, useEffect } from 'react'

function App() {
  const [data, setData] = useState("")
    useEffect(() => {
      const startState = async() => {
        const response = await fetch("http://localhost:5268/", {method: "GET"}) 
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        setData(await response.json());
      }
      startState()
    }, []);
  return (
    <>
      <p>{JSON.stringify(data)}</p>
    </>
  )
}

export default App
