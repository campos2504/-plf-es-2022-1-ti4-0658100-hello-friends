const urlRespostaOpcaoCerta = `https://localhost:44327/api/respostasOpcaoCerta`;
let alunoIdOpcaoCerta;

//Recuperar informações do localStorage
let dadosAlunoOpcaoCerta = JSON.parse(localStorage.getItem('userToken'));

let mIDopcaCerta = JSON.parse(localStorage.getItem('moduloCorrente'));
mIDopcaCerta = mIDopcaCerta.event;

let opcaoCertaID = JSON.parse(localStorage.getItem('atividadeOpcaoCerta'));
opcaoCertaID = opcaoCertaID.arg1;


//Salvar no BD a resposta
function salvarRespostaOpcaoCerta(resultado){ 

  const renamedData = {
    resultado: resultado,
    alunoId: alunoIdOpcaoCerta,
    mID: mIDopcaCerta,
    opcaoCertaID: opcaoCertaID
  }

  console.log(renamedData);

  fetch(urlRespostaOpcaoCerta, {
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
    let urlUpdateAluno = ''.concat("https://localhost:44327/api/alunos", '/email/', dadosAlunoOpcaoCerta.user.email);

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
  
  alunoIdOpcaoCerta = getUser();
  let urlModuloAluno = ''.concat("https://localhost:44327/api/respostasOpcaoCerta/", mIDopcaCerta,"/", alunoIdOpcaoCerta.id);
  console.log(urlModuloAluno);

    let request = new XMLHttpRequest();
    request.open('GET', urlModuloAluno, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    var objeto = JSON.parse(dados);

    return objeto;    
};