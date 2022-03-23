function validarLogin() {
  let userToken = JSON.parse(localStorage.getItem('userToken'));

  if (userToken === null || Object.keys(userToken).length === 0) window.location.href = 'Login.html';
}

function ehAluno() {
  let userToken = JSON.parse(localStorage.getItem('userToken'));

  return (userToken === null || Object.keys(userToken).length === 0 || (userToken !== null && userToken.userType === "aluno"));
}

function deslogarAluno() {
  let userToken = JSON.parse(localStorage.getItem('userToken'));

  if (userToken === null || Object.keys(userToken).length === 0 || ehAluno()) window.location.href = 'Login.html';
}

function deslogarUsuario() {
  localStorage.setItem('userToken', '{}');

  window.location.href = 'Login.html';
}

function retornarTokenUsuario() {
  let userToken = JSON.parse(localStorage.getItem('userToken'));

  return userToken.accessToken;
}