# SoftPlan Challenge

## Arquitetura
 As Api's foram desenvolvidas na versão .net core 3.1 por ser uma das versões mais recentes e mais estáveis do framework. 

###### Calcula Juros
A Api de cálculo de juros foi implementada em duas camadas (Api e Domain). Na camada de domínio foi utilizado Commands e CommandHandlers pois esse padrão deixa o código fonte mais legível e organizado por responsabilidades. A comunicação com outra api foi feita via protocolo http. Sendo assim, a técnica de Retry foi utilizada para casos de instabilidade na requisição.

###### Taxa de Juros
A Api de taxa de juros foi implementada em duas camadas (Api e Infra.Data). Por ter apenas um endpoint com um get, a injeção de dependência foi feita diretamente na controller , evitando complexidade criando outras camadas.

## Como executar as aplicações?
Abra o prompt de comando, navegue até a raiz do projeto e digite ```docker-compose up -d --build```. Esse comando irá compilar e executar as aplicações, além de não travar seu prompt de comando. As Apis respondem pelos seguintes endereços:

**Calcula Juros**: http://localhost:5005/swagger  
**Retorna Taxa de Juros**: http://localhost:5006/swagger
