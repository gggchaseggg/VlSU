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

const task6 = () => {
  function func (alone) { return alone }

  console.log(func(123))
}
