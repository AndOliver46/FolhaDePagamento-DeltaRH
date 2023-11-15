const botaoInfos = document.querySelector(".botao-infos");
const botaoAprovacoes = document.querySelector(".botao-aprovacoes");
const viewMissao = document.querySelector(".container-infos-missao");
const viewAprovacoes = document.querySelector(".container-aprovacoes");


botaoInfos.addEventListener("click", function(){
    viewAprovacoes.classList.add('sumiu');
    viewMissao.classList.remove('sumiu');
})

botaoAprovacoes.addEventListener("click", function(){
    viewMissao.classList.add('sumiu');
    viewAprovacoes.classList.remove('sumiu');
})

window.addEventListener('DOMContentLoaded', function () {
    // Selecionar todos os elementos com a classe "status-item".
    var statusItems = document.querySelectorAll('.status-item');

    statusItems.forEach(function (statusElement) {
        var status = statusElement.textContent.trim(); // Obter o valor do status e remover espa�os em branco

        // Verificar se o status � igual a "Aprovado".
        if (status === "Aprovado" || status === "Reprovado" || status === "Processado") {
            // Encontrar a linha (elemento pai) que cont�m o status.
            var folhaElement = statusElement.closest('.folha');

            // Desativar todos os bot�es na linha.
            var buttons = folhaElement.querySelectorAll('button');
            buttons.forEach(function (button) {
                button.disabled = true;
                button.classList.add('button-disabled');
            });
        }
    });
});