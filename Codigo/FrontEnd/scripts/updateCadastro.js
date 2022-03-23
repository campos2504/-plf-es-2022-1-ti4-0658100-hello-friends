let imagemForm;
let imagemNome;
let imageBase64;
let binaryString;
const url = 'https://localhost:44380/api/autenticacao/';

function iniciarInformacoesUsuario() {
  let usuario = JSON.parse(localStorage.getItem('-------'));
  let idUsuario = usuario.id;
  let nomeUsuaria = usuario.nomeUsuaria;
  let nomeResp = usuario.Resp;
  let email = usuario.email;
  let birthDate = usuario.birthDate;

  document.querySelector('#txtname').value = nomeUsuaria;
  document.querySelector('#txtrespname').value = nomeResp;
  document.querySelector('#txtmail').value = email;
  document.querySelector('#datepicker').value = birthDate;

};

const saveUpdateProduct = (data) => {
  const renamedData = {
    idAluno: data.idAluno,
    nameAluno: data.nameAluno,
    nameResp: data.nameResp,
    emailAluno: data.emailAluno,
    birthDate=data.birthDate,
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
    window.location = 'consultarProdutos.html'
  })
    .catch(function (res) { console.log(res) })
}

const formUpdateUsuario = {
  idAluno,
  nameAluno: document.querySelector('#txtname').value,
  nameResp: document.querySelector('#txtrespname').value,
  emailAluno: document.querySelector('#txtmail').value,
  birthDate: document.querySelector('#datepicker').value,

  getValue() {
    return {
      idAluno: idAluno.value,
      nameAluno: nameAluno.value,
      nameResp: nameResp.value,
      emailAluno: emailAluno.value,
      birthDate: birthDate.valua,
    }
  },

  validateFields() {
    const { idAluno, nameAluno, nameResp, emailAluno, birthDate } = formUpdateProduto.getValue()
    if (idAluno.trim() === "" || nameAluno.trim() === "" ||
      nameResp.trim() === "" || emailAluno.trim() === ""
      || birthDate.trim() === "") {
      throw new Error("Por favor, preencha todos os campos")
    }
  },

  formatProduct() {
    let { idAluno, nameAluno, nameResp, emailAluno, birthDate } = formUpdateProduto.getValue()
    return {
      idAluno, nameAluno, nameResp, emailAluno, birthDate
    }
  },

  submit(event) {
    event.preventDefault()
    try {
      formUpdateProduto.validateFields()
      const SaveUpdateProduct = formUpdateProduto.formatProduct()
      saveUpdateProduct(SaveUpdateProduct)
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
