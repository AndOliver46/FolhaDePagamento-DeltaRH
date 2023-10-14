const botaoInfos = document.querySelector(".botao-infos")
const botaoAprovacoes = document.querySelector(".botao-aprovacoes")
const viewMissao = document.querySelector(".container-infos-missao")
const viewAprovacoes = document.querySelector(".container-aprovacoes")

botaoInfos.addEventListener("click", function(){
    viewAprovacoes.classList.add('sumiu');
    viewMissao.classList.remove('sumiu');
})

botaoAprovacoes.addEventListener("click", function(){
    viewMissao.classList.add('sumiu');
    viewAprovacoes.classList.remove('sumiu')
})
