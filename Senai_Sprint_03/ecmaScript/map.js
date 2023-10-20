//foreach - void
//map - retorna novo array modificado
//filter - Retorna somente elementos que atenderam a uma condição
//reduce - Valor unificado

//------------- Função map -----------------

const numeros = [1,2,5,10,300];

const dobro = numeros.map( (n) => {
    return n * 2
} );

//console.log(numeros);
console.log(dobro);

//------------- Função Filter ----------------

const numbers = [1,2,5,10,300];

const maiorQ10 = numbers.filter( (e) => {
    return e > 10;
})

console.log(numbers);
console.log(maiorQ10);

const comentarios = [
    {comentario: "bla bla bla bla", exibe: true},
    {comentario: "jdjkkdks", exibe: false},
    {comentario: "oioi", exibe: true}
];

const comentariosOk = comentarios.filter((c) => {
    return c.exibe == true   
})

comentariosOk.forEach( c => {
    console.log(`Comentario: ${c.comentario}`)
}  )

//------------- Função Reduce ---------------

 const num = [1,2,5,10,300];

 const soma = num.reduce( (vlInical, n) => {
    return vlInical + n
 },0)

 console.log(soma);