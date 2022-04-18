const baseURL = `https://localhost:44327/api/alunos`;
const baseURLAutorizar = `https://localhost:44327/api/alunos/autorizar`;

var aprovacaoCadastro = {
  aprovado(id) {
    let url = ''.concat(baseURL, '/', id);
    console.log(url);
    let request = new XMLHttpRequest();
    request.open('GET', url, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const produtos = request.responseText;
    var objeto = JSON.parse(produtos);
    console.log(objeto)

    let form = {
      id: objeto.id,
      status: true,
      situacao: "Aprovado"
    }
    atualizaCadastro(form);
    table();
  },

  reprovado(id) {
    let url = ''.concat(baseURL, '/', id);
    let request = new XMLHttpRequest();
    request.open('GET', url, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const produtos = request.responseText;
    var objeto = JSON.parse(produtos);

    let form = {
      id: objeto.id,
      status: true,
      situacao: "Reprovado"
    }
    atualizaCadastro(form);
    table();
  }
}

function table() {
  fetch(baseURL, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      //process the returned data
      let divTela = document.querySelector('#data-table #lista');
      let texto = "";
      // Montar texto HTML das noticias
      for (i = 0; i < data.length; i++) {
        if (data[i].status == false) {
          texto = texto + ` 
                        <tr id="tb">
                            <td id="tb">${data[i].nomeCompleto}</td>
                            <td id="tb">${data[i].nomeResponsavel}</td>
                            <td id="tb">
                        
                            <a onclick="aprovacaoCadastro.aprovado(${data[i].id})">
                            <i id="" class="fas fa-angle-down"></i>
                            </a>

                            <a onclick="aprovacaoCadastro.reprovado(${data[i].id})">
                            <i id="" class="fas fa-times"></i>
                            </a>
                            </td>
                        </tr>
                    `;
        }
      };

      // Preencher a DIV com o texto HTML
      divTela.innerHTML = texto;
    })
}
table();


function atualizaCadastro(form) {
  let url = ''.concat(baseURLAutorizar, '/', form.id);
  console.log(url);
  fetch(url, {
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
    method: 'PUT',
    body: JSON.stringify(form)
  }).then(function (res) {
    window.location.reload();
  }).catch(function (res) {
    renderizaAlert('Não foi possível atualizar ao status do aluno', 'danger');
  })
};

