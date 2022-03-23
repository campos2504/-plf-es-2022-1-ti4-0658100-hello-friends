
const saveProvider = (data) => {
  console.log("Data", data)
  const renamedData = {
    token: data.token,
    email: data.email,
    password: data.senha,
    comfirmPassword: data.senhaRepitida,
  }
  const xhr = new XMLHttpRequest();

  xhr.open('POST', 'https://localhost:44327/api/forgotpassword/resetPassword', true);
  xhr.setRequestHeader("Content-type", "application/json");

  xhr.onreadystatechange = () => {
    if (xhr.readyState == 4) {
      if (xhr.status == 200) {
        console.log(xhr.responseText);
        throw new Error("Senha alterada")
      }
      else {
        console.log(xhr.responseText);
        throw new Error("Senha não alterada")
      }
    }
  }

  xhr.send(JSON.stringify(renamedData));
}


const formRecovery = {
  getValue() {
    var params = new URLSearchParams(window.location.search);
    return {
      token: params.get("token").replaceAll(" ", "+"),
      email: params.get("email"),
      senha: document.querySelector('#txtpass').value,
      senhaRepitida: document.querySelector('#txtrepeatpass').value,
    }
  },

  validateFields() {
    const { senha, senhaRepitida } = formRecovery.getValue()
    if (senha.trim() === "" || senhaRepitida.trim() === "") {
      throw new Error("Por favor, preencha todos os campos")
    }
    if (senha != senhaRepitida) {
      throw new Error("Senhas diferentes")
    }
  },

  clearProvider() {
    formRecovery.senha.value = ""
  },

  submit(event) {

    event.preventDefault()
    try {
      formRecovery.validateFields()
      const SaveProvider = formRecovery.getValue();
      saveProvider(SaveProvider)
    } catch (error) {
      alert(error.message)
    }
  }
}

