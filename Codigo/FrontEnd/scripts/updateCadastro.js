let imagemFormUpdate;
let imagemNomeUpdate;
let imageBase64Update;
let binaryStringUpdate;
let idUpdateAluno;
let nameAlunoUpdate;
let email;
let idAluno;

const url = 'https://localhost:44327/api/alunos';

//recupera do localStorage a atividade escolhida
let dadosAluno = JSON.parse(localStorage.getItem('userToken'));

function iniciarInformacoesUsuario() {

  let urlUpdateAluno = ''.concat(url, '/email/', dadosAluno.user.email);
  console.log(urlUpdateAluno);
  
  fetch(urlUpdateAluno, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      console.log(data.id);
      idUpdateAluno = data.id;
      var dataAniver = new Date(data.dataAniversario)
      var birthDateUpdateCerto = dataAniver.toISOString().slice(0,10)
      console.log(data.imagemSrc)

      document.getElementById('imageUpdateAluno').src = data.imagemSrc;
      document.querySelector('#txtnameUpdate').value = data.nomeCompleto;
      document.querySelector('#txtrespnameUpdate').value = data.nomeResponsavel;
      document.querySelector('#datepickerUpdate').value = birthDateUpdateCerto;

    }) 
};

const saveUpdateAluno = (data) => {
  const renamedData = {
    id: idUpdateAluno,
    nomeCompleto: data.nameAlunoUpdate,
    nomeResponsavel: data.nameRespUpdate,
    email: dadosAluno.user.email,
    dataAniversario:data.birthDateUpdate,
    status: true,
    situacao: "Aprovado",
    imagem: imagemNomeUpdate,
    imagemUpload: imageBase64Update,
  }

  console.log(renamedData);

  fetch(url, {
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
    method: 'PUT',
    body: JSON.stringify(renamedData),
  }).then(function (res) {
    window.location.href="modulos.html"   
  })
    .catch(function (res) { console.log(res) })
}



const formUpdateAluno = {
  getValue() {
    return {
      nameAlunoUpdate: document.querySelector('#txtnameUpdate').value,
      nameRespUpdate: document.querySelector('#txtrespnameUpdate').value,
      birthDateUpdate: document.querySelector('#datepickerUpdate').value,
    }
  },

  validateFieldsUpdate() {
    const { nameAlunoUpdate, nameRespUpdate, birthDateUpdate } = formUpdateAluno.getValue()
    if (nameAlunoUpdate.trim() === "" ||
      nameRespUpdate.trim() === "" || birthDateUpdate.trim() === "") {
      throw new Error("Por favor, preencha todos os campos")
    }else{
      console.log("value ok")
    }
  },

  formatUpdateAluno() {
    console.log("entrou");
    let { nameAlunoUpdate, nameRespUpdate, birthDateUpdate } = formUpdateAluno.getValue()
    return {
       nameAlunoUpdate, nameRespUpdate, birthDateUpdate
    }
  },

  submit(event) {
    event.preventDefault()
    try {
      console.log("teste");
      formUpdateAluno.validateFieldsUpdate()
      const SaveUpdateAluno = formUpdateAluno.formatUpdateAluno()      
      saveUpdateAluno(SaveUpdateAluno)
    } catch (error) {
      alert(error.message)
    }
  }
}

function checkfiles(event) {
  let fileNameUpdate = event.target.value;
  let extUpdate = fileNameUpdate.substring(fileNameUpdate.lastIndexOf('.') + 1);

  if (extUpdate == "jpeg" || extUpdate == "png" || extUpdate == "jpg") {
    return true;
  }
  else {
    return false;
  }
}

var loaderFileUpdateAluno = function (event) {
  var readerUpdateUpdate = new FileReader();

  if (!checkfiles(event)) {
    alert("Não foi possível carregar a imagem, formato não suportado!")
    return false;
  }

  readerUpdateUpdate.onload = function () {
    var outputUpdateAluno = document.getElementById("new");
    outputUpdateAluno.style.display = "block";
    outputUpdateAluno.style.backgroundImage = "url(" + readerUpdateUpdate.result + ")";
  }
  readerUpdateUpdate.readAsDataURL(event.target.files[0]);

  upload(event.target.files[0]);
};

function upload(file) {

  imagemFormUpdate = file;
  imagemNomeUpdate = file.name;

  console.log("NAME >>>>" + file.name);

  var readerUpdate = new FileReader();
  readerUpdate.onload = this.manipularreaderUpdate.bind(this);
  readerUpdate.readAsBinaryString(file);
};

function manipularreaderUpdate(readerUpdateEvt) {
  binaryStringUpdate = readerUpdateEvt.target.result;
  imageBase64Update = btoa(binaryStringUpdate);
};
iniciarInformacoesUsuario();