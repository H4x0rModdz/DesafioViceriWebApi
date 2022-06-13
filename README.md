<div align="center"># Desafio Para o Grupo ViceriWebApi # </div>
<div align="center">Um desafio feito para a empresa Grupo Viceri</div>

<hr/>

# Resumo sobre a API
<strong>Frameworks e Modelo do Projeto:</strong> Utilizei para começo da minha API o ASP.NET Core Web API com o Swagger(Onde fiz um modelo de camadas com Controller, Repository, Models e Service).
######
<strong>Dependências Utilizadas:</strong> Microsoft Entity Framework Core, SQL Server, VS Code Generator e o BCrypt.Net(para criptografar minhas senhas). 
######
<strong>Controller:</strong> Realizei tarefas com verificações em cada etapa(Adicionar, Deletar, Atualizar, Editar, Buscar por Id e Buscar Todos) por meio de Try Catch para sempre retornar Exceptions caso o usuário utilize algum método de forma incorreta.
######
<strong>Repository:</strong> Em meu Repository criei três verificações booleanas (EhCpfJaCadastrado, EhEmailJaCadastrado e EhVerificaSeUsuarioExiste).
<br/>Na <strong>EhCpfCadastrado</strong>, consultei o banco para me retornar uma lista de CPFs já cadastrados, caso me retornasse 0, o CPF estaria pronto para uso dentro do Cadastro de Usuários, caso me retornasse maior que 0(que já me colocaria na parte de edição, onde fiz pela lógica caso fosse meu próprio cpf "consultando pelo Id do usuário", ele me deixasse fazer a edição sem problemas. Caso fosse um CPF de outro Id, barrava a edição).
<br/>Na <strong>EhEmailJaCadastrado</strong> a lógica foi a mesma da anterior, porém, com o Email ao invés do CPF.
<br/>Na <strong>EhVerificaSeUsuarioExiste</strong>, fiz uma consulta no banco onde me retornava o id do usuário numa lista. Caso retornasse = 0, retornaria "False" então não existia um usuário com aquele Id no banco, logo, a minha consulta por Id retornaria uma Exception com "Id de Usuário não existe", caso fosse = 1 ele retornava "True" e o Usuário com seu respectivo Id procurado.
######
<strong>Service:</strong> Dentro da Service utilizei minhas verificações booleanas da Repository para utilizar Exceptions caso o usuário não esteja atendendo os requisitos mínimos da utilização da API(que são os requisitos mínimos Desafio.PDF). Exceptions essas que mostram se o Email e CPF já existem, se a senha foi preenchida corretamente e se o Id existe.
######
<strong>Model:</strong> Dentro da minha Model, criei o modelo Usuário, onde atendia aos requisitos de: Id(Guid), Nome(string), Email(string), Senha(onde criei uma string private _Senha e uma string public Senha para poder já criptografar e, futuramente, caso necessite, descriptografar pela própria Model. Também adicionei uma verificação para ver se a Senha passada estava null, ou melhor, desta forma "". Caso esteja, ela não criptografa e retorna a senha sem criptografia para que retorne uma Exception, sem bugs, para o Usuário), CPF(string "apenas 11 dígitos") e DataNascimento(DateTime).
