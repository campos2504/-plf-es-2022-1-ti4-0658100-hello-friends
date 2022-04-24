const urlRespostaCompletaTexto = `https://localhost:44327/api/respostasCompletaTexto`;
let alunoIdCompletaTexto;

//Recuperar informações do localStorage
let dadosAlunoCompletaTexto = JSON.parse(localStorage.getItem('userToken'));

let mIDCompletaTexto = JSON.parse(localStorage.getItem('moduloCorrente'));
mIDCompletaTexto = mIDCompletaTexto.event;

let completaTextoID = JSON.parse(localStorage.getItem('atividadeCompletaTextoEscolhida'));
completaTextoID = completaTextoID.arg1;


//Salvar no BD a resposta
function salvarRespostaCompletaTexto(resultado){ 

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
    window.location.href="modulos.html"
  })
    .catch(function (res) { console.log(res) })
}


//Recuperar usuário
function getUser() {

  if(ehAluno()){
    //GetByEmail
    let urlUpdateAluno = ''.concat("https://localhost:44327/api/alunos", '/email/', dadosAlunoCompletaTexto.user.email);

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
  
  alunoIdCompletaTexto = getUser();
  let urlModuloAluno = ''.concat("https://localhost:44327/api/respostasCompletaTexto/", mIDCompletaTexto,"/", alunoIdCompletaTexto.id);
  console.log(urlModuloAluno);

    let request = new XMLHttpRequest();
    request.open('GET', urlModuloAluno, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    var objeto = JSON.parse(dados);

    return objeto;    
};