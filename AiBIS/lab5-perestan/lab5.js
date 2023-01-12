function getCol(arr, idx) {
  let str = ""
  for (let k = 0; k < arr.length; k++) {
    if (arr[k][idx] !== undefined) str += arr[k][idx]
  }
  return str;
}

function encryption(text, key) {
  key = key.toLowerCase()
  text = text
    .toLowerCase()
    .split("")
    .filter((item) => forDel.includes(item))
    .join("")

  let charArray = []

  for (let i = 0; i < (text.length / key.length); i++) {
    if (i === 0) charArray.push(text.substring(0, key.length).split(""))
    else {
      charArray.push(text.substring(key.length*i, key.length*(i+1)).split(""))
    }
  }

  let keySorted = key.split("").map((item,idx) => item + idx).sort()
  let key2 = key.split("").map((item,idx) => item + idx)

  const queueArray = key2.map((item) => keySorted.indexOf(item))

  let cipher = ""

  let strMap = new Map()

  for (let i = 0; i < key.length; i++) {
    strMap.set(queueArray[i], getCol(charArray, i))
  }

  for (let i = 0; i < key.length; i++) {
    cipher += strMap.get(i)
  }
  return cipher;
}

const alphabet = 'абвгдеёжзийклмнопрстуфхцчшщъыьэюя';
const forDel = alphabet.split("")

const text = "Двадцать первое. Ночь. Понедельник. Очертанья столицы во мгле. Сочинил же какой-то бездельник, что бывает " +
  "любовь на земле. И от лености или от скуки все поверили, так и живут: ждут свиданий, боятся разлуки и любовные песни поют."

console.log("Пример: ",encryption("пусть будет так как мы хотели", "радиатор"))
console.log("\nВариант 1: ",encryption(text, "головоломка"))
console.log("\nВариант 2: ",encryption(text, "ловушка"))
console.log("\nВариант 3: ",encryption(text, "положение"))
console.log("\nВариант 4: ",encryption(text, "свобода"))