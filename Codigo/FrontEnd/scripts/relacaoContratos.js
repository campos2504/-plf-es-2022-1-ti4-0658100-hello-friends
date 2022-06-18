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