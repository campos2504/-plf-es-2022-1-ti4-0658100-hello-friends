let nomeUsuario;
let urlNomeUsuario;
const urlNome = 'https://localhost:44327/api/alunos';


function mensagemBoasVindas() {

    nomeUsuario = JSON.parse(localStorage.getItem('userToken'));
    urlNomeUsuario = ''.concat(urlNome, '/email/', nomeUsuario.user.email);
    console.log(urlNomeUsuario);

    if (dadosUsuario.userType === "aluno") {
        fetch(urlNomeUsuario, {
            headers: {
                'Authorization': `Bearer ${retornarTokenUsuario()}`
            },
        }).then(result => result.json())
            .then((data) => {
                console.log(data);
                document.getElementById('nomeUsuarioCorrente').innerHTML = data.nomeCompleto;
            })
    }else{
        document.getElementById('nomeUsuarioCorrente').innerHTML = "Welcome, teacher!"
    }
};

mensagemBoasVindas();