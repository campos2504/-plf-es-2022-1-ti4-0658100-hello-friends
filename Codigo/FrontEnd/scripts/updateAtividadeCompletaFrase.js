const baseURLCompletaFrase = `https://localhost:44327/api/completar-frase`;
let idModuloEscolhidoUpdate;
let idUpdateCompletaFrase;
let idPalavraUpdate;

//recupera do localStorage a atividade para update
let atividadeUpdate = JSON.parse(localStorage.getItem('atividadeUpdate'));
idAtividadeUpdate = atividadeUpdate.event;
console.log("testefinal->", idAtividadeUpdate);
update();

function update() {

    fetch(baseURLCompletaFrase, {
        headers: {
            'Authorization': `Bearer ${retornarTokenUsuario()}`
        },
    }).then(result => result.json())
        .then((data) => {
            for (i = 0; i < data.length; i++) {
                if (data[i].id == idAtividadeUpdate) {
                    console.log(data[i]);
                    console.log("Update atividade.....!");
                    idModuloEscolhidoUpdate = data[i].moduloId;
                    idUpdateCompletaFrase = data[i].id;
                    console.log("idUpdateCompletaFrase.....!", idUpdateCompletaFrase);
                    $("#tituloUpdate").val(data[i].titulo);
                    $("#enunciadoUpdate").val(data[i].enunciado);

                    let palavrasUpdate = data[i].palavrasChaves[0].texto;
                    idPalavraUpdate = data[i].palavrasChaves[0].id;
                    console.log("idPalavraUpdate ->", idPalavraUpdate);

                    for(j = 1; j < data[i].palavrasChaves.length; j++){
                        console.log(palavrasUpdate);
                        palavrasUpdate += ',' + data[i].palavrasChaves[j].texto;
                    }

                    $("#palavrasUpdate").val(palavrasUpdate);
                }
            }
        })
}



/*Atualiza Atividade completa frase */
const saveProviderCompletaFraseUpdate = (dataUpdate) => {
    const xhrUpdateCompletaFrase = new XMLHttpRequest();
    let palavrasChaves = dataUpdate.palavrasChaves.split(',').map((palavraUpdate) => { return { texto: palavraUpdate, id: idPalavraUpdate } });
    const newDataUpdate = {
      id: idUpdateCompletaFrase,
      titulo: dataUpdate.titulo,
      enunciado: dataUpdate.enunciado,
      moduloId: idModuloEscolhidoUpdate,
      palavrasChaves,
    };
  
    xhrUpdateCompletaFrase.open('PUT', 'https://localhost:44327/api/completar-frase', true);
    xhrUpdateCompletaFrase.setRequestHeader("Content-type", "application/json");
    xhrUpdateCompletaFrase.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);

    xhrUpdateCompletaFrase.onreadystatechange = () => {
      if (xhrUpdateCompletaFrase.readyState == 4) {
        if (xhrUpdateCompletaFrase.status == 200) {
          alert("Atividade atuaizada com sucesso");
          window.location.href="listaAtividadesCompletaFrase.html"
          console.log(xhrUpdateCompletaFrase.responseText);
        }
        else {
          alert('Não foi possivel atualizar a atividade');
          console.log(xhrUpdateCompletaFrase.responseText);
        }
      }
    }
    console.log("Resultado uptadate --->", newDataUpdate);
    xhrUpdateCompletaFrase.send(JSON.stringify(newDataUpdate));
  }
  
  
  const formCompletaFraseUpdate = {
    getValue() {
      return {
        titulo: document.querySelector('#tituloUpdate').value,
        enunciado: document.querySelector('#enunciadoUpdate').value,
        palavrasChaves: document.querySelector('#palavrasUpdate').value,
      }
    },
  
    validateFields() {
      const { titulo, enunciado } = formCompletaFraseUpdate.getValue()
      if (titulo.trim() === "" || enunciado.trim() === "") {
        throw new Error("Por favor, preencha todos os campos")
      }
    },
  
    formatProvider() {
      let { titulo, enunciado, palavrasChaves } = formCompletaFraseUpdate.getValue()
      return { titulo, enunciado, palavrasChaves };
    },
  
    submit(event) {
      event.preventDefault()
      try {
        formCompletaFraseUpdate.validateFields()
        const SaveProviderCompletaFraseUpdate = formCompletaFraseUpdate.formatProvider()
        saveProviderCompletaFraseUpdate(SaveProviderCompletaFraseUpdate)
      } catch (error) {
        alert(error.message)
      }
    }
  }