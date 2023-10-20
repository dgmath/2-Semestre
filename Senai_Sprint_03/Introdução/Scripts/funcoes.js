function calcular()
{
    event.preventDefault();
    let n1 = parseFloat(document.getElementById("numero1").value);
    let n2 = parseFloat(document.getElementById("numero2").value);
    let res; // = n1 + n2
    let op = document.getElementById("operacao").value;

    if( isNaN(n1) || isNaN(n2) )
    {
        alert("Preencha todos os campos!")
        return;
    }
    
    if (op == '+') {
        res = somar(n1,n2);     
    }
    else if (op == '-')
    {
        res = subtrair(n1,n2);
    }
    else if (op == '*') {
        res = mult(n1,n2);               
    }
    else if (op == '/') {
        res = div(n1,n2);
    }
    else
    {
        res = "Operação invalida! Insira uma das (+,-,*,/)"
    }

    //let res = parseFloat(n1) + parseFloat(n2); Parse float espera uma string e retorna um number;

    document.getElementById('resultado').innerText = res;
}

function somar(x,y) {
    return (x + y).toFixed(2);
}

function subtrair(x,y) {
    return (x - y).toFixed(2);
}

function mult(x,y)
{
    return (x * y).toFixed(2);
}

function div(x,y)
{
    if (y == 0) {
        return "Não é possivel dividir por zero"
    }
    //validar divisao por 0
    return (x / y).toFixed(2);
}
