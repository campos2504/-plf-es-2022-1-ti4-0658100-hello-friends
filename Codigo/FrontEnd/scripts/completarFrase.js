let novaFrase;
let idEscolhido;
let frase;
let palavrasChaves;
let idAtividadeEscolhida;
let idModuloEscolhido;

const baseURLCompletaFrase = `https://localhost:44327/api/completar-frase`;

//recupera do localStorage a atividade escolhida
let moduloEscolhido = JSON.parse(localStorage.getItem('moduloCorrente'));
idModuloEscolhido = moduloEscolhido.event;
console.log("testefinal->", idModuloEscolhido);

/*Carregar atividades na tela*/
function imprimeDadosCompletaFrase() {
  fetch(baseURLCompletaFrase, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    }  
  }).then(result => result.json())
    .then((data) => {
      let tela = document.getElementById('atividadeCompletaFrase');
      let strHtml = "";

      //recupera do localStorage a atividade escolhida
      let atividadeEscolhida = JSON.parse(localStorage.getItem('atividadeCompletaFraseEscolhida'));
      idAtividadeEscolhida = atividadeEscolhida.arg1;
      console.log("testefinal->", idAtividadeEscolhida);

      for (i = 0; i < data.length; i++) {
        if (data[i].id == idAtividadeEscolhida) {
          idEscolhido = i;
        }
      }

      console.log(data);
      frase = data[idEscolhido].enunciado;
      frase = data[idEscolhido].enunciado.replace(/,/, "");
      frase = data[idEscolhido].enunciado.replace(".", "");
      console.log(frase);
      novaFrase = frase.split(/\s/);
      palavrasChaves = data[idEscolhido].palavrasChaves;
      console.log("Palavras Chave->", palavrasChaves);
      console.log("Nova frase ->", novaFrase);

      /**
       * Percorre o vetor de palavras da senteça, verificando se cada palavra corresponde a palavra chave.
       * Em caso positivo, a palavra é substituída pelo input.
       */
      novaFrase.forEach(element => {

        if (encontraPalavra(element, data)) {
          strHtml += `<input id="${element}" type="text">`;
          strHtml += ' ';
        } else {
          strHtml += element + ' ';
        }
      });

      // Preencher a DIV com o texto HTML
      tela.innerHTML = strHtml;
    })
}

/**
 * 
 * Verifica se uma determinada palavra é igual a palara chave.
 */
function encontraPalavra(element, data) {
  for (i = 0; i < data[idEscolhido].palavrasChaves.length; i++) {
    if (element == data[idEscolhido].palavrasChaves[i].texto.trim()) {
      return true;
    }
  }
}


/*Incluir Atividade completa frase */
const saveProviderCompletaFrase = (data) => {
  const xhr = new XMLHttpRequest();
  let palavrasChaves = data.palavrasChaves.split(',').map((palavra) => { return { texto: palavra } });
  const newData = {
    titulo: data.titulo,
    enunciado: data.enunciado,
    moduloId: idModuloEscolhido,
    palavrasChaves,
  };

  xhr.open('POST', 'https://localhost:44327/api/completar-frase', true);
  xhr.setRequestHeader("Content-type", "application/json");
  xhr.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
  xhr.onreadystatechange = () => {
    if (xhr.readyState == 4) {
      if (xhr.status == 200) {
        alert("Atividade criada com sucesso");
        window.location.href="listaAtividadesCompletaFrase.html"
        console.log(xhr.responseText);
      }
      else {
        alert('Não foi possivel criar a atividade');
        console.log(xhr.responseText);
      }
    }
  }

  xhr.send(JSON.stringify(newData));
  console.log(newData);
  imprimeDadosCompletaFrase();
}


const formCompletaFrase = {
  getValue() {
    return {
      titulo: document.querySelector('#titulo').value,
      enunciado: document.querySelector('#enunciado').value,
      palavrasChaves: document.querySelector('#palavras').value,
    }
  },

  validateFields() {
    const { titulo, enunciado } = formCompletaFrase.getValue()
    if (titulo.trim() === "" || enunciado.trim() === "") {
      throw new Error("Por favor, preencha todos os campos")
    }
  },

  formatProvider() {
    let { titulo, enunciado, palavrasChaves } = formCompletaFrase.getValue()
    return { titulo, enunciado, palavrasChaves };
  },

  submit(event) {
    event.preventDefault()
    try {
      formCompletaFrase.validateFields()
      const SaveProviderCompletaFrase = formCompletaFrase.formatProvider()
      saveProviderCompletaFrase(SaveProviderCompletaFrase)
    } catch (error) {
      alert(error.message)
    }
  }
}

$('#modalInclusaoAtividadeCompletaFrase').modal('hide');
imprimeDadosCompletaFrase();



function verificaResposta() {

  let aux = palavrasDigitadas();
  let acertou = false;
  console.log(aux);

  //Limpar os campos com as palavras preenchidas.
  for (i = 0; i < palavrasChaves.length; i++) {
    document.getElementById(`${palavrasChaves[i].texto.trim()}`).value = "";
  }

  for (i = 0; i < aux.length; i++) {
    console.log(aux[i]);
    console.log(palavrasChaves[i].texto.trim());
    if (aux[i] == palavrasChaves[i].texto.trim()) {
      acertou = true;
      console.log("acertou");
    } else {
      acertou = false;
      console.log("errou");
    }
  }

  if (acertou) {
    alert("Parabéns, você acertou!");
    window.location.href = "listaAtividadesCompletaFrase.html";
  } else {
    alert("Não foi dessa vez, tente novamente!");
  }
}

function palavrasDigitadas() {
  let strHtml2 = [];

  for (i = 0; i < palavrasChaves.length; i++) {
    let palavra = document.getElementById(`${palavrasChaves[i].texto.trim()}`).value;
    strHtml2[i] = palavra;
  }
  return strHtml2;
}
