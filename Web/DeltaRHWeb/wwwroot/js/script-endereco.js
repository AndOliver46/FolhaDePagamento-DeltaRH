const formEndereco = document.getElementById("form-endereco")
const cepInput = document.querySelector("#cep")
const estadoInput = document.querySelector("#estado")
const cidadeInput = document.querySelector("#cidade")
const bairroInput = document.querySelector("#bairro")
const ruaInput = document.querySelector("#rua")
const formInputs = document.querySelectorAll("data-input")


// Add or remove disable attribute
const toggleDisabled = () => {
    if (cidadeInput.hasAttribute("disabled")) {
        formInputs.forEach((input) => {
            input.removeAttribute("disabled");
        });
    } else {
        formInputs.forEach((input) => {
            input.setAttribute("disabled", "disabled");
        });
    }
};


//Loader
const aparecerLoader = () => {
    const fade = document.querySelector("#fade");
    const loader = document.querySelector("#loader");

    fade.classList.toggle("hide");
    loader.classList.toggle("hide");
}

//Apenas numeros
cepInput.addEventListener("keypress", (e) => {
    const apenasNumeros = /[0-9]/;
    const key = String.fromCharCode(e.keyCode);

    //permissao
    if (!apenasNumeros.test(key)) {
        e.preventDefault()
        return;
    }
})

// Digitando 8 digitos
cepInput.addEventListener("keyup", (e) => {

    const inputValor = e.target.value;

    if (inputValor.length === 8) {
        getEndereco(inputValor);
    }
})

// Buscando cep na API
const getEndereco = async (cep) => {
    aparecerLoader();

    cepInput.blur();

    const apiURL = `https://viacep.com.br/ws/${cep}/json/`;

    try {
        const response = await Promise.race([
            fetch(apiURL),
            new Promise((_, reject) => setTimeout(() => reject(new Error('Timeout')), 5000))
        ]);

        const data = await response.json();

        // Error
        if (data.erro === true) {
            document.getElementById("form-endereco").reset();
            aparecerLoader();
            return;
        }

        cidadeInput.value = data.localidade;
        ruaInput.value = data.logradouro;
        bairroInput.value = data.bairro;
        estadoInput.value = data.uf;

        if (ruaInput.hasAttribute("disabled")) {
            formInputs.forEach((input) => {
                input.removeAttribute("disabled");
            });
        }

        aparecerLoader();
    } catch (error) {
        // Trate o erro aqui (pode ser um timeout)
        console.error("Erro na requisição:", error.message);
        aparecerLoader();
    }
};

formEndereco.addEventListener("submit", (e) => {
    aparecerLoader();

    setTimeout(() => {
        aparecerLoader();
    }, 1500);
});
