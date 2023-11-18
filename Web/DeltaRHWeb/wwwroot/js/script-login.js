const urlParams = new URLSearchParams(window.location.search);
const myParam = urlParams.get('error');
const myParam2 = urlParams.get('statuserror');
const myParam3 = urlParams.get('sessaoInvalida');
const paragrafoErro = document.getElementById("paragrafo-erro");
const paragrafoErroSt = document.getElementById("paragrafo-erro-st");
const paragrafoErroSi = document.getElementById("paragrafo-erro-si");
console.log(myParam)

if (myParam == "true") {
    paragrafoErro.style.display = "block";
}

if (myParam2 == "true") {
    paragrafoErroSt.style.display = "block";
}

if (myParam3 == "true") {
    paragrafoErroSi.style.display = "block"
}
