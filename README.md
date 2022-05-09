# Laboratorio Rabbit MQ
---

Aplica��o de laborat�rio simples com um microservi�o produtor e outro consumidor.

### Arquitetura de Pastas/Projetos
- Adapta��o de DDD Layers

### Linguagem de Programa��o e Frameworks:
- C#
- Dot Net 5
- Entity Framework Core 5
- Swagger

### Infraestrutura
- Docker / Docker Compose
- RabbitMQ
- SQL Server Developer Edition

### Fluxo de Dados
![](/RabbitMQ-Lab-Fluxo.drawio.png)

### Guia de Utiliza��o
Quando o Rabbit MQ estiver operacional, entrar com o login e senha padr�o (guest,guest).
Criar uma nova queue com o nome consumer.lab, durable.
Fazer o bind na exchange "amq.direct".
Caso queira utilizar outras exchanges ou queue, basta alterar as variaveis de ambiente no docker-compose.yml

