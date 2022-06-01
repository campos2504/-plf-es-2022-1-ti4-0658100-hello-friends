# Hello Friends

Plataforma web de aprendizado de Língua Inglesa.

## Alunos integrantes da equipe

* Helen Camila de Oliveira
* Izabella de Castro Lucas
* Pedro Campos Miranda
* Nataniel Geraldo Mendes Peixoto

## Professoras responsáveis

* Cleiton Silva Tavares
* Soraia Lúcia da Silva

## Instruções de utilização

O trabalho consiste em dois projetos desacoplados, um para o BackEnd da solução e outro para o FrontEnd. O projeto BackEnd é uma API Rest implementada por meio do framework ASP.NET Core 2.2, enquanto que o FrontEnd é composto por HTML, CSS e JavaScript convencional, sem uma biblioteca ou framework FrontEnd específico. A comunicação e troca de dados entre os dois projetos é realizada através de requisições AJAX que enviam e retornam JSON.

### Configuração do BackEnd

Esse projeto utiliza o framework ASP.NET Core 2.2, que por sua vez possui dependência na plataforma .NET Core 2.2. O link para baixar o .NET Core 2.2 é esse: https://dotnet.microsoft.com/download/dotnet/2.2. Também será necessário [instalar o Banco de Dados SQL Server](https://www.youtube.com/watch?v=LxtLqS-9KYo).

Após fazer as devidas configurações será necessário criar o banco de dados do projeto BackEnd, sendo possível fazer essa configuração através do Gerenciador de Pacotes da IDE Visual Studio ou através da Linha de Comando via terminal.

**Visual Studio:** Será necessário [instalar a IDE](https://visualstudio.microsoft.com/pt-br/vs/) e então abrir o projeto dentro da mesma, para isso será necessário selecionar a opção Open Project/Solution e então escolher o arquivo **plf-es-2021-2-ti3-6654100-projeto-de-ingles\Codigo\BackEnd\HelloFriends\HelloFriends.sln**. Dentro do Gerenciador de Pacotes da IDE será necessário executar os dois comandos abaixo:

```console
Update-Database -Context ApplicationDbContext
Update-Database -Context HelloFriendsContext
```

**Linha de Comando:** Para configurar o banco via linha de comando será necessário instalar o [dotnet-ef](https://docs.microsoft.com/pt-br/ef/core/cli/dotnet), para isso é necessário já estar com o .NET Core 2.2 instalado na máquina. Após instalar o dotnet-ef basta executar os comandos abaixo no terminal:

```console
$ cd plf-es-2021-2-ti3-6654100-projeto-de-ingles\Codigo\BackEnd\HelloFriends\src\HelloFriendsAPI
$ dotnet ef database update --context ApplicationDbContext
$ dotnet ef database update --context HelloFriendsContext
```

### Inicializar BackEnd

Existem duas maneiras de executar o projeto: através da IDE [Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/vs/) ou via Linha de Comando no terminal.

#### Inicialização através do Visual Studio

Para executar o projeto via Visual Studio é necessário realizar a instalação da mesma e então abrir o projeto nela, para abrir o projeto será necessário escolher o arquivo **plf-es-2021-2-ti3-6654100-projeto-de-ingles\Codigo\BackEnd\HelloFriends\HelloFriends.sln** através da opção Open Project presente no Visual Studio, essa escolhe irá aparecer após iniciar a IDE.

![image](https://user-images.githubusercontent.com/36521129/138569684-8981f5bd-c4db-41a8-be88-ff9bf97a0b45.png)

Após abrir o projeto no Visual Studio basta iniciar ele:

![image](https://user-images.githubusercontent.com/36521129/138569730-e5c9291c-c45e-4cc4-989b-d488e309e45a.png)

#### Inicialização através da Linha de Comando

Para iniciar o projeto através da linha de comando basta abrir o terminal do computador e executar os comandos:

```console
$ cd plf-es-2021-2-ti3-6654100-projeto-de-ingles\Codigo\BackEnd\HelloFriends\src\HelloFriendsAPI
$ dotnet run
```
O comando dotnet é instalado automáticamente durante a instalação do .NET Core 2.2.

### Utilização do FrontEnd

O fluxo de navegação entre as telas do FrontEnd ainda não está finalizado, mas as telas desenvolvidas já estão integradas com o BackEnd. Para testar basta ir até a pasta plf-es-2021-2-ti3-6654100-projeto-de-ingles\Codigo\FrontEnd e escolher algum arquivo HTML para interagir.


