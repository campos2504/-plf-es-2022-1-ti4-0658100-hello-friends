const urlMediaAlunos = `https://localhost:44327/api/alunos/media`;
          
function mediaAlunos() {
  fetch(urlMediaAlunos, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      console.log(data);
      //process the returned data
      let texto_mediaAlunos = document.querySelector('#data-table #listaMediaAlunos');
      let tabela_mediaAlunos = "";
      // Montar texto HTML das atividades
      for (i = 0; i < data.length; i++) {           
          var media = (data[i].media*100).toFixed(2);
          tabela_mediaAlunos = tabela_mediaAlunos + ` 
                    <tr id="tb">
                      <td id="tb">
                            <a onclick="" href="">
                                <i id="${data[i].id}"">
                                    ${data[i].nomeCompleto}
                                </i>                              
                            </a>

                            <td>
                              <div class=">
                                <h3 class=""><span id=""></span>${media}%</h3>
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
mediaAlunos();