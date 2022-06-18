const baseURLCompletaFrase = `http://tishellofriends.azurewebsites.net/api/completar-frase`;
let idModuloTextoEscolhido;

var selecaoAtividade_completaFrase = {
  completaFrase(event) {
    let nameOfFunction = [event.target];
    let arg1 = event.target.getAttribute('id');

    localStorage.setItem('atividadeCompletaFraseEscolhida', JSON.stringify({ arg1 }));
  }
}

//recupera do localStorage a atividade escolhida
let moduloEscolhido_completaFrase = JSON.parse(localStorage.getItem('moduloCorrente'));
idModuloTextoEscolhido = moduloEscolhido_completaFrase.event;


//Exclui Atividade completa frase
function deletaAtividadeCompletaFrase(id) {

  let urlDeleteCompletaFrase = ''.concat(baseURLCompletaFrase, '/', id);

  fetch(urlDeleteCompletaFrase, {
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
    method: 'delete',
  }).then(function (res) {
    window.location.reload();
  })
    .catch(function (res) { console.log("reposta delete->", res) })
};


//Carregar dados de atividade em tela para posterior atualização.
function editarCompletaFrase(id) {
  
  localStorage.setItem('atividadeUpdate', JSON.stringify({ id }));
  window.location.href = "Update_cadastroDeAtivCompletarFrase.html";
  /*fetch(baseURLCompletaFrase, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
  .then((data) => {
    console.log("imagem ->", data);
    window.location.href = "Update_cadastroDeAtivCompletarFrase.html";
    for (i = 0; i < data.length; i++) {
      if (data[i].id == id) {
        console.log(data[i]);
        console.log("Update atividade.....!");
        $("#tituloUpdate").val(data[i].titulo);
        $("#enunciadoUpdate").val(data[i].enunciado);
      }
    }
  })*/
}
          
function tableCompletaFrase() {
  fetch(baseURLCompletaFrase, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      let dadosModuloAlunoCompletaFrase;
      if(ehAluno()){
        dadosModuloAlunoCompletaFrase = getModuloAlunoCompletaFrase();
      }         
      let nota;
      //process the returned data
      let divTela_CompletaFrase = document.querySelector('#data-table #listaAtividades_completaFrase');
      let texto_completaFrase = "";
      // Montar texto HTML das atividades
      for (i = 0; i < data.length; i++) {
        if (data[i].moduloId == idModuloTextoEscolhido) {
          nota  = undefined;
          if(ehAluno()){
            dadosModuloAlunoCompletaFrase.forEach(element => {
              if(element.completaFraseID == data[i].id){
                nota = (element.resultado * 100) + "%";
              }
            });
          }          
          if(nota == undefined){
            nota = "Pendente";
          }          
          texto_completaFrase = texto_completaFrase + ` 
                    <tr id="tb">
                      <td id="tb">
                            <a onclick="selecaoAtividade_completaFrase.completaFrase(event)" href="atividade_completaFrase.html">
                                <i id="${data[i].id}"">
                                    ${data[i].titulo}
                                </i>                              
                            </a>
                          <td>
                              <button type="button" style=${ehAluno() ? 'display:none;' : ""} id="btn_editar" onclick="editarCompletaFrase('${data[i].id}')" data-toggle="modal"
                                  data-target="#modalEdicaoModulo" class="btn btn-light btn-circle btn-sm">
                                  <svg width="2em" height="2em" viewBox="0 0 16 16" class="bi bi-pencil editar-excluir"
                                      fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                      <path fill-rule="evenodd"
                                          d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168l10-10zM11.207 2.5L13.5 4.793 14.793 3.5 12.5 1.207 11.207 2.5zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293l6.5-6.5zm-9.761 5.175l-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325z" />
                                  </svg>
                              </button>

                              <button type="button" style=${ehAluno() ? 'display:none;' : ""} id="btn_excluir" onclick="deletaAtividadeCompletaFrase('${data[i].id}')"
                                  class="btn btn-light btn-circle btn-sm">
                                    <svg width="3em" height="3em" viewBox="0 0 16 16" class="bi bi-x editar-excluir"
                                        fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                        <path fill-rule="evenodd"
                                            d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z" />
                                  </svg>
                              </button>
                           </td>

                            <td>
                              <div class=">
                                <h3 class=""><span id=""></span>${nota}</h3>
                              </div>
                           </td>
                       </td>                               
                    </tr>
                    `;
        }
      };

      // Preencher a DIV com o texto HTML
      divTela_CompletaFrase.innerHTML = texto_completaFrase;
    })
}
tableCompletaFrase();