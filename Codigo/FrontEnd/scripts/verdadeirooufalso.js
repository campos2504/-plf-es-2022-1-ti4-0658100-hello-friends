let idUpdate;
let id = "c5ce6fcf-6adc-4a35-9a40-d5fe5e96e62c";
let idAtividadeOpcaoCertaEscolhida;
let idEscolhido;
let questaoTxt;
let questaoVideo;
let questaoImg;
let pergunta;
let alternativaRespondida;
let respostaCerta;
const baseURL = `https://localhost:44327/api/verdadeiro-falso`;

function introducao() {
  fetch(baseURL, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      console.log("VF-> ", data)
      let divQuestaoTxt = document.getElementById('textAlQuestaoTxt');
      let divPergunta = document.getElementById('txtAlPergunta');


      let AtividadeEscolhida = JSON.parse(localStorage.getItem('atividadeVerdadeiroFalso'));
      idAtividadeOpcaoCertaEscolhida = AtividadeEscolhida.arg1;
      console.log("testefinal->", idAtividadeOpcaoCertaEscolhida);

      for (i = 0; i < data.length; i++) {
        if (data[i].id == idAtividadeOpcaoCertaEscolhida) {
          idEscolhido = i;
        }
      }
      
      respostaCerta = data[idEscolhido].alternativaCerta;
      if (data[idEscolhido].texto != "") {
        questaoTxt = `<h3 class="textoAtiv">${data[idEscolhido].texto}</h3>`;
        divQuestaoTxt.innerHTML = questaoTxt;
      }

      if (data[idEscolhido].video != "") {
        let novaURL = data[idEscolhido].video.split("=", 2);
        let url = ''.concat("https://www.youtube.com/embed/", novaURL[1]);
        let divTelaQuestao = document.getElementById('textAlQuestao');
        questaoVideo = `
                        <iframe class ="video" width="450" height="300"  src="${url}" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                        `;

        divTelaQuestao.innerHTML = questaoVideo;
      }

      let fileImagem = data[idEscolhido].imagemSrc;
      let extImagem = fileImagem.substring(fileImagem.lastIndexOf('.') + 1);

      if (extImagem == "jpeg" || extImagem == "png" || extImagem == "jpg") {
        let divImg = document.getElementById('textAlQuestaoImg');
        questaoImg = `<img class="imagemAtiv" src="${data[idEscolhido].imagemSrc}">`

        divImg.innerHTML = questaoImg;
      }

      pergunta = data[idEscolhido].pergunta;

      divPergunta.innerHTML = pergunta;

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
      alternativaRespondida = respostaCorreta[i].value;
    }
  }

  console.log("respostacerta",respostaCerta);
  console.log("altenativa",JSON.parse(alternativaRespondida));

  if (respostaCerta ==JSON.parse(alternativaRespondida) ) {
    alert("Parabéns você acertou!");
    window.location.href = "listaAtividadesCompletaFrase.html";
  } else {
    alert("Infelizmente a resposta não está certa");
  }
  
}
