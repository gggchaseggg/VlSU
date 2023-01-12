function alphabetsFromChar(char) {
  const charIndex = alphabet.indexOf(char);
  return alphabet.slice(charIndex) + alphabet.slice(0, charIndex)
}

function vizhenerEnc(text, key) {
  const encription = {
    keyLength: key.length,
    alphabets: key.toLowerCase().split("").map((item) => alphabetsFromChar(item)),
    nIndex: [],
    spaceIndex: []
  }

  text = text
    .toLowerCase()
    .split("")
    .filter((item) => forDel.includes(item))
    .join("")

  text.split("").forEach((item, idx) => {
    if (item === "\n") encription.nIndex.push(idx - encription.nIndex.length - encription.spaceIndex.length)
    else if (item === " ") encription.spaceIndex.push(idx - encription.nIndex.length - encription.spaceIndex.length)
  })

  return text
    .replaceAll("\n", " ")
    .replaceAll(" ", "")
    .split("")
    .map((char, idx) => Number.isInteger((idx + 1) / encription.keyLength) ? char + " " : char)
    .join("")
    .split(" ")
    .map((item) => item.split("").map((item, idx) => encription.alphabets[idx][alphabet.indexOf(item)]).join(""))
    .join("")
    .split("")
    .map((char, idx) => {
      if (encription.nIndex.includes(idx+1)) return char += "\n"
      else if (encription.spaceIndex.includes(idx+1)) return char += " "
      else return char
    })
    .join("")
}

function vizhenerDec(text, key) {
  const decription = {
    keyLength: key.length,
    alphabets: key.toLowerCase().split("").map((item) => alphabetsFromChar(item)),
    nIndex: [],
    spaceIndex: []
  }

  text = text
    .toLowerCase()
    .split("")
    .filter((item) => forDel.includes(item))
    .join("")

  text.split("").forEach((item, idx) => {
    if (item === "\n") decription.nIndex.push(idx - decription.nIndex.length - decription.spaceIndex.length)
    else if (item === " ") decription.spaceIndex.push(idx - decription.nIndex.length - decription.spaceIndex.length)
  })


  return text
    .replaceAll("\n", " ")
    .replaceAll(" ", "")
    .split("")
    .map((char, idx) => Number.isInteger((idx + 1) / decription.keyLength) ? char + " " : char)
    .join("")
    .split(" ")
    .map((item) => item.split("").map((item, idx) => alphabet[decription.alphabets[idx].indexOf(item)]).join(""))
    .join("")
    .split("")
    .map((char, idx) => {
      if (decription.nIndex.includes(idx+1)) return char += "\n"
      else if (decription.spaceIndex.includes(idx+1)) return char += " "
      else return char
    })
    .join("")
}

const alphabet = 'абвгдеёжзийклмнопрстуфхцчшщъыьэюя';
const forDel = alphabet.split("")
forDel.push(" ", "\n")


console.log("Шифр улыбки: \n", vizhenerEnc("от улыбки каждый день светлей", "мышь"))

console.log("\n----------------------------------------------\n")

console.log("Шифр романы: \n", vizhenerEnc(
  "Ей рано нравились романы\n" +
  "Они ей заменяли все\n" +
  "Она влюблялася в обманы\n" +
  "И Ричардсона и Руссо\n" , "идеал"))

console.log("\n----------------------------------------------\n")

console.log("Расшифровка чего-то: \n", vizhenerDec(
  "фуэ цтфж пгл уяпшыь эоуыь\n" +
  "т юшозхтаеь туте чрюцзуръгй\n" +
  "эя р тншуоэ нф тчлаы тямдп", "проза"))

console.log("\n----------------------------------------------\n")

console.log("Шифровка 1 вариант: \n", vizhenerEnc(
  "Не мысля гордый свет забавить,\n" +
  "Вниманье дружбы возлюбя,\n" +
  "Хотел бы я тебе представить\n" +
  "Залог достойнее тебя,\n" +
  "Достойнее души прекрасной,\n" +
  "Святой исполненной мечты,\n" +
  "Поэзии живой и ясной,\n" +
  "Высоких дум и простоты;\n" +
  "Но так и быть - рукой пристрастной\n" +
  "Прими собранье пестрых глав,\n" +
  "Полусмешных, полупечальных,\n" +
  "Простонародных, идеальных,\n" +
  "Небрежный плод моих забав,\n" +
  "Бессонниц, легких вдохновений,\n" +
  "Незрелых и увядших лет,\n" +
  "Ума холодных наблюдений\n" +
  "И сердца горестных замет.", "даниил"))

console.log("\n----------------------------------------------\n")

console.log("Расшифровка 1 вариант: \n", vizhenerDec(
  "се ъдъчг гьщмжн спны удбнксюа\n" +
  "высхлсьт мщякби кчупюоз\n" +
  "юъцещ йд к цеон шьидяыинмтй\n" +
  "ричтг счъютйынн юибм\n" +
  "мчэцочцнр зуёс шьикюиъщтй\n" +
  "якзютй цъшъпнтццън мтаыж\n" +
  "уокрсф кипчт ф гсычт\n" +
  "нясьусб зуъ с шьтсачыж\n" +
  "со аиу ф еыае щяооч шщфхтюиъюсоч\n" +
  "шщфри ячйьднйн шрхтюдю опап\n" +
  "шчччсънбщях эчфяуееифзсыг\n" +
  "шщъхтьциьтдыдю фзенфещях\n" +
  "ынйьижыдт ыпос хчфщ знйин\n" +
  "ееяъчщсид фнооиг кмъщнькнщмй\n" +
  "ынрьилию с яёясбсб пеа\n" +
  "ьхл щощчмщях ыийчвдтцсх\n" +
  "м стщмвд гьщнэцнию рлреа", "даниил"))

console.log("\n----------------------------------------------\n")

console.log("Шифровка 2 вариант: \n", vizhenerEnc(
  "\"Мой дядя самых честных правил,\n" +
  "Когда не в шутку занемог,\n" +
  "Он уважать себя заставил\n" +
  "И лучше выдумать не мог.\n" +
  "Его пример другим наука;\n" +
  "Но, боже мой, какая скука\n" +
  "С больным сидеть и день и ночь,\n" +
  "Не отходя ни шагу прочь!\n" +
  "Какое низкое коварство\n" +
  "Полуживого забавлять,\n" +
  "Ему подушки поправлять,\n" +
  "Печально подносить лекарство,\n" +
  "Вздыхать и думать про себя:\n" +
  "Когда же черт возьмет тебя!\"", "даниил"))

console.log("\n----------------------------------------------\n")

console.log("Расшифровка 2 вариант: \n", vizhenerDec(
  "роч мзпг снхдб ыеяыцжщ пюикфп\n" +
  "кьлмл се п бьюоу хицррор\n" +
  "чц яёафиыз хеоз рлхтнксч\n" +
  "м лбабр ёысьхлць ын хъж\n" +
  "ерч шьммтщ мьчгцх цлчкн\n" +
  "цч мтжт хчх оашиз эоуши\n" +
  "ъ мтлйцдш хисныз м дтце ф соее\n" +
  "цр ттгчмк си ёиля урьае\n" +
  "цдкьн цфлкьн уъёаюъынт\n" +
  "пьфьтмвьлч удбнкфкць\n" +
  "тхь ытдббуф уоэщинпяае\n" +
  "шрыащецъ уосцчэмтй фнцдряыкъ\n" +
  "ёзсдюлць ц мьшдтй шщъ хеоз\n" +
  "уъждн пн гира кчуамты ырея", "даниил"))