google.charts.load('current', { 'packages': ['corechart'] });


function getMedalha() {
    let baseURLBuscaMedalhas = `https://localhost:44327/api/medalha`;
    let request = new XMLHttpRequest();
    request.open('GET', baseURLBuscaMedalhas, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dados = request.responseText;
    var objeto = JSON.parse(dados);

    return objeto;
  }

  function getModulo() {
    let baseURLModulo = `https://localhost:44327/api/modulos/qtdModulosConcluidos`;
    let request = new XMLHttpRequest();
    request.open('GET', baseURLModulo, false);
    request.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    request.send();
    const dadosModulo = request.responseText;
    var objetoModulo = JSON.parse(dadosModulo);
    console.log("modulo" + objetoModulo);
    return objetoModulo;
  }
getModulo();

//Gráfico de barra - Total medalhas
function desenharBarraMedalhas() {

    let medalhas = getMedalha(); //getInformação

    let valorTotalMedalhaOuro = 0;
    let valorTotalMedalhaPrata = 0;
    let valorTotalMedalhaBronze = 0;

    for (i = 0; i < medalhas.length; i++) {

       
        if(medalhas[i].tipoMedalha == 'Ouro'){
            valorTotalMedalhaOuro += 1;
        }     
        
        if(medalhas[i].tipoMedalha == 'Prata'){
            valorTotalMedalhaPrata += 1;
        }

        if(medalhas[i].tipoMedalha == 'Bronze'){
            valorTotalMedalhaBronze += 1;
        }

    }

    let tabela = new google.visualization.DataTable();
    tabela.addColumn('string', 'categorias');
    tabela.addColumn('number', 'quantidade de medalhas');
    tabela.addRows([

    ]);

    tabela.addRows([
        ['Ouro', valorTotalMedalhaOuro]
    ])    

    tabela.addRows([
        ['Prata', valorTotalMedalhaPrata]
    ])

    tabela.addRows([
        ['Bronze', valorTotalMedalhaBronze]
    ])

  

    let opcoes = {
        'height': 500,
        'width':1350,
    };

    let grafico = new google.visualization.ColumnChart(document.getElementById('graficoBarra'));
    grafico.draw(tabela, opcoes)

}
google.charts.setOnLoadCallback(desenharBarraMedalhas);


//Gráfico de barra - quantidade de Modulos feitos
function desenharBarraModulos() {

    let modulos = getModulo();
    var ListaNomeModulos = new Array;
    var ListaQuantAlunosFinalizaramModulo = new Array;
    
    for (i = 0; i < modulos.length; i++) {
        ListaNomeModulos.push(modulos[i].nomeModulo);
        ListaQuantAlunosFinalizaramModulo.push(modulos[i].repeticoes);
    }

    
console.log('!!' + ListaNomeModulos);
console.log('111!!' + ListaQuantAlunosFinalizaramModulo);

    let tabela = new google.visualization.DataTable();
    tabela.addColumn('string', 'categorias');
    tabela.addColumn('number', 'Quantidade de alunos que finalizaram o módulo');
    tabela.addRows([

    ]);

    for (i = 0; i < modulos.length; i++) {
        tabela.addRows([
            [ListaNomeModulos[i], ListaQuantAlunosFinalizaramModulo[i]]
        ]) 
    }
    

    let opcoes = {
        'height': 500,
        'width':1350,
    };

    let grafico = new google.visualization.ColumnChart(document.getElementById('graficoBarraModulo'));
    grafico.draw(tabela, opcoes)

}
google.charts.setOnLoadCallback(desenharBarraModulos);
