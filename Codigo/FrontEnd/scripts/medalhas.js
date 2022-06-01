const baseURLIdModulo = `https://localhost:44327/api/modulos`;
let baseURLMedalhas;
const medalhaURI = 'https://localhost:44327/api/medalha';
let idUsuario;
let urlIdUsuario;
let ouro = 0;
let prata = 0;
let bronze = 0;

function recuperaIdAluno() {
  idUsuario = JSON.parse(localStorage.getItem('userToken'));
  urlIdUsuario = ''.concat('https://localhost:44327/api/alunos', '/email/', idUsuario.user.email);

  let request = new XMLHttpRequest();
  request.open('GET', urlIdUsuario, false);
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
      // Montar texto HTML das medalhas
      let idAluno = recuperaIdAluno();
      for (i = 0; i < data.length; i++) {
        baseURLMedalhas = `https://localhost:44327/api/modulos/medalha/${data[i].id}/${idAluno}`
        let request = new XMLHttpRequest();
        request.open('GET', baseURLMedalhas, false);
        request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
        request.send();
        const dados = request.responseText;
        let medalha = buscarMedalha(data[i].id);

        if (ehAluno()) {
          escolhaMedalha(data[i].id, dados, medalha);
        }

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

function escolhaMedalha(id, dados, medalha) {
  if (dados == "Ouro") {
    ouro += 1;
    if (medalha.tipoMedalha == null) {
      alert("Parabéns, você conclui o módulo" + id);
      medalhaGanha(dados, id, medalha);
    }
  } else if (dados == "Prata") {
    prata += 1;
    if (medalha.tipoMedalha == null) {
      alert("Parabéns, você conclui o módulo" + id);
      medalhaGanha(dados, id, medalha);
    }
  } else if (dados == "Bronze") {
    bronze += 1;
    if (medalha.tipoMedalha == null) {
      alert("Parabéns, você conclui o módulo" + id);
      medalhaGanha(dados, id, medalha);
    }
  } else if (dados == "Sem medalha") {
    if (!(medalha == null)) {
      atualizarStatusMedalha(false, dados, id, medalha);
    }
  }

  if (medalha.tipoMedalha != dados && dados != "Sem medalha" && medalha.tipoMedalha != null) {
    medalhaGanha(dados, id, medalha);
    alert("Medalha atualizada para " + dados);
  }

  return dados;
}

function medalhaGanha(medalha, id, buscaMedalha) {

  const renamedData = {
    AlunoId: recuperaIdAluno(),
    ModuloId: id,
    TipoMedalha: medalha,
    ModuloConcluido: true
  }

  if (buscaMedalha.moduloConcluido == false) {
    atualizarStatusMedalha(true, buscaMedalha, id, buscaMedalha);
  }

  fetch(medalhaURI, {
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
    method: 'POST',
    body: JSON.stringify(renamedData),
  }).then(function (res) {
  })
    .catch(function (res) { })
}

function buscarMedalha(id) {
  let baseURLBuscaMedalhas = `https://localhost:44327/api/medalha/${id}/${recuperaIdAluno()}`;
  let request = new XMLHttpRequest();
  request.open('GET', baseURLBuscaMedalhas, false);
  request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
  request.send();
  const dados = request.responseText;
  var objeto = JSON.parse(dados);

  return objeto;
}

function atualizarStatusMedalha(statusMedalha, medalha, id, buscaMedalha) {

  const renamedData = {
    id: buscaMedalha.id,
    AlunoId: recuperaIdAluno(),
    ModuloId: id,
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