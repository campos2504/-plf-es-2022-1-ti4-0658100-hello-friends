const urlMediaAlunos = `http://tishellofriends.azurewebsites.net/api/alunos/media`;
          
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
          var media;
          if(data[i].media == "NaN"){
            media = "Não iniciou"
          }else{
            media = ''.concat((data[i].media*100).toFixed(2), "%");
          }
          tabela_mediaAlunos = tabela_mediaAlunos + ` 
                    <tr id="tb">
                      <td id="tb">
                            <a onclick="selecionarAluno(${data[i].id})" href="listaAtividadesDoAluno.html">
                                <i id="${data[i].id}"">
                                    ${data[i].nomeCompleto}
                                </i>                              
                            </a>

                            <td>
                              <div class=">
                                <h3 class=""><span id=""></span>${media}</h3>
                              </div>
                           </td>
                           <td>
                              <div class=">
                                <h3 class=""><span id=""></span>${data[i].atividadesFeitas}</h3>
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




function selecionarAluno(event) {

  console.log(event);

  if (event) {
    localStorage.setItem('visualizarAtivAluno', JSON.stringify({ event }));
  };
};