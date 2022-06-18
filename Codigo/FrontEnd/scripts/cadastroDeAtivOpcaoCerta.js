let imagemForm;
let imagemNome;
let imageBase64;
let binaryString;
let alternativaCerta;
let idModuloEscolhidoOC;

let moduloEscolhido = JSON.parse(localStorage.getItem('moduloCorrente'));
idModuloEscolhidoOC = moduloEscolhido.event;
console.log("testefinal->", idModuloEscolhidoOC);

const saveProvider = (data) => {
  const renamedData = {
    titulo: data.tituloAtiv,
    texto: data.textoQuestao,
    imagem: imagemNome,
    imagemSrc: imageBase64,
    video: data.linkVideo,
    moduloId: idModuloEscolhidoOC,
    pergunta: data.pergunta,
    alternativaA: data.alternativaA,
    alternativaB: data.alternativaB,
    alternativaC: data.alternativaC,
    alternativaD: data.alternativaD,
    alternativaCerta: alternativaCerta,
  }
  console.log(renamedData);

  const xhr = new XMLHttpRequest();

  xhr.open('POST', 'https://tishellofriends.azurewebsites.net/api/opcaocerta', true);
  xhr.setRequestHeader("Content-type", "application/json");
  xhr.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);

  xhr.onreadystatechange = () => {
    if (xhr.readyState == 4) {
      if (xhr.status == 200) {
        alert("Atividade criada com sucesso");
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
      alternativaA: document.querySelector('#txtAlternativaA').value,
      alternativaB: document.querySelector('#txtAlternativaB').value,
      alternativaC: document.querySelector('#txtAlternativaC').value,
      alternativaD: document.querySelector('#txtAlternativaD').value,
    }
  },


  validateFields() {
    const { pergunta, alternativaA, alternativaB, alternativaC, alternativaD, tituloAtiv } = formAtividade.getValue();
    console.log("entrei");
    if (pergunta.trim() === "" || alternativaA.trim() === "" || alternativaB.trim() === ""
      || alternativaC.trim() === "" || alternativaD.trim() === "" || tituloAtiv.trim() === "") {
      throw new Error("Por favor, preencha todos os campos")
    }
  },


  formatProvider() {
    let { tituloAtiv, textoQuestao, linkVideo, pergunta, alternativaA, alternativaB, alternativaC, alternativaD } = formAtividade.getValue()
    return {
      tituloAtiv, textoQuestao, linkVideo, pergunta, alternativaA, alternativaB, alternativaC, alternativaD
    }
  },

  clearProvider() {
    formAtividade.tituloAtiv.value = ""
    formAtividade.textoQuestao.value = ""
    formAtividade.pergunta.value = ""
    formAtividade.alternativaA.value = ""
    formAtividade.alternativaB.value = ""
    formAtividade.alternativaC.value = ""
    formAtividade.alternativaD.value = ""
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
  console.log(alternativaCerta);
}


