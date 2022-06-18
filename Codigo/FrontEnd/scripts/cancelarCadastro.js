const baseURL = `http://tishellofriends.azurewebsites.net/api/alunos`;

var cancelarCadastro = {
  delete(id) {
    let urlCancelaAluno = ''.concat(baseURL, '/', id);
    console.log(urlCancelaAluno);

    fetch(urlCancelaAluno, {
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${retornarTokenUsuario()}`
      },
      method: 'delete',
    }).then(function (res) {
      console.log(res)
      window.location.reload();
    }).catch(function (res) { console.log(res) })

  }
}
function table() {
  fetch(baseURL, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      console.log(data);
      //process the returned data
      let divTela = document.querySelector('#data-table #lista');
      let texto = "";
      // Montar texto HTML das noticias
      for (i = 0; i < data.length; i++) {
        if (data[i].status == true & data[i].situacao == "Aprovado") {
          texto = texto + ` 
                        <tr id="tb">
                            <td id="tb"> <img  class="card-img-fluid" src="${data[i].imagemSrc}"></td>
                            <td id="tb">${data[i].nomeCompleto}</td>
                            <td id="tb">                        

                            <a onclick="cancelarCadastro.delete(${data[i].id}), modal()">
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

function modal() {
  alert("Deseja excluir cadastro?");
}
