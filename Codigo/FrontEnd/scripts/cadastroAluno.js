let imagemForm;
let imagemNome;
let imageBase64;
let binaryString;

const saveProvider = (data) => {
  const renamedData = {
    nomeCompleto: data.nameAluno,
    nomeResponsavel: data.nameResp,
    email: data.emailAluno,
    dataAniversario: data.birthDate,
    senha: data.password,
    imagem: imagemNome,
    imagemUpload: imageBase64,
  }

  const xhr = new XMLHttpRequest();

  xhr.open('POST', 'https://tishellofriends.azurewebsites.net/api/autenticacao/registrar-aluno', true);
  xhr.setRequestHeader("Content-type", "application/json");

  xhr.onreadystatechange = () => {
    if (xhr.readyState == 4) {
      if (xhr.status == 200) {
        renderizaAlert('Usuário salvo com sucesso! Aguarde aprovação do professor.', 'success')
        setTimeout(() => {window.location.href="Login.html"}, 3000);
      }
      else {
        const { errors } = JSON.parse(xhr.responseText);
        Object.values(errors).forEach(erro => renderizaAlert(erro, 'danger'));
      }
    }

  }
  xhr.send(JSON.stringify(renamedData));

}

const formAluno = {
  getValue() {
    return {
      nameAluno: document.querySelector('#txtname').value,
      nameResp: document.querySelector('#txtrespname').value,
      emailAluno: document.querySelector('#txtmail').value,
      birthDate: document.querySelector('#datepicker').value,
      password: document.querySelector('#txtpass').value,
    }
  },

  validateFields() {
    const { nameAluno, nameResp, emailAluno, birthDate, password } = formAluno.getValue()
    if (nameAluno.trim() === "" || nameResp.trim() === "" || emailAluno.trim() === ""
      || birthDate.trim() === "" || password.trim() === "") {
      renderizaAlert('Por favor, preencha todos os campos', 'danger')
    }
  },

  formatProvider() {
    let { nameAluno, nameResp, emailAluno, birthDate, password } = formAluno.getValue()
    return {
      nameAluno, nameResp, emailAluno, birthDate, password
    }
  },

  clearProvider() {
    formAluno.nameAluno.value = ""
    formAluno.nameResp.value = ""
    formAluno.emailAluno.value = ""
    formAluno.birthDate.value = ""
    formAluno.password.value = ""
  },

  submit(event) {
    event.preventDefault()
    try {
      formAluno.validateFields()
      const SaveProvider = formAluno.formatProvider()
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
    renderizaAlert('Não foi possível carregar a imagem, formato não suportado', 'warning')
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
