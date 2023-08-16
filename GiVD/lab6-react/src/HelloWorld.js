import React from 'react'
const HelloWorld = ({ name, age }) => {
  const sayHello = () => alert(`Привет, ${name}. Тебе ${age} лет!`)
  return <button onClick={sayHello}>Нажми меня!</button>
}
export default HelloWorld
