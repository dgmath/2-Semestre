// const somar = (x,y) => {
//     return x + y;
// };

// const somar = function(x,y) {
//     return x + y;
// }

// const somar = function name(x,y) {
//     return x + y;
// }

// const dobro = numero => numero * 2;
// const dobro = numero => {
//     return numero * 2;
// }
// const dobro = (numero) => {
//     return numero * 2;
// }

// const boaTarde = () => {console.log("Boa Tarde!");}

// console.log(somar(50,10));
// console.log(`O dobro deste numero é ${dobro(10)}`);
// console.log(boaTarde());

const convidados = [
    {nome : "Carlos", idade: 43},
    {nome : "Catarina", idade: 17},
    {nome : "Eduardo", idade: 40},
    {nome : "Claiton", idade: 54},
    {nome : "Rebeca", idade: 13},
    {nome : "Magalhaes", idade: 66},
    {nome : "Guilherme", idade: 21}
];

convidados.forEach( p => {
    console.log(`Pessoa convidada: ${p.nome} Idade: ${p.idade}`);
})
