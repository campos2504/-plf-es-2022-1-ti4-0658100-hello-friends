const urlRespostaVF = `https://localhost:44327/api/respostasvf`;
let alunoIdVF;

//Recuperar informações do localStorage
let dadosAlunoVF = JSON.parse(localStorage.getItem('userToken'));
dadosAlunoVF = dadosAlunoVF.user.email;

let mIDVF = JSON.parse(localStorage.getItem('moduloCorrente'));
mIDVF = mIDVF.event;

let verdadeiroFalsoID = JSON.parse(localStorage.getItem('atividadeVerdadeiroFalso'));
verdadeiroFalsoID = verdadeiroFalsoID.arg1;


//Salvar no BD a resposta
function salvarRespostaOpcaoCerta(resultado){ 

  const renamedData = {
    resultado: resultado,
    alunoId: alunoIdVF,
    mID: mIDVF,
    verdadeiroFalsoID: verdadeiroFalsoID
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
  })
    .catch(function (res) { console.log(res) })
}


//Recuperar usuário
function getUserRespostaVF() {

  if(ehAluno()){
    let urlUpdateAluno = ''.concat("https://localhost:44327/api/alunos", '/email/', dadosAlunoVF);
    let request = new XMLHttpRequest();
    request.open('GET', urlUpdateAluno, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    var objeto = JSON.parse(dados);
    alunoIdVF = objeto.id;
    return objeto;
  }  
};
getUserRespostaVF();

//Recuperar usuário
function getModuloAlunoVF() {
  
  let alunoIdVF = getUserRespostaVF();
  let urlModuloAluno = ''.concat("https://localhost:44327/api/respostasvf/", mIDVF,"/", alunoIdVF.id);

    let request = new XMLHttpRequest();
    request.open('GET', urlModuloAluno, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    var objeto = JSON.parse(dados);

    return objeto;    
};