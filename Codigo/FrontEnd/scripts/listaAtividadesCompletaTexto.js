const baseURLCompletaTexto = `http://tishellofriends.azurewebsites.net/api/completar-texto`;
let idModuloEscolhido;

var selecaoAtividade_completaTexto = {
  completaTexto(event) {
    let nameOfFunction = [event.target];
    let arg1 = event.target.getAttribute('id');

    localStorage.setItem('atividadeCompletaTextoEscolhida', JSON.stringify({ arg1 }));
  }
}

//recupera do localStorage a atividade escolhida
let moduloEscolhido_completaTexto = JSON.parse(localStorage.getItem('moduloCorrente'));
idModuloEscolhido = moduloEscolhido_completaTexto.event;


//Exclui Atividade completa Texto
function deletaAtividadeCompletaTexto(id) {

  let urlDeleteCompletaTexto = ''.concat(baseURLCompletaTexto, '/', id);

  fetch(urlDeleteCompletaTexto, {
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
    method: 'delete',
  }).then(function (res) {
    console.log("reposta delete->", res)
    window.location.reload();
  })
    .catch(function (res) { console.log("reposta delete->", res) })
};


//Carregar dados de atividade em tela para posterior atualização.
function editarCompletaTexto(id) {
  
  selecionaAtividadeUpdate(id);
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


function selecionaAtividadeUpdate(event) {
  if (event) {
    localStorage.setItem('atividadeUpdate', JSON.stringify({ event }));
    window.location.href = "Update_cadastroDeAtivCompletarTexto.html";
  };
};

          
function tableCompletaTexto() {
  fetch(baseURLCompletaTexto, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      let dadosModuloAlunoCompletaTexto;
      if(ehAluno()){
        dadosModuloAlunoCompletaTexto = getModuloAlunoCompletaTexto();
      }
      let nota;
      //process the returned data
      let divTela_CompletaTexto = document.querySelector('#data-table #listaAtividades_completaTexto');
      let texto_completaTexto = "";
      // Montar texto HTML das atividades
      for (i = 0; i < data.length; i++) {
        if (data[i].moduloId == idModuloEscolhido) {
          nota  = undefined;
          if(ehAluno()){
            dadosModuloAlunoCompletaTexto.forEach(element => {
              if(element.completaTextoID == data[i].id){
                nota = (element.resultado * 100) + "%";
              }
            });
          }          
          if(nota == undefined){
            nota = "Pendente";
          } 
          texto_completaTexto = texto_completaTexto + ` 
                    <tr id="tb">
                      <td id="tb">
                            <a onclick="selecaoAtividade_completaTexto.completaTexto(event)" href="atividade_completaTexto.html">
                                <i id="${data[i].id}"">
                                    ${data[i].titulo}
                                </i>                              
                            </a>
                          <td>
                              <button type="button" style=${ehAluno() ? 'display:none;' : ""} id="btn_editar" onclick="editarCompletaTexto('${data[i].id}')" data-toggle="modal"
                                  data-target="#modalEdicaoModulo" class="btn btn-light btn-circle btn-sm">
                                  <svg width="2em" height="2em" viewBox="0 0 16 16" class="bi bi-pencil editar-excluir"
                                      fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                      <path fill-rule="evenodd"
                                          d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168l10-10zM11.207 2.5L13.5 4.793 14.793 3.5 12.5 1.207 11.207 2.5zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293l6.5-6.5zm-9.761 5.175l-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325z" />
                                  </svg>
                              </button>

                              <button type="button" style=${ehAluno() ? 'display:none;' : ""} id="btn_excluir" onclick="deletaAtividadeCompletaTexto('${data[i].id}')"
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
      divTela_CompletaTexto.innerHTML = texto_completaTexto;
    })
}
tableCompletaTexto();