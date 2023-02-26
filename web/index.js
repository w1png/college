// #1
const n = prompt('Enter a number');
if (n > 0) {
  alert(1);
} else if (n < 0) {
  alert(-1);
} else {
  alert(0);
}

// #2
const a = 0;
const b = 1;
let result = (a + b < 4) ? "Мало" : "Много";

// #3
const age = 14;
if (age >= 14 && age <= 90) {
  alert("Верно");
}

// #4
const login = prompt("Введите логин");
if (login === 'Админ') {
  const password = prompt("Введите пароль");
  if (password === 'Я главный') {
    alert('Здравствуйте!');
  } else if (password === null) {
    alert('Отменено');
  } else {
    alert('Неверный пароль');
  }
}


