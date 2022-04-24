const urlRespostaCompletaFrase = `https://localhost:44327/api/respostasCompletaFrase`;
let alunoIdCompletaFrase;

//Recuperar informações do localStorage
let dadosAlunoCompletaFrase = JSON.parse(localStorage.getItem('userToken'));

let mIDCompletaFrase = JSON.parse(localStorage.getItem('moduloCorrente'));
mIDCompletaFrase = mIDCompletaFrase.event;
console.log(mIDCompletaFrase);

let completaFraseID = JSON.parse(localStorage.getItem('atividadeCompletaFraseEscolhida'));
completaFraseID = completaFraseID.arg1;
console.log(completaFraseID);


//Salvar no BD a resposta
function salvarRespostaCompletaFrase(resultado){ 
  console.log(alunoId);

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
    window.location.href="modulos.html"
  })
    .catch(function (res) { console.log(res) })
}


//Recuperar usuário
function getUser() {

  if(ehAluno()){
    //GetByEmail
    let urlUpdateAluno = ''.concat("https://localhost:44327/api/alunos", '/email/', dadosAlunoCompletaFrase.user.email);

    let request = new XMLHttpRequest();
    request.open('GET', urlUpdateAluno, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    var objeto = JSON.parse(dados);
    alunoId = objeto.id;
    return objeto;
  }  
};
getUser();

//Recuperar usuário
function getModuloAluno() {
  
  alunoIdCompletaFrase = getUser();
  let urlModuloAluno = ''.concat("https://localhost:44327/api/respostasCompletaFrase/", mIDCompletaFrase,"/", alunoIdCompletaFrase.id);
  console.log(urlModuloAluno);

    let request = new XMLHttpRequest();
    request.open('GET', urlModuloAluno, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    var objeto = JSON.parse(dados);

    return objeto;    
};