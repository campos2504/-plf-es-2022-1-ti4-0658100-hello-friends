let imagemForm;
let imagemNome;
let imageBase64;
let binaryString;
let alternativaCerta;
let idModuloEscolhidoOC;

let moduloEscolhido = JSON.parse(localStorage.getItem('moduloCorrente'));
idModuloEscolhidoOC = moduloEscolhido.event;

const saveProvider = (data) => {
  const renamedData = {
    id:JSON.parse(localStorage.getItem('atividadeUpdateVF')).event,
    titulo: data.tituloAtiv,
    texto: data.textoQuestao,
    imagem: imagemNome,
    imagemSrc: imageBase64,
    video: data.linkVideo,
    moduloId: idModuloEscolhidoOC,
    pergunta: data.pergunta,
    alternativaCerta: alternativaCerta,
  }
  console.log(renamedData);

  const xhr = new XMLHttpRequest();

  xhr.open('PUT', 'https://tishellofriends.azurewebsites.net/api/verdadeiro-falso', true);
  xhr.setRequestHeader("Content-type", "application/json");
  xhr.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);

  xhr.onreadystatechange = () => {
    if (xhr.readyState == 4) {
      if (xhr.status == 200) {
        alert("Atividade atualizada com sucesso");
        window.location.href="listaAtividadesCompletaFrase.html"
        console.log(xhr.responseText);
      }
      else {
        console.log(xhr.responseText);
      }
    }
  }

  xhr.send(JSON.stringify(renamedData));
}


const formAtividade = {
  getValue() {
    return {
      tituloAtiv: document.querySelector('#txtTitulo').value,
      textoQuestao: document.querySelector('#txtQuestao').value,
      pergunta: document.querySelector('#txtPergunta').value,
      linkVideo: document.querySelector('#linkVideo').value,
    }
  },


  validateFields() {
    const { pergunta, tituloAtiv } = formAtividade.getValue();
    if (pergunta.trim() === ""  || tituloAtiv.trim() === "") {
      throw new Error("Por favor, preencha todos os campos")
    }
  },


  formatProvider() {
    let { tituloAtiv, textoQuestao, linkVideo, pergunta } = formAtividade.getValue()
    return {
      tituloAtiv, textoQuestao, linkVideo, pergunta
    }
  },

  clearProvider() {
    formAtividade.tituloAtiv.value = ""
    formAtividade.textoQuestao.value = ""
    formAtividade.pergunta.value = ""
    formAtividade.linkVideo.value = ""
  },

  submit(event) {
    event.preventDefault()
    try {
      formAtividade.validateFields()
      altertivaCerta();
      const SaveProvider = formAtividade.formatProvider()
      saveProvider(SaveProvider)
    } catch (error) {
      alert(error.message)
    }
  }

}

function checkfiles(event) {
  let fileName = event.target.value;
  let ext = fileName.substring(fileName.lastIndexOf('.') + 1);

  if (ext == "jpeg" || ext == "png" || ext == "jpg") {
    return true;
  }
  else {
    return false;
  }
}

var loaderFile = function (event) {
  var reader = new FileReader();

  if (!checkfiles(event)) {
    alert("Não foi possível carregar a imagem, formato não suportado!")
    return false;
  }

  reader.onload = function () {
    var output = document.getElementById("newImagem");
    output.style.display = "block";
    output.style.backgroundImage = "url(" + reader.result + ")";
  }
  reader.readAsDataURL(event.target.files[0]);

  upload(event.target.files[0]);
};

function upload(file) {

  imagemForm = file;
  imagemNome = file.name;

  console.log("NAME >>>>" + file.name);

  var reader = new FileReader();
  reader.onload = this.manipularReader.bind(this);
  reader.readAsBinaryString(file);
};

function manipularReader(readerEvt) {
  binaryString = readerEvt.target.result;
  imageBase64 = btoa(binaryString);
};

let respostaCorreta = document.getElementsByName("alternativa");
function altertivaCerta() {
  for (var i = 0; i < respostaCorreta.length; i++) {
    if (respostaCorreta[i].checked) {
      alternativaCerta = respostaCorreta[i].defaultValue;
    }
  }
}

////

function introducao() {
  let AtividadeEscolhida = JSON.parse(localStorage.getItem('atividadeUpdateVF'));

  let urlUpdate = ''.concat('https://tishellofriends.azurewebsites.net/api/verdadeiro-falso/', AtividadeEscolhida.event);
  fetch(urlUpdate, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {

      document.querySelector('#txtTitulo').value= data.titulo;
      document.querySelector('#txtQuestao').value= data.texto;
      document.querySelector('#txtPergunta').value= data.pergunta;
      document.querySelector('#linkVideo').value= data.video;
      document.getElementById('newImagem').src = data.imagemSrc;
      let  respostas= document.getElementsByName("alternativa");
      console.log("olas ",respostas)
      if(data.alternativaCerta){
        respostas[0].checked=true
      }else{
        respostas[1].checked=true
      }


      
      
    

    })
}

