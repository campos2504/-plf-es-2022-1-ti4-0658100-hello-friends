const urlRespostaCompletaFrase = `https://localhost:44327/api/respostasCompletaFrase`;
let alunoId;
let dados;

//Recuperar informações do localStorage
let dadosAluno = JSON.parse(localStorage.getItem('userToken'));

let mID = JSON.parse(localStorage.getItem('moduloCorrente'));
mID = mID.event;
console.log(mID);

let completaFraseID = JSON.parse(localStorage.getItem('atividadeCompletaFraseEscolhida'));
completaFraseID = completaFraseID.arg1;
console.log(completaFraseID);


//Salvar no BD a resposta
function salvarRespostaCompletaFrase(resultado){ 
  console.log(alunoId);

  const renamedData = {
    resultado: resultado,
    alunoId: alunoId,
    mID: mID,
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
    let urlUpdateAluno = ''.concat("https://localhost:44327/api/alunos", '/email/', dadosAluno.user.email);

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
  
  alunoId = getUser();
  let urlModuloAluno = ''.concat("https://localhost:44327/api/respostasCompletaFrase/", mID,"/", alunoId.id);
  console.log(urlModuloAluno);

    let request = new XMLHttpRequest();
    request.open('GET', urlModuloAluno, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    var objeto = JSON.parse(dados);

    return objeto;    
};