const saveProvider = (data) => {
  console.log("Data", data)
  const renamedData = {
    email: data.email,
  }
  const xhr = new XMLHttpRequest();

  xhr.open('POST', 'http://tishellofriends.azurewebsites.net/api/forgotpassword/recoveryEmail', true);
  xhr.setRequestHeader("Content-type", "application/json");

  xhr.onreadystatechange = () => {
    if (xhr.readyState == 4) {
      if (xhr.status == 200) {
        console.log(xhr.responseText);
        throw new Error("Email enviado")
      }
      else {
        console.log(xhr.responseText);
        throw new Error("Error")
      }
    }
  }

  xhr.send(JSON.stringify(renamedData));
}

const formRecovery = {
  getValue() {
    return {
      email: document.querySelector('#txtmail').value,
    }
  },

  validateFields() {
    const { email } = formRecovery.getValue()
    if (email.trim() === "") {
      throw new Error("Por favor, preencha todos o email")
    }
  },

  formatProvider() {
    let { email } = formRecovery.getValue()
    return {
      email
    }
  },

  clearProvider() {
    formRecovery.email.value = ""
  },

  submit(event) {
    event.preventDefault()
    try {
      formRecovery.validateFields()
      const SaveProvider = formRecovery.formatProvider()
      saveProvider(SaveProvider)
    } catch (error) {
      alert(error.message)
    }
  }
}


