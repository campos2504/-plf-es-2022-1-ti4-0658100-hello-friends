const urlRespostaCompletaFrase = `https://localhost:44327/api/respostasCompletaFrase`;
let alunoIdCompletaFrase;

//Recuperar informações do localStorage
let dadosAlunoCompletaFrase = JSON.parse(localStorage.getItem('userToken'));
dadosAlunoCompletaFrase = dadosAlunoCompletaFrase.user.email;

let mIDCompletaFrase = JSON.parse(localStorage.getItem('moduloCorrente'));
mIDCompletaFrase = mIDCompletaFrase.event;

let completaFraseID = JSON.parse(localStorage.getItem('atividadeCompletaFraseEscolhida'));
completaFraseID = completaFraseID.arg1;


//Salvar no BD a resposta
function salvarRespostaCompletaFrase(resultado) {

  const renamedData = {
    resultado: resultado,
    alunoId: alunoIdCompletaFrase,
    mID: mIDCompletaFrase,
    completaFraseID: completaFraseID
  }
  console.log(renamedData);

  fetch(urlRespostaCompletaFrase, {
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
function getUserCompletaFrase() {

  if(ehAluno()) {
    let urlUpdateAluno = ''.concat("https://localhost:44327/api/alunos", '/email/', dadosAlunoCompletaFrase);
    let request = new XMLHttpRequest();
    request.open('GET', urlUpdateAluno, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    var objeto = JSON.parse(dados);
    alunoIdCompletaFrase = objeto.id;
    return objeto;
  }
};
getUserCompletaFrase();

//Recuperar usuário
function getModuloAlunoCompletaFrase() {

  let alunoIdCompletaFrase = getUserCompletaFrase();
  let urlModuloAluno = ''.concat("https://localhost:44327/api/respostasCompletaFrase/", mIDCompletaFrase, "/", alunoIdCompletaFrase.id);

  let request = new XMLHttpRequest();
  request.open('GET', urlModuloAluno, false);
  request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
  request.send();
  const dados = request.responseText;
  var objeto = JSON.parse(dados);

  return objeto;
};
