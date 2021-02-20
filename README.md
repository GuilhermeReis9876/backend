<h2>Projeto Desafio Localiza - Locação de veículos de passeio (.NET)</h2>
<p>API de um processo de locação de veículos que possui as funcionalidades de registro de usuários, veículos, marcas, modelos, reservas e checklists.</p>
<h3>Equipe</h3>
<ul>
  <li><a href="https://github.com/cassio-morais">Cássio Morais</a> ajudou no desenvolvimento, modelagem e implementação das regras de negócios do sistema, além de ser responsável por gerenciar e publicar a aplicação.</li> 
  <li><a href="https://github.com/vstorresti">Victor Torres</a> ajudou no desenvolvimento, modelagem e arquitetura do sistema, além de ser responsável por implementar configurações de segurança do sistema.</li>
</ul>
<h3>Estrutura do Projeto</h3>
Utilizamos como referência uma abstração da arquitetura Clean, com o intuito de desacoplar a regra de negócio do sistema permitindo uma maior facilidade de manutenção.
<ul>
  <li><b>Domain</b> - Camada que contém nossas models/entidades, interface de repositório dessas models e a as ViewModels para Data Transfer Object. </li> 
  <li><b>Application</b> -  Regras de negócios e suas interfaces. </li> 
  <li><b>Infrastructure</b> - Implementação do Entity Framework, DTO Handler e a implementação dos repositórios.</li> 
  <li><b>Controllers</b> - Controllers, em suma, que utilizam o protocolo HTTP e fazemos o tratamento de acessos usando JWT para autenticação e autorização. </li> 
  <li><b>IoC</b> - Container para injeção de dependência das interfaces de serviço, infraestrutura (repositórios) e utilitários.</li>
  <li><b>Migration</b> - Gerenciador de migrations do Entity Framework. </li>
</ul>

📦api

 ┣ 📂Application 
 
 ┃ ┣ 📂Interfaces
 
 ┃ ┗ 📂Services
 
 ┣ 📂Controllers
 
 ┣ 📂Domain
 
 ┃ ┣ 📂Interfaces
 
 ┃ ┣ 📂Models
 
 ┃ ┗ 📂ViewModels
 
 ┣ 📂Infrastructure 
 
 ┃ ┣ 📂Data
 
 ┃ ┣ 📂DtoHandler
 
 ┃ ┗ 📂Repositories
 
 ┣ 📂IoC
 
 ┗ 📂Migrations

<h3> Implementações de Segurança </h3>
 <p>A api faz uso de Jason Web Token (JWT) para autenticação de endpoints durante o uso além da utilização do padrão de criptografia Hash Salting para utilizando de chave HMAC512 para garantir uma maior segurança a senha do usuário.</p>
