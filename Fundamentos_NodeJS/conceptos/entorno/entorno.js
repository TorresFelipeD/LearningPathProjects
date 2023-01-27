require('dotenv').config();

let nombre = process.env.NOMBRE || "Dante";
console.log("Hola " + nombre);