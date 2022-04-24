const urlRespostaVF = `https://localhost:44327/api/respostasvf`;
let alunoIdVF;

//Recuperar informações do localStorage
let dadosAlunoVF = JSON.parse(localStorage.getItem('userToken'));

let mIDVF = JSON.parse(localStorage.getItem('moduloCorrente'));
mIDVF = mIDVF.event;

let vfID = JSON.parse(localStorage.getItem('atividadeVerdadeiroFalso'));
vfID = vfID.arg1;


//Salvar no BD a resposta
function salvarRespostaOpcaoCerta(resultado){ 

  const renamedData = {
    resultado: resultado,
    alunoId: alunoIdVF,
    mID: mIDVF,
    vfID: vfID
  }

  console.log(renamedData);

  fetch(urlRespostaVF, {
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
    let urlUpdateAluno = ''.concat("https://localhost:44327/api/alunos", '/email/', dadosAlunoVF.user.email);

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
  
  alunoIdVF = getUser();
  let urlModuloAluno = ''.concat("https://localhost:44327/api/respostasvf/", mIDVF,"/", alunoIdVF.id);
  console.log(urlModuloAluno);

    let request = new XMLHttpRequest();
    request.open('GET', urlModuloAluno, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    var objeto = JSON.parse(dados);

    return objeto;    
};