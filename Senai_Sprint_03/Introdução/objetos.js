let eduardo = {
    nome : "Eduardo",
    idade : 41,
    altura : 1.67
};

eduardo.peso = 89;

let carlos = new Object();

carlos.nome = "Carlos";
carlos.idade = 36;
carlos.sobrenome = "Roque";

let pessoas = [];

pessoas.push(eduardo);
pessoas.push(carlos);

console.log(pessoas);

pessoas.forEach(function(p,i){
    console.log(`Nome ${i+1}: ${p.nome}`)
});

