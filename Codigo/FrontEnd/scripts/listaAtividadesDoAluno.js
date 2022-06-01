const urlAtividadesAluno = `https://localhost:44327/api/alunos/notas`;

//recupera do localStorage a atividade escolhida
let alunoEscolhido = JSON.parse(localStorage.getItem('visualizarAtivAluno'));
alunoEscolhido = alunoEscolhido.event;

const urlAtividadesAlunoEscolhido = ''.concat(urlAtividadesAluno, '/', alunoEscolhido);

function listaAtividadesAluno() {
  fetch(urlAtividadesAlunoEscolhido, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      console.log(data);
      //process the returned data
      let texto_mediaAlunos = document.querySelector('#data-table #listaAtividadesDoAluno');
      let tabela_mediaAlunos = "";
      document.getElementById('nomeAluno').innerHTML = data[0].nomeCompleto;
      // Montar texto HTML das atividades
      for (i = 0; i < data.length; i++) {        
          var media = (data[i].resultado*100).toFixed(2);
          tabela_mediaAlunos = tabela_mediaAlunos + ` 
                    <tr id="tb">
                            <td>
                              <div class=">
                                <h3 class=""><span id=""></span>${data[i].nomeModulo}</h3>
                              </div>
                           </td>

                           <td>
                              <div class=">
                                <h3 class=""><span id=""></span>${data[i].nomeAtividade}</h3>
                              </div>
                            </td>

                            <td>
                              <div class=">
                                <h3 class=""><span id=""></span>${media}</h3>
                              </div>
                           </td>
                       </td>                               
                    </tr>
                    `;
        
      };

      // Preencher a DIV com o texto HTML
      texto_mediaAlunos.innerHTML = tabela_mediaAlunos;
    })
}
listaAtividadesAluno();
