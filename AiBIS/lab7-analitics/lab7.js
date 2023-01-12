const alphabetArr = ["а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м",
  "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я"]

const alphabet = 'абвгдеёжзийклмнопрстуфхцчшщъыьэюя';
const forDel = alphabet.split("")

function multiplyMatrix(A,B) {
  let rowsA = A.length, colsA = A[0].length,
    rowsB = B.length, colsB = B[0].length,
    C = [];

  if (colsA !== rowsB) return false;

  for (let i = 0; i < rowsA; i++) C[ i ] = [];

  for (let k = 0; k < colsB; k++) {
    for (let i = 0; i < rowsA; i++) {
      let t = 0;
      for (let j = 0; j < rowsB; j++) t += A[ i ][j]*B[j][k];
      C[ i ][k] = t;
    }
  }

  return C;
}

function createVector(arr, length) {
  let newArr = arr.map((item) => [item])
  while (newArr.length < length) newArr.push([33])
  return newArr
}

function encryption(text, key) {
  text = text
    .toLowerCase()
    .split("")
    .filter((item) => forDel.includes(item))
    .join("")

  const charNumberArray = text.split("").map((item) => alphabetArr.indexOf(item))
  const cipher = []
  for (let i = 0; i < charNumberArray.length; i += key.length) {
    cipher.push(multiplyMatrix(key, createVector(charNumberArray.slice(i,i + key.length), key.length)))
  }
  return cipher.flat(2)
}

const matrix0 = [[14,8,3],[8,5,2],[3,2,1]]
const text0 = "ВАТАЛА"

console.log("Пример: ", encryption(text0, matrix0))

const text = "Помехоустойчивое кодирование – это кодирование с возможностью восстановления потерянных или ошибочно принятых данных"

const matrix1 = [[11,13,6],[7,4,15],[14,13,4]]
console.log("\nВариант 1: ", encryption(text, matrix1).join(""))

const matrix2 = [[1,8,7],[7,-5,8],[12,0,2]]
console.log("\nВариант 2: ", encryption(text, matrix2).join(""))

const matrix3 = [[1,3,2,5],[2,13,3,6],[5,9,5,-5],[4,7,11,29]]
console.log("\nВариант 3: ", encryption(text, matrix3).join(""))

const matrix4 = [[5,3,5,5],[12,0,2,3],[-4,7,1,2],[8,21,1,9]]
console.log("\nВариант 4: ", encryption(text, matrix4).join(""))