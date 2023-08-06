function loadScript(src, callback) {
  let script = document.createElement('script')
  script.src = src
  script.onload = () => callback(null)
  script.onerror = () => callback(
    new Error(`Не удалось загрузить скрипт ${src}`)
  )
  document.head.append(script)
}

function print(text) {
  document.body.innerHTML += text
}

function secondFunction(x, y) {
  return new Promise(resolve => {
    setTimeout(() => {
      print(`${y}.Выполнилось ${x} действие `)
      resolve(x, y)
    }, 1000)
  })
}

const target = new EventTarget()
target.addEventListener(
  "clack",
  () => print('<br/>Всем привет!')
)

loadScript('functions.js', async function (error) {
  if (error) {
    console.error(error)
  } else {
    conditional(true,
      () => print('1.Выполнилось первое действие '),
      () => print('1.Выполнилось второе действие '),
      () => print('1.Выполнилось третье действие '),
      () => print('1.Выполнилось четвертое действие ')
    )
    print('<br/>')
    loop(6,
      () => print('2.Выполнилось первое действие '),
      (iteration) => print(`2.Выполнилось второе действие ${iteration} раз `),
      () => print('2.Выполнилось третье действие '),
      target
    )
    print('<br/>')
    conditionalAsync(true,
      secondFunction,
      secondFunction,
      secondFunction,
      secondFunction
    )
    print('<br/>')
    loopAsync(4,
      () => secondFunction(1, 4),
      () => secondFunction(2, 4),
      () => print('4.Выполнилось 3 действие '),
    )
  }
})


