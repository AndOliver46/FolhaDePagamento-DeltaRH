const cnpjInput = document.querySelector("#CNPJ")
const cpfResponsavel = document.querySelector("#CPFResponsavel")
const telefone = document.querySelector("#Telefone")
const telefone2 = document.querySelector("#Telefone2")

//Apenas numeros
function permitirApenasNumeros(inputElement) {
    inputElement.addEventListener("keypress", (e) => {
        const apenasNumeros = /[0-9]/;
        const key = String.fromCharCode(e.keyCode);

        if (!apenasNumeros.test(key)) {
            e.preventDefault();
        }
    });
}

permitirApenasNumeros(cnpjInput);
permitirApenasNumeros(cpfResponsavel);
permitirApenasNumeros(telefone);
permitirApenasNumeros(telefone2);

//Apenas letras
function permitirApenasLetras(inputElement) {
    inputElement.addEventListener("keypress", (e) => {
        const apenasLetras = /[a-zA-Z\u00C0-\u00FF ]+/i;
        const key = String.fromCharCode(e.keyCode);

        if (!apenasLetras.test(key)) {
            e.preventDefault();
        }
    });
}

const responsavel = document.querySelector("#Responsavel")
permitirApenasLetras(responsavel);