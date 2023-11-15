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
        var status = statusElement.textContent.trim(); // Obter o valor do status e remover espaços em branco

        // Verificar se o status é igual a "Aprovado".
        if (status === "Aprovado" || status === "Reprovado" || status === "Processado") {
            // Encontrar a linha (elemento pai) que contém o status.
            var folhaElement = statusElement.closest('.folha');

            // Desativar todos os botões na linha.
            var buttons = folhaElement.querySelectorAll('button');
            buttons.forEach(function (button) {
                button.disabled = true;
                button.classList.add('button-disabled');
            });
        }
    });
});