const urlParams = new URLSearchParams(window.location.search);
const myParam = urlParams.get('error');
const paragrafoErro = document.getElementById("paragrafo-erro");
console.log(myParam)

if (myParam == "true") {
    paragrafoErro.style.display = "block";
}