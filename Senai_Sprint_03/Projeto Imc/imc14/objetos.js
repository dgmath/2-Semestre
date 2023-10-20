let math = {
    nome : "Matheus",
    idade : 17,
    altura : 1.68,
    peso : 60
};//objeto literal

let cat = new Object();
cat.nome = "Catarina";
cat.idade = 16;

console.log(math);
console.log(cat);


const fruta = {};
const sacola = new Object();

sacola.itens = [];//lista//array

sacola.armazenaItem = function(item) {
    this.itens.push(item)
}

sacola.armazenaItem("Banana");
console.log(sacola.itens)

// console.log( typeof(fruta)); 
// console.log( typeof(sacola)); 

// fruta.nome = "Maçã"

// console.log(fruta);

// fruta.peso = 0.300;

// console.log(fruta);