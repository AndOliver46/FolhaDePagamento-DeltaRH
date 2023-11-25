const botaoInfos = document.querySelector(".botao-infos");
const botaoAprovacoes = document.querySelector(".botao-aprovacoes");
const viewMissao = document.querySelector(".container-infos-missao");
const viewAprovacoes = document.querySelector(".container-aprovacoes");


botaoInfos.addEventListener("click", function(){
    viewAprovacoes.classList.add('sumiu');
    viewMissao.classList.remove('sumiu');

    botaoInfos.classList.add('botao-ativo')
    botaoAprovacoes.classList.remove('botao-ativo')
})

botaoAprovacoes.addEventListener("click", function(){
    viewMissao.classList.add('sumiu');
    viewAprovacoes.classList.remove('sumiu');

    botaoAprovacoes.classList.add('botao-ativo')
    botaoInfos.classList.remove('botao-ativo')
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



const aprovaFolha = document.querySelector(".bt-aprovaFolha")
const reprovaFolha = document.querySelector(".bt-reprovaFolha")
const notification = document.getElementById("modal-lateral")
const folhaAprovada = '<i class="bi bi-check-circle-fill" style="color: green;"></i> Folha aprovada com sucesso'
const folhaReprovada = '<i class="bi bi-x-circle-fill" style="color: red;"></i> Folha reprovada com sucesso'

function showNotification(msg) {
    const toast = document.createElement('div');

    toast.classList.add('toast');
    toast.innerHTML = msg;
    notification.appendChild(toast);

    setTimeout(() => {
        toast.remove();
    }, 2000);
}