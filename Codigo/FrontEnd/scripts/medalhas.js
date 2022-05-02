
const baseURLIdModulo = `https://localhost:44327/api/modulos`;
let baseURLMedalhas;
const baseURLIdAluno = 'https://localhost:44327/api/alunos';
const medalhaURI = 'https://localhost:44327/api/medalha'
let idAlunoMedalha;
let idUsuario;
let urlIdUsuario;
let ouro = 0;
let prata = 0;
let bronze = 0;

//Recuperar informações do localStorage
let mIDMedalha = JSON.parse(localStorage.getItem('moduloCorrente'));
mIDMedalha = mIDMedalha.event;



function recuperaIdAluno() {
    idUsuario = JSON.parse(localStorage.getItem('userToken'));
    urlIdUsuario = ''.concat(baseURLIdAluno, '/email/', idUsuario.user.email);

    let request = new XMLHttpRequest();
    request.open('GET',urlIdUsuario, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    var objeto = JSON.parse(dados);
    return objeto.id;
};

//recuperar o id do modulo
function atualizaMedalha() {

  ouro = 0;
  prata = 0;
  bronze = 0;
    fetch(baseURLIdModulo, {
      headers: {
        'Authorization': `Bearer ${retornarTokenUsuario()}`
      },
    }).then(result => result.json())
      .then((data) => {
  
        let tela = document.getElementById('medalhas');
        let strHtml = "";
        // Montar texto HTML dos módulos
        for (i = 0; i < data.length; i++) {
          baseURLMedalhas = `https://localhost:44327/api/modulos/medalha/${data[i].id}/${recuperaIdAluno()}`
          console.log("uri" + baseURLMedalhas);
          escolhaMedalha();
        };

        strHtml = `
          <h5 class="pontuacaoOuro pontuacao">${ouro}</h5>
          <img src="img/ouro.png" alt="medalhada de ouro">
          <h5 class="pontuacaoPrata pontuacao">${prata}</h5>
          <img src="img/prata.png" alt="medalhada de ouro">
          <h5 class="pontuacaoBronze pontuacao">${bronze}</h5>
          <img src="img/bronze.png" alt="medalhada de ouro">
          `
  
        // Preencher a DIV com o texto HTML
        tela.innerHTML = strHtml;


      })
  }

  function escolhaMedalha(){

    let request = new XMLHttpRequest();
    request.open('GET', baseURLMedalhas, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    if(dados == "Ouro"){
        ouro += 1;
        medalhaGanha("Ouro");
    }else if(dados == "Prata"){
        prata += 1;
        medalhaGanha("Prata");
    }else if(dados == "Bronze"){
        bronze += 1;
        medalhaGanha("Bronze");
    }else if(dados == "Sem medalha"){
      //Temos duas opções: aluno não concluiu ou Joyce adicionou atividade
      if(!(buscarMedalha() == null)){
        //Chamar uma função update para a variável booleana. Fazer um put.
        atualizarStatusMedalha(false, dados);
      }
    }

    return dados;
  }

  function medalhaGanha(medalha){
    const renamedData = {
      AlunoId: recuperaIdAluno(),
      ModuloId: mIDMedalha,
      TipoMedalha: medalha,
      ModuloConcluido: true
    }
    
    console.log("@@" + buscarMedalha().moduloConcluido)
  
    fetch(medalhaURI, {
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${retornarTokenUsuario()}`
      },
      method: 'POST',
      body: JSON.stringify(renamedData),
    }).then(function (res) {
      //Pode ser que ele já tinha a medalha
      if(buscarMedalha() == null){
        alert("Parabéns!");
      }else{
        //Basta atualizar novamente a variável booeleana para true. Update.
        if(buscarMedalha().moduloConcluido == false){
          console.log("entrou");
          alert("Parabéns!");
        atualizarStatusMedalha(true,buscarMedalha());
       
        }
      }
    })
      .catch(function (res) {  })
  }

  function buscarMedalha(){
   let baseURLBuscaMedalhas = `https://localhost:44327/api/medalha/${mIDMedalha}/${recuperaIdAluno()}`;
   let request = new XMLHttpRequest();
    request.open('GET', baseURLBuscaMedalhas, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    var objeto = JSON.parse(dados);
    return objeto;
  }

  function atualizarStatusMedalha(statusMedalha, medalha){
    const renamedData = {
      AlunoId: recuperaIdAluno(),
      ModuloId: mIDMedalha,
      TipoMedalha: medalha.tipoMedalha,
      ModuloConcluido: statusMedalha
    }
  
    fetch(medalhaURI, {
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${retornarTokenUsuario()}`
      },
      method: 'PUT',
      body: JSON.stringify(renamedData),
    }).then(function (res) {
      
    })
      .catch(function (res) { })

  }



  atualizaMedalha();