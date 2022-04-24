const urlRespostaCompletaTexto = `https://localhost:44327/api/respostasCompletaTexto`;
let alunoIdCompletaTexto;

//Recuperar informações do localStorage
let dadosAlunoCompletaTexto = JSON.parse(localStorage.getItem('userToken'));
dadosAlunoCompletaTexto = dadosAlunoCompletaTexto.user.email;

let mIDCompletaTexto = JSON.parse(localStorage.getItem('moduloCorrente'));
mIDCompletaTexto = mIDCompletaTexto.event;

let completaTextoID = JSON.parse(localStorage.getItem('atividadeCompletaTextoEscolhida'));
completaTextoID = completaTextoID.arg1;


//Salvar no BD a resposta
function salvarRespostaCompletaTexto(resultado) {

  const renamedData = {
    resultado: resultado,
    alunoId: alunoIdCompletaTexto,
    mID: mIDCompletaTexto,
    completaTextoID: completaTextoID
  }
  console.log(renamedData);

  fetch(urlRespostaCompletaTexto, {
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
    method: 'POST',
    body: JSON.stringify(renamedData),
  }).then(function (res) {
  })
    .catch(function (res) { console.log(res) })
}


//Recuperar usuário
function getUserCompletaTexto() {

  if (ehAluno()) {
    let urlUpdateAluno = ''.concat("https://localhost:44327/api/alunos", '/email/', dadosAlunoCompletaTexto);
    let request = new XMLHttpRequest();
    request.open('GET', urlUpdateAluno, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    var objeto = JSON.parse(dados);
    alunoIdCompletaTexto = objeto.id;
    return objeto;
  }
};
getUserCompletaTexto();

//Recuperar usuário
function getModuloAlunoCompletaTexto() {

  let alunoIdCompletaTexto = getUserCompletaTexto();
  let urlModuloAluno = ''.concat("https://localhost:44327/api/respostasCompletaTexto/", mIDCompletaTexto, "/", alunoIdCompletaTexto.id);

  let request = new XMLHttpRequest();
  request.open('GET', urlModuloAluno, false);
  request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
  request.send();
  const dados = request.responseText;
  var objeto = JSON.parse(dados);
  
  return objeto;
};