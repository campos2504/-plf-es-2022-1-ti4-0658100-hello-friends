let imagemFormUpdate;
let imagemNomeUpdate;
let imageBase5;
let binaryStringUpdate;
let idUpdateAluno;
let nomeUsuario;
let nomeResp;
let nameAluno;
let email;
let idAluno;

const url = 'https://localhost:44327/api/alunos';

//recupera do localStorage a atividade escolhida
let dadosAluno = JSON.parse(localStorage.getItem('userToken'));
console.log(dadosAluno);
/*idUpdateAluno = dadosAluno.user.id;*/
idUpdateAluno = 4;
console.log("testefinal->", idUpdateAluno);


function iniciarInformacoesUsuario() {

  let urlUpdateAluno = ''.concat(url, '/', idUpdateAluno);
  console.log(urlUpdateAluno);
  
  fetch(urlUpdateAluno, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      console.log(data)
      nomeUsuario = data.nomeCompleto;
      nomeResp = data.nomeResponsavel;
      email = data.email;
      birthDate = data.dataAniversario;
      var dataAniver = new Date(birthDate)
      var birthDateCerto = dataAniver.toISOString().slice(0,10)

      document.querySelector('#txtnameUpdate').value = nomeUsuario;
      document.querySelector('#txtrespname').value = nomeResp;
      document.querySelector('#txtmail').value = email;
      document.querySelector('#datepicker').value = birthDateCerto;

    }) 

};

const saveUpdateAluno = (data) => {
  const renamedData = {
    idAluno: idUpdateAluno,
    nameAluno: data.nameAluno,
    nameResp: data.nameResp,
    emailAluno: data.emailAluno,
    dataAniversario:data.birthDate,
    imagem: imagemNomeUpdate,
    imagemUpload: imageBase64Update,
  }

  console.log(url);

  fetch(url, {
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
    method: 'put',
    body: JSON.stringify(renamedData),
  }).then(function (res) {
    window.location = 'Login.html'
  })
    .catch(function (res) { console.log(res) })
}



const formUpdateAluno = {
  nameAluno: document.querySelector('#txtnameUpdate').value,
  nameResp: document.querySelector('#txtrespname').value,
  emailAluno: document.querySelector('#txtmail').value,
  birthDate: document.querySelector('#datepicker').value,

  getValue() {
    return {
      nameAluno: nameAluno.value,
      nameResp: nameResp.value,
      emailAluno: emailAluno.value,
      birthDate: birthDate.value,
    }
  },

  validateFields() {
    const { nameAluno, nameResp, emailAluno, birthDate } = formUpdateAluno.getValue()
    if (nameAluno.trim() === "" ||
      nameResp.trim() === "" || emailAluno.trim() === ""
      || birthDate.trim() === "") {
      throw new Error("Por favor, preencha todos os campos")
    }else{
      console.log("value ok")
    }
  },

  formatAluno() {
    let { nameAluno, nameResp, emailAluno, birthDate } = formUpdateAluno.getValue()
    return {
       nameAluno, nameResp, emailAluno, birthDate
    }
  },

  submit(event) {
    event.preventDefault()
    try {
      console.log("entrou");
      formUpdateAluno.validateFields()
      const SaveUpdateAluno = formUpdateAluno.formatAluno()
      console.log("->", SaveUpdateAluno);
      saveUpdateAluno(SaveUpdateAluno)
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
    var output = document.getElementById("new");
    output.style.display = "block";
    output.style.backgroundImage = "url(" + reader.result + ")";
  }
  reader.readAsDataURL(event.target.files[0]);

  upload(event.target.files[0]);
};

function upload(file) {

  imagemFormUpdate = file;
  imagemNomeUpdate = file.name;

  console.log("NAME >>>>" + file.name);

  var reader = new FileReader();
  reader.onload = this.manipularReader.bind(this);
  reader.readAsbinaryString(file);
};

function manipularReader(readerEvt) {
  binaryStringUpdate = readerEvt.target.result;
  imageBase64Update = btoa(binaryStringUpdate);
};
iniciarInformacoesUsuario();