let idContrato = JSON.parse(localStorage.getItem('contratoSelecionado'));
urlIdContrato = ''.concat(`https://tishellofriends.azurewebsites.net/api/contrato/`, idContrato.event);
console.log(urlIdContrato);
          
let contratoPreenchido;
function getContratos() {
  fetch(urlIdContrato, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      console.log(data);
      //process the returned data
      let contratosPorId = document.querySelector('#content2');
      contratoPreenchido = "";

        var dataInicio = new Date(data.dataInicioContrato)
        var dataFormatadaInicio = dataInicio.toISOString().slice(0,10);
        dataFormatadaInicio = dataFormatadaInicio.split('-').reverse().join('/');
        
        var dataFinal = new Date(data.dataFinalContrato)
        var dataFormatadaFinal = dataFinal.toISOString().slice(0,10);
        dataFormatadaFinal = dataFormatadaFinal.split('-').reverse().join('/');
      // Montar texto HTML das atividades
      
        contratoPreenchido = contratoPreenchido + ` 
        <div class="row" id="content">
        <div id="contrato" style="text-align: justify;">
        <h1 style="text-align: center;">CONTRATO DE PRESTAÇÃO DE SERVIÇOS DE ENSINO DE LÍNGUA ESTRANGEIRA</h1><br/>
        <h1 style="text-align: center;">IDENTIFICAÇÃO DAS PARTES CONTRATANTES </h1><br/>
        <p>CONTRATANTE:
          <span id="nomeContratante">${data.nomeResponsavel}</span>, nacionalidade
          <span id="nacionalidade">${data.nacionalidade}</span>, 
          <span id="estadoCivil">${data.estadoCivil}</span>, 
          <span id="profissao">${data.profissao}</span>, 
          Carteira de Identidade nº 
          <span id="ci">${data.ci}</span>, 
          C.P.F. nº 
          <span id="cpf">${data.cpf}</span>, 
          residente na 
          <span id="endereco">${data.endereco}</span>, 
          nº 
          <span id="numero">${data.numero}</span>, bairro: 
          <span id="bairro">${data.bairro}</span>, Cidade: 
          <span id="cidade">${data.cidade}</span>, 
          CEP: 
          <span id="cep">${data.cep}</span>, no Estado de 
          <span id="estado">${data.estado}</span>, 
          RESPONSÁVEL pela(o)(s) aluna(o)(s): 
          <span id="nomeAluno">${data.nomeAluno}</span>.<br/>
        </p>
        <p>
          CONTRATADA: Joyce Adriana Lopes da Silva Lacerda, professora de Inglês, Carteira de Identidade nº MG XXXXXX, C.P.F. nº XXX.XXX.XXX-XX, residente na Rua A, nº 0, bairro: Centro, Cep XXXXX-XXXX, na Cidade de Contagem, no Estado de Minas Gerais.
        </p>  
        <p>
          As partes acima identificadas têm, entre si, justo e acertado o presente Contrato de Prestação de Serviços de Ensino de Língua Estrangeira, que se regerá pelas cláusulas seguintes e pelas condições descritas no presente.
        </p>
        <h1 style="text-align: center;">DO OBJETO DO CONTRATO</h1><br/>
        <p>
          Cláusula 1ª. O presente contrato tem como objeto a prestação, pela CONTRATADA ao CONTRATANTE, dos serviços de ensino do idioma Inglês.      
        </p>
        <h1 style="text-align: center;">DAS AULAS</h1><br/>
        <p>
          Cláusula 2ª. As aulas serão ministradas aos
          <span id="diaAula">${data.diaAula}</span>
          , no horário de 
          <span id="horario">${data.horario}</span> , 
          totalizando a carga horária semanal de 
          <span id="cargaHorariaSemanal">${data.cargaHorariaSemanal}</span> 
          horas, ressalvando o caso de feriados, que serão devidamente compensados em horário a ser acertado posteriormente.
        </p>
        <h1 style="text-align: center;">DA FREQUÊNCIA</h1><br/>
        <p>
          Cláusula 3ª. A fim de que possa receber o certificado ao final do curso, o CONTRATANTE não deverá se ausentar por mais de 25% (vinte e cinco por cento) das aulas.
        </p>
        <h1 style="text-align: center;">DO PAGAMENTO</h1><br/>
        <p>
          Cláusula 4ª. Pelos serviços prestados, o CONTRATANTE pagará à CONTRATADA o valor mensal de 
          <span id="valorMensalidade">${data.valorMensalidade}</span> 
          (<span id="valorExtensoMensalidade">${data.valorExtensoMensalidade}</span>), sendo o pagamento à vista em dinheiro ou PIX, a serem pagos até o dia 10 (dez) de cada mês.
        </p>
        <h1 style="text-align: center;">DA RESCISÃO</h1><br/>
        <p>
          Cláusula 5ª. O presente contrato poderá ser rescindido caso o CONTRATANTE avise a CONTRATADA com antecedência de 30 (trinta) dias, devendo estar pagas todas as parcelas até este momento, mensais ou proporcional às aulas ministradas.<br/>
          Cláusula 6ª. O presente instrumento também será rescindido caso o CONTRATANTE deixe de pagar a mensalidade após 15 (quinze) dias do vencimento.
        </p>
        <h1 style="text-align: center;">DO PRAZO</h1><br/>
        <p>
          Cláusula 7ª. O presente contrato terá validade entre o periodo de 
          <span id="dataInicioContrato">${dataFormatadaInicio}</span> ao dia 
          <span id="dataFinalContrato">${dataFormatadaFinal}</span>
          .
        </p>
        <h1 style="text-align: center;">CONDIÇÕES GERAIS</h1><br/>
        <p>
          Cláusula 8ª. Ao final deste contrato, o CONTRATANTE receberá um certificado de proficiência do curso.<br/>
          Cláusula 9ª. Não se incluem neste contrato os serviços de reforço e reciclagem, e o fornecimento de material didático utilizado no curso.
        </p>
        <h1 style="text-align: center;">DO FORO</h1>
        <p>
          Cláusula 10ª. Para dirimir quaisquer controvérsias oriundas do contrato, as partes elegem o foro da comarca de Contagem.<br/>
          Por estarem assim justos e contratados, firmam o presente instrumento, em duas vias de igual teor.<br/>
        </p>
        <p>
          Data de início do contrato: ${dataFormatadaInicio}
        </p>
        <p>
          Contagem,______de__________________de__________.
        </p>
        <div>
        <p>
        Contratante: <hr>
     </p>
     <p>
       Contratada: <hr>
     </p>
   </div>
   <br>
</div>
<p>
 <input type="button" value="Imprimir" id="btnImprimir" onclick="CriaPDF()" />
</p>
<br>
<br>
<br>
<br>
</div>
                    `;       
     

      // Preencher a DIV com o texto HTML
      contratosPorId.innerHTML = contratoPreenchido;
    })
}
getContratos();


function CriaPDF() {
    
    // CRIA UM OBJETO WINDOW
    var win = window.open('', '', 'height=700,width=700');
    win.document.write('<html><head>');
    win.document.write('<title>Contrato</title>');
    win.document.write('</head>');
    win.document.write('<body>');
    win.document.write(contratoPreenchido);
    win.document.close();
    win.print();
}




