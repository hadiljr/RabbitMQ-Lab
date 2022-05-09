# Laboratorio Rabbit MQ
---

Aplicação de laboratório simples com um microserviço produtor e outro consumidor.

### Arquitetura de Pastas/Projetos
- Adaptação de DDD Layers

### Linguagem de Programação e Frameworks:
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

### Guia de Utilização
Quando o Rabbit MQ estiver operacional, entrar com o login e senha padrão (guest,guest).
Criar uma nova queue com o nome consumer.lab, durable.
Fazer o bind na exchange "amq.direct".
Caso queira utilizar outras exchanges ou queue, basta alterar as variaveis de ambiente no docker-compose.yml

