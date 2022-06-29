let arrayDePalavrasDaTexto;
let novasPalavrasChaves;
let idEscolhido;
let Texto;
let palavrasParaEsconder;
let arrayPalavrasChaves;
let palavrasChaves;
let idAtividadeEscolhida;
let idModuloEscolhido;

const baseURLCompletaTexto = `https://tishellofriends.azurewebsites.net/api/completar-texto`;

//recupera do localStorage a atividade escolhida
let moduloEscolhido = JSON.parse(localStorage.getItem('moduloCorrente'));
idModuloEscolhido = moduloEscolhido.event;

/*Carregar o texto na tela*/
function imprimeDadosDoTexto() {
  fetch(baseURLCompletaTexto, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    }
  }).then(result => result.json())
    .then((data) => {
      let tela = document.getElementById('atividadeCompletaTexto');
      let strHtml = "";

      //recupera do localStorage a atividade escolhida
      let atividadeEscolhida = JSON.parse(localStorage.getItem('atividadeCompletaTextoEscolhida'));
      idAtividadeEscolhida = atividadeEscolhida.arg1;
      console.log(data);
      for (i = 0; i < data.length; i++) {
        if (data[i].id == idAtividadeEscolhida) {
          idEscolhido = i;
        }
      }

      //Retira caracteres especiais da Texto
      Texto = data[idEscolhido].enunciado;
      Texto = data[idEscolhido].enunciado.replace(/\,/g, ' ');
      Texto = Texto.replace(/\?/g, ' ?');
      Texto = Texto.replace(/\!/g, ' !');
      Texto = Texto.replace(/\./g, ' .');
      Texto = Texto.replace(/\*/g, '<br><br>');


      //Cria um array com cada palavra da Texto, após retirar os caracteres especiais
      arrayDePalavrasDaTexto = Texto.split(/\s/);

      //Cria um array com cada palavra a ser escondida
      palavrasParaEsconder = data[idEscolhido].palavrasChaves.trim();
      arrayPalavrasChaves = palavrasParaEsconder.split(/,/);

      /**
       * Percorre o vetor de palavras da senteça, verificando se cada palavra corresponde a palavra chave.
       * Em caso positivo, a palavra é substituída pelo input. O id da campo corresponde ao nome da palavra
       */
      arrayDePalavrasDaTexto.forEach(element => {
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

/*Carregar as palavras chaves na tela*/
function imprimePalavrasChaves() {
  fetch(baseURLCompletaTexto, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    }
  }).then(result => result.json())
    .then((data) => {
      let tela = document.getElementById('atividadeCompletaText-palavrasClaves');
      let strHtml = "";

      //recupera do localStorage a atividade escolhida
      let atividadeEscolhida = JSON.parse(localStorage.getItem('atividadeCompletaTextoEscolhida'));
      idAtividadeEscolhida = atividadeEscolhida.arg1;

      for (i = 0; i < data.length; i++) {
        if (data[i].id == idAtividadeEscolhida) {
          idEscolhido = i;
        }
      }

      Texto = data[idEscolhido].palavrasChaves;
      Texto = data[idEscolhido].palavrasChaves.replace(/\,/g, ' ');


      //Cria um array com cada palavra da Texto, após retirar os caracteres especiais
      arrayDePalavrasDaTexto = Texto.split(/\s/);


      /**
       * Percorre o vetor de palavras da senteça, verificando se cada palavra corresponde a palavra chave.
       * Em caso positivo, a palavra é substituída pelo input. O id da campo corresponde ao nome da palavra
       */

      //Colocar em ordem alfabética as palavra que serão exibidas para os alunos.
      arrayDePalavrasDaTexto.sort();
      
      arrayDePalavrasDaTexto.forEach(element => {
        strHtml += `<p class="palavraChaveCompletaTexto">${element} </p>` + ''
      });
      // Preencher a DIV com o texto HTML
      tela.innerHTML = strHtml;

    })
}

/**
 * Verifica se uma determinada palavra é igual a palara chave.
 */
function encontraPalavra(element, data) {
  for (i = 0; i < data.length; i++) {
    for (j = 0; j < arrayPalavrasChaves.length; j++) {
      if (element == arrayPalavrasChaves[j]) {
        return true;
      }
    }
  }
}

/**
 * Função para verificar se as palavras que o usuário digitou estão corretas.
 */
function verificaResposta() {

  let aux = palavrasDigitadas();
  let acertos = 0;
  let erros = 0;
  let resultado = 0;

  //Limpar os campos com as palavras preenchidas.
  for (i = 0; i < arrayPalavrasChaves.length; i++) {
    document.getElementById(`${arrayPalavrasChaves[i]}`).value = "";
  }

  for (i = 0; i < aux.length; i++) {
    if (aux[i] == arrayPalavrasChaves[i]) {
      acertos++;
    } else {
      erros++;
    }
  }

  resultado = acertos / aux.length;

  if (ehAluno()) {
    salvarRespostaCompletaTexto(resultado);
  }
  resultado = ''.concat((resultado*100).toFixed(2));
  alert("Você acertou " + (resultado) + "% !");

  if(ehAluno()){
    atualizaMedalha();
  }

  window.location.href = "listaAtividadesCompletaFrase.html";
}

/*recuperaIdAluno();*/
/**
 * Função para criar um array com as palavras digitadas pelo usuário.
 * @returns Retorna o array de palavras
 */
function palavrasDigitadas() {
  let strHtml2 = [];

  for (i = 0; i < arrayPalavrasChaves.length; i++) {
    let palavra = document.getElementById(`${arrayPalavrasChaves[i]}`).value;
    strHtml2[i] = palavra;
  }
  return strHtml2;
}



/**
 * Função para criar uma nova atividade no banco de dados.
 */
const saveProviderCompletaTexto = (data) => {
  const xhr = new XMLHttpRequest();
  const newData = {
    titulo: data.titulo,
    enunciado: data.enunciado,
    moduloId: idModuloEscolhido,
    palavrasChaves: data.palavrasChaves
  };

  console.log("data-->", newData);

  xhr.open('POST', 'https://tishellofriends.azurewebsites.net/api/completar-texto', true);
  xhr.setRequestHeader("Content-type", "application/json");
  xhr.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
  xhr.onreadystatechange = () => {
    if (xhr.readyState == 4) {
      if (xhr.status == 200) {
        alert("Atividade criada com sucesso");
        window.location.href = "listaAtividadesCompletaFrase.html"
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
  /*imprimeDadosCompletaTexto();*/
}


const formCompletaTexto = {
  getValue() {
    return {
      titulo: document.querySelector('#titulo').value,
      enunciado: document.querySelector('#enunciado').value,
      palavrasChaves: document.querySelector('#palavras').value,
    }
  },

  validateFields() {
    const { titulo, enunciado } = formCompletaTexto.getValue()
    if (titulo.trim() === "" || enunciado.trim() === "") {
      throw new Error("Por favor, preencha todos os campos")
    }
  },

  formatProvider() {
    let { titulo, enunciado, palavrasChaves } = formCompletaTexto.getValue()
    return { titulo, enunciado, palavrasChaves };
  },

  submit(event) {
    event.preventDefault()
    try {
      formCompletaTexto.validateFields()
      const SaveProviderCompletaTexto = formCompletaTexto.formatProvider()
      saveProviderCompletaTexto(SaveProviderCompletaTexto)
    } catch (error) {
      alert(error.message)
    }
  }
}

$('#modalInclusaoAtividadeCompletaTexto').modal('hide');
imprimeDadosDoTexto();
imprimePalavrasChaves();

