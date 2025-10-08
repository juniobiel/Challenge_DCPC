# DCPC Challenge

Repositório para desafio técnico da DCPC.

- [x] CRUD Com JWT
- [x] Teste Unitário
- [x] Cadastrar Aluno (Front-end)
- [x] SQLite

Extras:
- [x] DockerFile
- [x] (IAM) Identity Entity Framework
- [x] Aplicação de Padrão Services (Arquitetura em camadas)


## Rodando a API (Backend)
Para rodar a aplicação é necessário a instalação do .net sdk, uma vez que a aplicação não está hospedada.

https://dotnet.microsoft.com/download/dotnet a versão utilizada neste projeto foi a 9.0.

Depois de instalado, recomendo abrir o arquivo `DCPC.Challenge.sln` diretamente no visual studio e após isso terá a opção de rodar a aplicação.

![Botão Rodar API Visual Studio](https://i.imgur.com/BNVzh3s.png)

Assim, irá abrir o Swagger com a documentação da API contendo todos os end-points.

É possível testar o funcionamento da api diretamente no swagger.

## Rodando a aplicação

Instalar o nodejs e o Angular Cli.
Abrir a pasta do projeto `src/DCPC-challenge-escola-app` no terminal.

Rodar o comando `npm install` e após a instalação da pasta node_modules, rodar o comando `ng serve`.

Para realizar o login e realizar um cadastro, certifique-se de deixar o back-end rodando. No campo usuário e senha utilize estas credenciais:
```json
usuario: "admin"
senha: "Admin@123456"
```