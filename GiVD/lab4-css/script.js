// 70% — B3

const opacity = {
  '100': 'FF',
  '95': 'F2',
  '90': 'E6',
  '85': 'D9',
  '80': 'CC',
  '75': 'BF',
  '70': 'B3',
  '65': 'A6',
  '60': '99',
  '55': '8C',
  '50': '80',
  '45': '73',
  '40': '66',
  '35': '59',
  '30': '4D',
  '25': '40',
  '20': '33',
  '15': '26',
  '10': '1A',
  '5': '0D',
  '0': '00'
}

function onResize(e) {
  const root = document.querySelector(':root')
  root.style.setProperty('--cube-size', e.target.value + 'px')
}

function onColorChange(e) {
  const target = e.target
  const id = target.id.slice(0, -1)
  const cube = document.querySelector(`div.cube.${id}`)
  const opt =  document.querySelector(`input#${id}O`)
  cube.style.background = `${target.value}${opacity[opt.value]}`
}

function onOpacityChange(e) {
  const target = e.target
  const id = target.id.slice(0, -1)
  const cube = document.querySelector(`div.cube.${id}`)
  const clr =  document.querySelector(`input#${id}C`)
  cube.style.background = `${clr.value}${opacity[target.value]}`
}
