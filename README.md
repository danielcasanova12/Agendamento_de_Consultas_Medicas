# Agendamento_de_Consultas_Medicas
 
# Plataforma de Agendamento de Consultas Médicas

Este repositório contém a implementação de uma Plataforma de Agendamento de Consultas Médicas, um sistema que visa facilitar o agendamento de consultas entre médicos e pacientes. Esta plataforma oferece uma experiência otimizada para médicos, pacientes e recepcionistas, além de garantir a eficiência na gestão de horários e especialidades médicas.

## Estrutura do Projeto

O projeto está organizado em três camadas principais:

1. **Modelo de Negócio (Library):** Nesta camada, encontram-se as classes e lógicas de negócio, encapsulando as regras do sistema.

2. **Front End (ASP.NET Razor Pages):** Aqui, você encontrará a interface de usuário para interação e visualização de dados. Utilizamos o framework ASP.NET Razor Pages para criar as páginas web.

3. **Back End (REST API):** Esta camada consiste em serviços RESTful que gerenciam e processam os dados. A API backend é responsável pela comunicação entre o front end e o banco de dados.

## Classes Básicas

O sistema é composto pelas seguintes classes básicas:

1. **Médico:** Representa os profissionais de saúde disponíveis para consulta. Atributos incluem nome, especialidade, número de registro profissional e horários disponíveis.

2. **Paciente:** Representa os usuários que buscam agendar consultas. Atributos incluem nome, sobrenome, número de identificação e histórico médico.

3. **Consulta:** Representa os agendamentos feitos pelos pacientes. Atributos incluem médico, paciente, data e hora, tipo de consulta (presencial ou online) e observações.

4. **Especialidade:** Representa as áreas de atuação dos médicos. Atributos incluem nome da especialidade e descrição.

5. **Recepcionista:** Representa os funcionários responsáveis pelo gerenciamento dos agendamentos. Atributos incluem nome, sobrenome, número de identificação e número de telefone.

## Associações

O sistema possui as seguintes associações entre as entidades:

- Um médico pode ter várias consultas agendadas.
- Um paciente pode agendar várias consultas com diferentes médicos.
- Uma especialidade pode ser associada a vários médicos.
- Um recepcionista pode gerenciar vários agendamentos.

## Requisitos

Para o desenvolvimento deste projeto, os seguintes requisitos devem ser atendidos:

- Utilize o framework ASP.NET Web Razor Pages para criar a interface de usuário.
- Implemente operações CRUD (Create, Read, Update, Delete) para as classes Médico, Paciente, Consulta, Especialidade e Recepcionista.
- Implemente funcionalidades de agendamento que permitam aos pacientes escolher médico, data e hora para suas consultas.
- Desenvolva um dashboard que exiba resumos de consultas, informações sobre os médicos mais procurados e os horários mais solicitados.
- Garanta a integridade dos dados com validações adequadas.
- Desenvolva uma API RESTful no backend para gerenciar e processar os dados, garantindo a comunicação eficiente entre o front end e o banco de dados.
- A camada de Modelo de Negócio (Library) deve encapsular as regras e lógicas do sistema.


## Como abrir:

- Abra o projeto no Visual Studio Code;
- Clique com o botão direito no arquivo Program.cs, que está dentro da pasta Agenda_Web;
- Clique em "Open in Integrated Terminal";
- No terminal, digite "dotnet watch run";
- Clique com o botão direito no arquivo Program.cs, que está dentro da pasta agendamento_webapi;
- Clique em "Open in Integrated Terminal";
- No terminal, digite "dotnet watch run".
