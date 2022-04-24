let dadosUsuario;
let urlUpdateAluno;
const urlFoto = 'https://localhost:44327/api/alunos';


function carregarFotoUsuario() {

  dadosUsuario = JSON.parse(localStorage.getItem('userToken'));
  urlUpdateAluno = ''.concat(urlFoto, '/email/', dadosUsuario.user.email);
  
  if (dadosUsuario.userType === "aluno") {
    fetch(urlUpdateAluno, {
      headers: {
        'Authorization': `Bearer ${retornarTokenUsuario()}`
      },
    }).then(result => result.json())
      .then((data) => {
        
      })
  }else{
    document.getElementById('fotoUsuario').src = "img/logo.png"
  }
};

carregarFotoUsuario();