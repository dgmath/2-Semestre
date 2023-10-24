
    async function chamaApi() {
        const cep = document.getElementById("cep").value;
        const url = `https://viacep.com.br/ws/${cep}/json/`;

        try {
            const promise = await fetch(url);
            const endereco = await promise.json();

            exibeEndereco(endereco);
            console.log(endereco)   
            document.getElementById("nao-encontrado").innerText = "";
        } catch (error) {
            console.log("Deu ruim na api");

            document.getElementById("nao-encontrado").innerText = "Cep inválido";
            apagaEndereco();
        }
    }

    function exibeEndereco(endereco) {
        document.getElementById("rua").value = endereco.logradouro;
        document.getElementById("bairro").value = endereco.bairro;
        document.getElementById("cidade").value = endereco.localidade;
        document.getElementById("UF").value = endereco.uf;
    }

    function apagaEndereco() {
        document.getElementById("endereco").value = "";
        document.getElementById("bairro").value = "";
        document.getElementById("cidade").value = "";
        document.getElementById("estado").value = "";
    }

    const urlLocal = "http://localhost:3000/contatos";

    async function Cadastrar(e) {
        e.preventDefault();//captura o evento de submit do form

        //pegar os dados do formulario

        const nome = document.getElementById("nome").value;
        const sobrenome = document.getElementById("sobrenome").value;
        const email = document.getElementById("email").value;
        const pais = document.getElementById("pais").value;
        const ddd = document.getElementById("ddd").value;

        const telefone = document.getElementById("telefone").value;
        const cep = document.getElementById("cep").value;
        const rua = document.getElementById("rua").value;
        const numero = document.getElementById("numero").value;
        const complemento = document.getElementById("complemento").value;
        const bairro = document.getElementById("bairro").value;
        const cidade = document.getElementById("cidade").value;
        const UF = document.getElementById("UF").value;
        const anotacoes = document.getElementById("anotacoes").value;

        const objContato = { nome, sobrenome, email, pais, ddd, telefone, cep, rua, complemento, numero, bairro, cidade, UF, anotacoes};

        try {
            const promise = await fetch(urlLocal,{
                //transforma um objeto em JSON stringficando o objeto
                body: JSON.stringify(objContato),
                headers: {"Content-Type" : "application/json"},
                method: "post"
            });

            const retorno = await promise.json();//pega o retorno da api
            console.log(retorno);

        } catch (error) {
            alert("Deu ruim" + error)
        }

    };

    function limparForm() {
         nome = document.getElementById("nome").value = "";
         sobrenome = document.getElementById("sobrenome").value = "";
         email = document.getElementById("email").value = "";
         pais = document.getElementById("pais").value = "";
         ddd = document.getElementById("ddd").value = "";

         telefone = document.getElementById("telefone").value = "";
         cep = document.getElementById("cep").value = "";
         rua = document.getElementById("rua").value = "";
         numero = document.getElementById("numero").value = "";
         complemento = document.getElementById("complemento").value = "";
         bairro = document.getElementById("bairro").value = "";
         cidade = document.getElementById("cidade").value = "";
         UF = document.getElementById("UF").value = "";
         anotacoes = document.getElementById("anotacoes").value = "";
    }
