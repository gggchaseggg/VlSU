const task2 = () => {
  const block = document.querySelector('.task2>.display')
  const randomNumber = Math.floor(Math.random() * 10)
  let text = `Случайное число ${randomNumber} <br/>`
  if (randomNumber > 5) text += `Полученное число ${randomNumber} больше 5 <br/>`
  text += randomNumber === 6 ? 'Число равно 6<br/>' : 'Число не равно 6<br/>'
  block.innerHTML = text
}

const task3 = (maxNumber) => {
  const block = document.querySelector('.task3>.display')
  let text = ''

  const isPrime = (num) => {
    for (let i = 2; i < num; i++) {
      if (num % i === 0) return false
    }
    return num !== 1
  }

  for (let i = 2; i <= maxNumber; i++) {
    if (isPrime(i)) text += `${i} - `
  }
  block.innerHTML = text

}

const task4 = () => {
  const block = document.querySelector('.task4>.display')
  let text = ''

  const array = [6, 2, 9, 0, 23, 35, 12, 7, 12]
  array.forEach((item) => text += `${item} * `)
  text += '<br/>'
  text += array.map((item) => item ** 2).reduce((acc, value) => acc += `${value} ** `, '')
  text += '<br/>'
  if (array.some((item) => item < 3)) text += 'Есть элемент меньше 3'
  block.innerHTML = text
}

const task5 = () => {
  const block = document.querySelector('.task5>.display')
  let text = ''

  const obj = {
    property1: 123,
    property2: '321'
  }
  Object.prototype.newProperty = 'Не делай так пж'
  for (const objKey in obj) {
    text += `${objKey}: ${obj[objKey]} <br/>`
  }
  block.innerHTML = text
}

class Man {

  name
  surname
  age
  #logCount = 0

  constructor(name, surname, age) {
    this.name = name
    this.surname = surname
    this.age = age
  }

  sayHi() {
    const block = document.querySelector('.task6>.display1')
    block.innerHTML = `Hi, I'm ${this.name} ${this.surname} - ${this.age} yo; count=${this.#logCount++}`
  }
}

class Driver extends Man {

  carTitle

  constructor(carTitle, name, surname, age) {
    super(name, surname, age)
    this.carTitle = carTitle
  }

  sayHi() {
    const block = document.querySelector('.task6>.display2')
    block.innerHTML = `Hi, I'm ${this.name} ${this.surname} - ${this.age} y.o., I'm drive ${this.carTitle}`
  }
}

const man = new Man('Anton', 'Ibragimov', 34)
const driver = new Driver('Granta', 'Daniil', 'Grachev', 20)

const task6 = () => {
  man.sayHi()
  driver.sayHi()
}

const task7 = () => {
  const block = document.querySelector('.task7>.display')
  let text = ''
  Driver.prototype.againPrototype = 'Не делай так'
  Driver.prototype.againPrototype2 = () => {
    const block = document.querySelector('.task7>.display2')
    block.innerHTML = 'Никогда не используй поля прототипов'
  }
  for (const objKey in driver) {
    text += `${objKey}: ${driver[objKey]} <br/>`
  }
  driver.againPrototype2()
  block.innerHTML = text
}

class Trapezoid {
  left_down
  left_top
  right_top
  right_down

  constructor(left_down, left_top, right_top, right_down) {
    this.left_down = left_down
    this.left_top = left_top
    this.right_top = right_top
    this.right_down = right_down
  }

  getArea() {
    return Math.abs((((this.right_top[0] - this.left_top[0]) + (this.right_down[0] - this.left_down[0])) / 2) * (this.left_top[1] - this.left_down[1]))
  }
}

const task8 = () => {
  const block = document.querySelector('.task8>.display')
  let text = ''
  const max = Math.floor(Math.random() * 1000)
  let maxCount = 0

  const traps = []

  for (let i = 0; i < Math.floor(Math.random() * 10); i++) {
    const y1 = Math.floor(Math.random() * 100)
    const y2 = Math.floor(Math.random() * 100)
    traps.push(new Trapezoid(
      [Math.floor(Math.random() * 100), y1],
      [Math.floor(Math.random() * 100), y2],
      [Math.floor(Math.random() * 100), y2],
      [Math.floor(Math.random() * 100), y1]))
  }
  text += '['
  for (const trap of traps) {
    text += `${trap.getArea()}, `
    if (trap.getArea() > max) maxCount++
  }
  text += ']'
  block.innerHTML = text

  document.querySelector('.task8>.display2')
    .innerHTML = `Площадь больше ${max} в ${maxCount} трапециях`

}
