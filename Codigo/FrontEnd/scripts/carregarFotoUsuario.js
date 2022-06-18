let dadosUsuario;
let urlUpdateAluno;
const urlFoto = 'http://tishellofriends.azurewebsites.net/api/alunos';


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
        document.getElementById('fotoUsuario').src = data.imagemSrc;
      })
  }else{
    document.getElementById('fotoUsuario').src = "img/logo.png"
  }
};

carregarFotoUsuario();