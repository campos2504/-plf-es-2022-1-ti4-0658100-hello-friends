let dadosUsuario;
let urlUpdateAluno;
const urlFoto = 'https://localhost:44327/api/alunos';


function carregarFotoUsuario() {

  dadosUsuario = JSON.parse(localStorage.getItem('userToken'));
  urlUpdateAluno = ''.concat(urlFoto, '/email/', dadosUsuario.user.email);
  console.log(urlUpdateAluno);
  
  fetch(urlUpdateAluno, {
    headers: {
      'Authorization': `Bearer ${retornarTokenUsuario()}`
    },
  }).then(result => result.json())
    .then((data) => {
      console.log(data.imagemSrc);
      document.getElementById('fotoUsuario').src = data.imagemSrc;
    }) 
};

carregarFotoUsuario();