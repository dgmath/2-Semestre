const evento = {
    dataEvento: new Date(),
    descricao : "Venha aprender JavaScript e todo seu poder!!",
    titulo: "Mão na massa EcmaScript",
    presenca : true,
    comentario: "Gostei do evento"
}

const {dataEvento, descricao, titulo, ...rest} = evento;

console.log(dataEvento);
console.log(descricao);
console.log(titulo);
console.log(rest);

// console.log(`
//     Evento: ${titulo}
//     Descrição: ${descricao}
//     Data: ${dataEvento}
//     Presença: ${presenca ? "Confirmada": "Não confirmada"}
//     Comentário: ${comentario}
// `);