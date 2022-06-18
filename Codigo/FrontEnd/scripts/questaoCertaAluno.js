let idUpdate;
let id = "c5ce6fcf-6adc-4a35-9a40-d5fe5e96e62c";
let idAtividadeOpcaoCertaEscolhida;
let idEscolhidoOpcaoCerta;
let questaoTxt;
let questaoVideo;
let questaoImg;
let pergunta;
let alternativaA;
let alternativaB;
let alternativaC;
let alternativaD;
let alternativaRespondida;
let respostaCerta;
const baseURL = `https://tishellofriends.azurewebsites.net/api/opcaocerta`;

function introducao() {
  fetch(baseURL, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      //process the returned data
      let divQuestaoTxt = document.getElementById('textAlQuestaoTxt');
      let divPergunta = document.getElementById('txtAlPergunta');
      let divAlternativaA = document.getElementById('textAlternativaA');
      let divAlternativaB = document.getElementById('textAlternativaB');
      let divAlternativaC = document.getElementById('textAlternativaC');
      let divAlternativaD = document.getElementById('textAlternativaD');

      let AtividadeEscolhida = JSON.parse(localStorage.getItem('atividadeOpcaoCerta'));
      idAtividadeOpcaoCertaEscolhida = AtividadeEscolhida.arg1;
      console.log("testefinal->", idAtividadeOpcaoCertaEscolhida);

      for (i = 0; i < data.length; i++) {
        if (data[i].id == idAtividadeOpcaoCertaEscolhida) {
          idEscolhidoOpcaoCerta = i;
        }
      }

      respostaCerta = data[idEscolhidoOpcaoCerta].alternativaCerta;
      if (data[idEscolhidoOpcaoCerta].texto != "") {
        questaoTxt = `<h3 class="textoAtiv">${data[idEscolhidoOpcaoCerta].texto}</h3>`;
        divQuestaoTxt.innerHTML = questaoTxt;
      }

      if (data[idEscolhidoOpcaoCerta].video != "") {
        let novaURL = data[idEscolhidoOpcaoCerta].video.split("=", 2);
        let url = ''.concat("https://www.youtube.com/embed/", novaURL[1]);
        let divTelaQuestao = document.getElementById('textAlQuestao');
        questaoVideo = `
                        <iframe class ="video" width="450" height="300"  src="${url}" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                        `;

        divTelaQuestao.innerHTML = questaoVideo;
      }

      let fileImagem = data[idEscolhidoOpcaoCerta].imagemSrc;
      let extImagem = fileImagem.substring(fileImagem.lastIndexOf('.') + 1);

      if (extImagem == "jpeg" || extImagem == "png" || extImagem == "jpg") {
        let divImg = document.getElementById('textAlQuestaoImg');
        questaoImg = `<img class="imagemAtiv" src="${data[idEscolhidoOpcaoCerta].imagemSrc}">`

        divImg.innerHTML = questaoImg;
      }

      pergunta = data[idEscolhidoOpcaoCerta].pergunta;
      alternativaA = data[idEscolhidoOpcaoCerta].alternativaA;
      alternativaB = data[idEscolhidoOpcaoCerta].alternativaB;
      alternativaC = data[idEscolhidoOpcaoCerta].alternativaC;
      alternativaD = data[idEscolhidoOpcaoCerta].alternativaD;

      divPergunta.innerHTML = pergunta;
      divAlternativaA.innerHTML = alternativaA;
      divAlternativaB.innerHTML = alternativaB;
      divAlternativaC.innerHTML = alternativaC;
      divAlternativaD.innerHTML = alternativaD;

    })
}

introducao();

const formAlternativaMarcada = {
  submit(event) {
    event.preventDefault()
    try {
      alternativaResposta();
    } catch (error) {
      alert(error.message)
    }
  }
}

let respostaCorreta = document.getElementsByName('alternativaMarcada');
function alternativaResposta() {
  for (var i = 0; i < respostaCorreta.length; i++) {
    if (respostaCorreta[i].checked) {
      alternativaRespondida = respostaCorreta[i].defaultValue;
    }
  }

  console.log(respostaCerta)

  if (alternativaRespondida == respostaCerta) {
    if(ehAluno()){
      salvarRespostaOpcaoCerta(1.0);
    }
    alert("Parabéns você acertou!");
    window.location.href = "listaAtividadesCompletaFrase.html";
  } else {
    if(ehAluno()){
      salvarRespostaOpcaoCerta(0.0);
    }
    alert("Infelizmente a resposta não está certa");
    window.location.href = "listaAtividadesCompletaFrase.html";
  }

  if(ehAluno()){
    atualizaMedalha();
  }
  console.log(alternativaRespondida);
}

recuperaIdAluno();