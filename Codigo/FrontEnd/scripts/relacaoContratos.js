const urlContratos = `https://tishellofriends.azurewebsites.net/api/contrato`;
          
function getContratos() {
  fetch(urlContratos, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      console.log(data);
      //process the returned data
      let contratos = document.querySelector('#data-table #listaContratos');
      let tabela_contratos = "";
      // Montar texto HTML das atividades
      for (i = 0; i < data.length; i++) {           
        var dataInicio = new Date(data[i].dataInicioContrato)
        var dataFormatadaInicio = dataInicio.toISOString().slice(0,10);
        dataFormatadaInicio = dataFormatadaInicio.split('-').reverse().join('/');
        
        var dataFinal = new Date(data[i].dataFinalContrato)
        var dataFormatadaFinal = dataFinal.toISOString().slice(0,10);
        dataFormatadaFinal = dataFormatadaFinal.split('-').reverse().join('/');

          tabela_contratos = tabela_contratos + ` 
                    <tr id="tb">
                      <td id="tb">
                            <a onclick="selecionarAluno(${data[i].id})" href="contrato.html">
                                <i id="${data[i].id}"">
                                    ${data[i].nomeResponsavel}
                                </i>                              
                            </a>

                            <td>
                            <div class=">
                            <h3 class=""><span id=""></span>${data[i].nomeAluno}</h3>
                          </div>
                           </td>
                           <td>
                              <div class=">
                                <h3 class=""><span id=""></span>${dataFormatadaInicio}</h3>
                              </div>
                           </td>
                           <td>
                              <div class=">
                                <h3 class=""><span id=""></span>${dataFormatadaFinal}</h3>
                              </div>
                           </td>
                           <td>
                              
                            <button type="button" id="btn_excluir" onclick="excluirContrato('${data[i].id}')"
                              class="btn btn-light btn-circle btn-sm">
                                <svg width="3em" height="3em" viewBox="0 0 16 16" class="bi bi-x editar-excluir"
                                    fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                    <path fill-rule="evenodd"
                                        d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z" />
                              </svg>

                            </button>

                           </td>
                       </td>                               
                    </tr>
                    `;
        
      };

      // Preencher a DIV com o texto HTML
      contratos.innerHTML = tabela_contratos;
    })
}
getContratos();



function selecionarAluno(event) {

  console.log(event);

  if (event) {
    localStorage.setItem('contratoSelecionado', JSON.stringify({ event }));
  };
};


//Exclui contrato
function excluirContrato(id) {

  let urlDeleteContrato = ''.concat(urlContratos, '/', id);

  fetch(urlDeleteContrato, {
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