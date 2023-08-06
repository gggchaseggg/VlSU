const delay = async (ms) => await new Promise(resolve => setTimeout(resolve, ms));

function getPlayer() {
  const rand = Math.random()
  if (rand > 0.666) {
    return 'rock'
  }
  if (rand < 0.333) {
    return 'paper'
  }
  return 'scissors'
}

function whoWin(p1, p2) {
  if (p1.player === 'paper' && p2.player === 'rock') {
    return 1
  }
  if (p1.player === 'paper' && p2.player === 'scissors') {
    return 2
  }
  if (p1.player === 'paper' && p2.player === 'paper') {
    return -1
  }

  if (p1.player === 'rock' && p2.player === 'paper') {
    return 2
  }
  if (p1.player === 'rock' && p2.player === 'scissors') {
    return 1
  }
  if (p1.player === 'rock' && p2.player === 'rock') {
    return -1
  }

  if (p1.player === 'scissors' && p2.player === 'paper') {
    return 1
  }
  if (p1.player === 'scissors' && p2.player === 'rock') {
    return 2
  }
  if (p1.player === 'scissors' && p2.player === 'scissors') {
    return -1
  }
}

function render(players) {
  const game = document.body.querySelector('.game')
  game.innerHTML = ''
  players.forEach((rps) => {
    const div = document.createElement('div')
    div.style.width = '30px'
    div.style.height = '30px'
    div.style.backgroundColor = rps.bgColor
    div.style.position = 'absolute'
    div.style.top = `${rps.y}%`
    div.style.left = `${rps.x}%`
    div.style.borderRadius = '30%'
    div.dataset.player = rps.player
    game.append(div)
  })
}

let count = 0
function renderCount () {
  count += 1
  document.body.querySelector('.count').innerHTML = count
}


class RPS {
  constructor(rockPaperScissors) {
    this.player = rockPaperScissors
    this.bgColor = this.#getColor(rockPaperScissors)
    this.x = Math.round(Math.random() * 96)
    this.y = Math.round(Math.random() * 98)
  }

  #getColor = (rockPaperScissors) => {
    switch (rockPaperScissors) {
      case 'rock':
        return 'black'
      case 'paper':
        return 'green'
      case 'scissors':
        return 'gray'
    }
  }

  isBound = (rps) => {
    const xLambda = Math.abs(this.x - rps.x)
    const yLambda = Math.abs(this.y - rps.y)
    return xLambda <= 2 && yLambda <= 2
  }

  lose = () => {
    if (this.player === 'paper') {
      this.player = 'scissors'
      this.bgColor = 'gray'
    } else if (this.player === 'scissors') {
      this.player = 'rock'
      this.bgColor = 'black'
    } else {
      this.player = 'paper'
      this.bgColor = 'green'
    }
  }

  move = () => {
    const xRand = Math.random()
    const yRand = Math.random()
    if (xRand > 0.5) this.x += this.x < 96 ? 1 : -1
    else this.x -= this.x > 0 ? 1 : -1

    if (yRand > 0.5) this.y += this.y < 98 ? 1 : -1
    else this.y -= this.y > 0 ? 1 : -1
  }
}

let players = [new RPS('paper')]
for (let i = 0; i < 20; i++) {
  players.push(new RPS(getPlayer()))
}
render(players)
delay(2000).then(() => {
  const playersCopy = [...players]
  playersCopy.forEach((rps) => rps.move())
  players = [...playersCopy]
  render(players)
})

function nextIter() {
  for (let i = 0; i < players.length - 2; i++) {
    for (let j = i + 1; j < players.length - 1; j++) {
      const p1 = players[i]
      const p2 = players[j]

      if (p1.isBound(p2)) {
        const winner = whoWin(p1,p2)
        if (winner === 1) {
          p2.lose()
          renderCount()
        }
        if (winner === 2) {
          p1.lose()
          renderCount()
        }
      }
      players[i] = p1
      players[j] = p2
    }
  }

  players.forEach((rps) => rps.move())
  render(players)
}
