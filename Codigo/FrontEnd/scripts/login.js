const realizarLogin = (event) => {
  event.preventDefault();

  const renamedData = {
    email: document.querySelector('#email').value,
    senha: document.querySelector('#senha').value,
  }  

  const xhr = new XMLHttpRequest();


  xhr.open('POST', 'https://tishellofriends.azurewebsites.net/api/autenticacao/entrar', true);
  xhr.setRequestHeader("Content-type", "application/json");

  xhr.onreadystatechange = () => {
    if (xhr.readyState == 4) {
      if (xhr.status == 200) {
        let tokenUsuario = JSON.parse(xhr.responseText);
        if (tokenUsuario) {
          localStorage.setItem('userToken', JSON.stringify(tokenUsuario.data));
          window.location.href = 'modulos.html';
        }
      }
      else {
        renderizaAlert('Favor verificar os dados de login.', 'danger')
        console.log(xhr.responseText);
      }
    }
  }

  xhr.send(JSON.stringify(renamedData));
}

function validacaoEmail(field) {
  usuario = field.value.substring(0, field.value.indexOf("@"));
  dominio = field.value.substring(field.value.indexOf("@") + 1, field.value.length);

  if ((usuario.length >= 1) &&
    (dominio.length >= 3) &&
    (usuario.search("@") == -1) &&
    (dominio.search("@") == -1) &&
    (usuario.search(" ") == -1) &&
    (dominio.search(" ") == -1) &&
    (dominio.search(".") != -1) &&
    (dominio.indexOf(".") >= 1) &&
    (dominio.lastIndexOf(".") < dominio.length - 1)) {
    document.getElementById("msgemail").innerHTML = "E-mail válido";
    alert("E-mail valido");
  }
  else {
    renderizaAlert('E-mail invalido', 'danger');
  }
}
