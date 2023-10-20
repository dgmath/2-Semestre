// const camisaLacoste = {
//     descricao: "Camisa Lacoste",
//     preco: 399.98,
//     marca: "Lacoste",
//     tamanho: "G",
//     cor: "Azul",
//     promo: true
// };

// const descricao = camisaLacoste.descricao;
// const preco = camisaLacoste.preco;
//let promo = camisaLacoste.promo;

// const {descricao, preco, promo} = camisaLacoste; //Destructuring = retiraar apenas aquilo que voce deseja do seu objeto

// console.log(`
//     Produto: ${descricao}
//     Preço: ${preco}
//     Promoção: ${promo ? "Sim" : "Não"}
// `);	

//If ternario ? : utilizado para nos retornar algo, como por exemplo acima foi usado para definir que caso seja o valor inicial(true) ? retorne o valor dado "Sim", caso não seja(else) retorne "Não"

/* crie um objeto evento com as propriedades 
    Data 
    Descrição
    Titulo
    Presença
    Comentário
*/

const evento = {
    dataEvento: new Date(),
    descricaoEvento: "Evento de aniversário",
    tituloEvento: "Niver do Math",
    presencaEvento: true,
    comentarioEvento: "Um evento maravilhoso"
}

const {dataEvento, descricaoEvento, tituloEvento, presencaEvento, comentarioEvento} = evento;

console.log(`
    Evento: ${tituloEvento}
    Descrição: ${descricaoEvento}
    Data: ${dataEvento}
    Presença: ${presencaEvento ? "Confirmada" : "Não confirmada"}
    Comentario: ${comentarioEvento}
`);
