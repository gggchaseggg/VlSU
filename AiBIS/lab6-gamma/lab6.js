const alphabetObj = {
  "а": "000001",
  "б": "001001",
  "в": "001010",
  "г": "001011",
  "д": "001100",
  "е": "000010",
  "ё": "000010",
  "ж": "001101",
  "з": "001110",
  "и": "000011",
  "й": "000011",
  "к": "001111",
  "л": "010000",
  "м": "010001",
  "н": "010010",
  "о": "000100",
  "п": "010011",
  "р": "010100",
  "с": "010101",
  "т": "010110",
  "у": "000101",
  "ф": "010111",
  "х": "011000",
  "ц": "011001",
  "ч": "011010",
  "ш": "011011",
  "щ": "011100",
  "ы": "011101",
  "ь": "011110",
  "ъ": "011110",
  "э": "000110",
  "ю": "000111",
  "я": "001000",
}

const alphabet = 'абвгдеёжзийклмнопрстуфхцчшщъыьэюя';
const forDel = alphabet.split("")

function encryption(text, gammaSign) {
  text = text
    .toLowerCase()
    .split("")
    .filter((item) => forDel.includes(item))
    .join("")

  const charNumberArray = text.split("").map((item) => Number.parseInt(alphabetObj[item],2))
  gammaSign = gammaSign.join("").repeat((charNumberArray.length/gammaSign.length)+1)

  let cipher = []

  for (let i = 0; i < charNumberArray.length; i++) {
    cipher.push((charNumberArray[i] ^ gammaSign[i]).toString(2).padStart(6,"0"))
  }
  return cipher
}

const gammaSignArray = [2, 3, 10, 4, 1, 5, 6, 7, 8, 11, 15, 14, 12, 13, 9, 0]

console.log(encryption("Помехоустойчивое кодирование – это кодирование с возможностью восстановления потерянных или ошибочно принятых данных.", gammaSignArray))
