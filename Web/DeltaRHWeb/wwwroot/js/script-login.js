const urlParams = new URLSearchParams(window.location.search);
const myParam = urlParams.get('error');
const myParam2 = urlParams.get('statuserror');
const paragrafoErro = document.getElementById("paragrafo-erro");
const paragrafoErroSt = document.getElementById("paragrafo-erro-st");
console.log(myParam)

if (myParam == "true") {
    paragrafoErro.style.display = "block";
}

if (myParam2 == "true") {
    paragrafoErroSt.style.display = "block";
}
