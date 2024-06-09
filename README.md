# FreelasUnit-Application
Aplicação FullStack desenvolvida para a matéria de Gerenciamento de Projetos (UNIT)

Foi construída com o proposito de ser uma plataforma web onde Freelancers e Empresas/Clientes
possam se encontrar e fechar contratos.

## Tutorial para rodar a aplicação

Para começar, siga estes passos:

1. Crie uma pasta

2. Abra o CMD dentro da pasta

3. (Com o git bash instalado) Execute o comando
```
4. git clone https://github.com/gabrieldesantana/socialmedia-freelas-unit
```
5. Abrir a pasta socialmedia-freelas-unit/SocialMediaFreelas.App

6. Clique em alguma parte vazia dentro da pasta com o botão direito do Mouse e busque pela opção "Abrir com Code"

7. (Caso a opção não apareça logo de cara) Clique em "Mostra mais Opções"

8. Após abrir o VS Code, Procure a opção Teminal/New Terminal (Conforme mostrado na Imagem)
   ![image](https://github.com/gabrieldesantana/socialmedia-freelas-unit/assets/85038581/4ae11a2e-5b2b-467a-864f-f800c65a00ca)

9. Após abrir o Terminal, Verifiquem se estão no Diretorio Correto. (Conforme mostrado na Imagem)
  ![image](https://github.com/gabrieldesantana/socialmedia-freelas-unit/assets/85038581/1d98ae74-a049-4d8d-9a93-48beec55333f)

10. Execute o seguinte comando
```
11. dotnet restore
```

12. Em seguida, execute o comando
```
13. dotnet watch run
```

12. Para validar se está tudo ocorrendo bem, vá até a rota /login/freelancer ou /login/cliente
```
12.1. Exemplo: http://localhost:5298/login/cliente
```

## Stack de desenvolvimento front-end
Razor Pages( HTML, CSS, JS ).

## Stack de desenvolvimento back-end
Foi utilizado C#, Asp.Net Core, Swagger para documentar as APIs, EF Core como ORM para interagir com um banco de dados SQLite, e Sessions para autenticação
