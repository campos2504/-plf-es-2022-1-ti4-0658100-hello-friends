
const saveProviderContrato = (data) => {
    const renamedData = {
      nomeResponsavel : data.nomeResponsavel,
      nacionalidade : data.nacionalidade,
      estadoCivil : data.estadoCivil,
      profissao : data.profissao,
      ci : data.ci,
      cpf : data.cpf,
      endereco : data.endereco,
      numero : data.numero,
      bairro : data.bairro,
      cidade : data.cidade,
      estado : data.estado,
      cep : data.cep,
      nomeAluno : data.nomeAluno,
      diaAula : data.diaAula,
      horario : data.horario,
      cargaHorariaSemanal : data.cargaHorariaSemanal,
      ValorMensalidade : data.ValorMensalidade,
      valorExtensoMensalidade : data.valorExtensoMensalidade,
      dataInicioContrato : data.dataInicioContrato,
      dataFinalContrato : data.dataFinalContrato,
    }
    const xhr = new XMLHttpRequest();
  
    xhr.open('POST', 'https://tishellofriends.azurewebsites.net/api/contrato', true);
    xhr.setRequestHeader("Content-type", "application/json");
    xhr.setRequestHeader('Authorization', `Bearer ${retornarTokenUsuario()}`);
    xhr.onreadystatechange = () => {
      if (xhr.readyState == 4) {
        if (xhr.status == 200) {
          alert("Contrato incluído com sucesso!");
          window.location.reload();
        }
        else {
          alert('Não foi possivel criar a atividade');
        }
      }
    }
    xhr.send(JSON.stringify(renamedData));
    getContratos();
  }
  
  const formContrato = {
    getValue() {
      return {
      nomeResponsavel : document.querySelector('#nomeResponsavel').value,
      nacionalidade : document.querySelector('#nacionalidade').value,
      estadoCivil : document.querySelector('#estadoCivil').value,
      profissao : document.querySelector('#profissao').value,
      ci : document.querySelector('#ci').value,
      cpf : document.querySelector('#cpf').value,
      endereco : document.querySelector('#endereco').value,
      numero : document.querySelector('#numero').value,
      bairro : document.querySelector('#bairro').value,
      cidade : document.querySelector('#cidade').value,
      estado : document.querySelector('#estado').value,
      cep : document.querySelector('#cep').value,
      nomeAluno : document.querySelector('#nomeAluno').value,
      diaAula : document.querySelector('#diaAula').value,
      horario : document.querySelector('#horario').value,
      cargaHorariaSemanal : document.querySelector('#cargaHorariaSemanal').value,
      ValorMensalidade : document.querySelector('#ValorMensalidade').value,
      valorExtensoMensalidade : document.querySelector('#valorExtensoMensalidade').value,
      dataInicioContrato : document.querySelector('#dataInicioContrato').value,
      dataFinalContrato : document.querySelector('#dataFinalContrato').value,
      }
    },
  
    validateFields() {
      const { nomeResponsavel, nacionalidade, estadoCivil, profissao, ci, cpf, endereco, 
        numero, bairro, cidade, estado, cep, nomeAluno, diaAula, horario, cargaHorariaSemanal, ValorMensalidade, 
        valorExtensoMensalidade, dataInicioContrato, dataFinalContrato } = formContrato.getValue()
  
      if (nomeResponsavel.trim() === "" ||  
      nacionalidade.trim() === "" ||
      estadoCivil.trim() === "" ||
      profissao.trim() === "" ||
      ci.trim() === "" ||
      cpf.trim() === "" ||
      endereco.trim() === ""||
      numero.trim() === "" ||
      bairro.trim() === "" ||
      cidade.trim() === "" ||
      estado.trim() === "" ||
      cep.trim() === "" ||
      nomeAluno.trim() === "" ||
      diaAula.trim() === "" ||
      horario.trim() === "" ||
      cargaHorariaSemanal.trim() === "" ||
      ValorMensalidade.trim() === "" ||
      valorExtensoMensalidade.trim() === "" ||
      dataInicioContrato.trim() === "" ||
      dataFinalContrato.trim() === "") {
        throw new Error("Por favor, preencha todos os campos")
      }
    },
  
    formatProvider() {
      let { nomeResponsavel, nacionalidade, estadoCivil, profissao, ci, cpf, endereco, 
        numero, bairro, cidade, estado, cep, nomeAluno, diaAula, horario, cargaHorariaSemanal, ValorMensalidade, 
        valorExtensoMensalidade, dataInicioContrato, dataFinalContrato } = formContrato.getValue()
      return {
        nomeResponsavel, nacionalidade, estadoCivil, profissao, ci, cpf, endereco, 
        numero, bairro, cidade, estado, cep, nomeAluno, diaAula, horario, cargaHorariaSemanal, ValorMensalidade, 
        valorExtensoMensalidade, dataInicioContrato, dataFinalContrato
      }
    },
  
  
    submit(event) {
      event.preventDefault()
      try {
        formContrato.validateFields()
        const SaveProviderContrato = formContrato.formatProvider()
        saveProviderContrato(SaveProviderContrato)
      } catch (error) {
        alert(error.message)
      }
    }
  }
  
  $('#modalInclusaoContrato').modal('hide');
  getContratos();

