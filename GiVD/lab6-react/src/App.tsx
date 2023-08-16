import React from 'react'
import { Table } from './components'
import HelloWorld from './HelloWorld'

function App() {
  return (
    <div>
      <Table />
      <HelloWorld name={'Даня'} age={20} />
    </div>
  )
}

export default App
