<h1>
    A aplicação de console LocadoraJogos foi criada com o intuito de simular uma locadora real de jogos de videogames</p>
<h1>
    &nbsp;</p>
<h2 style="height: 8px; width: 1239px; margin-top: 0px">
    A aplicação é dividida em 2 partes:
</h2>
<p>
    * Primeira: simula alguém que trabalha na locadora podendo cadastrar novos jogos ou ver clientes que alugaram jogos
</p>
<p>
    * Segunda: simula um cliente se cadastrando no serviço da locadora e podendo alugar jogos
</p>

A aplicação utiliza o server json para simular uma api. Para testar o código crie um arquivo chamado db.json com os seguintes dados:

```json
{
  "jogos": [
    {
      "id": 1,
      "Nome": "Persona 5",
      "Genero": "RPG",
      "Desenvolvedora": "Atlus",
      "Descricao": "Persona 5 acontece na Tóquio de hoje e segue um estudante do ensino médio, com o codinome Joker (Coringa), após sua transferência para a Academia Shujin após ser colocado em liberdade condicional por um assalto do qual ele foi falsamente acusado",
      "PrecoAluguel": 8
    },
    {
      "id": 2,
      "Nome": "Grand Theft Auto 5",
      "Genero": "Mundo Aberto",
      "Desenvolvedora": "Rockstar",
      "Descricao": "O game se passa no estado ficcional de San Andreas, baseado na Califórnia do Sul, nos EUA. Traz a história de campanha simultânea de três criminosos: o ladrão de bancos aposentado Michael 'Mike' De Santa, o gângster de rua Franklin Clinton e o traficante de armas psicopata Trevor Philips",
      "PrecoAluguel": 10
    },
    {
      "id": 3,
      "Nome": "Battlefield 4",
      "Genero": "FPS",
      "Desenvolvedora": "DICE",
      "Descricao": "A campanha de Battlefield 4 se desenrola em 2020, seis anos após os eventos do seu antecessor. As tensões entre os Estados Unidos e o Irão estão muito elevadas devido a um conflito que já dura seis anos",
      "PrecoAluguel": 9.7
    },
    {
      "id": 4,
      "Nome": "Genshin Impact",
      "Genero": null,
      "Desenvolvedora": null,
      "Descricao": "Hoyoverse",
      "PrecoAluguel": 2.0
    }
  ],
  "clientes": [
    {
      "id": 1,
      "CPF": "12345678901",
      "NomeCliente": "João Antônio",
      "JogoAlugado": [
        {
          "id": 1,
          "Nome": "Persona 5",
          "Genero": "RPG",
          "Desenvolvedora": "Atlus",
          "Descricao": "Persona 5 acontece na Tóquio de hoje e segue um estudante do ensino médio, com o codinome Joker (Coringa), após sua transferência para a Academia Shujin após ser colocado em liberdade condicional por um assalto do qual ele foi falsamente acusado",
          "PrecoAluguel": 8
        },
        {
          "id": 3,
          "Nome": "Battlefield 4",
          "Genero": "FPS",
          "Desenvolvedora": "DICE",
          "Descricao": "A campanha de Battlefield 4 se desenrola em 2020, seis anos após os eventos do seu antecessor. As tensões entre os Estados Unidos e o Irão estão muito elevadas devido a um conflito que já dura seis anos",
          "PrecoAluguel": 9.7
        }
      ],
      "DataEntrega": "2023-07-22T10:30:00Z",
      "CustoTotal": 17.7
    },
    {
      "id": 2,
      "CPF": "09876543211",
      "NomeCliente": "Antônio",
      "JogoAlugado": [
        {
          "id": 4,
          "Nome": "Genshin Impact",
          "Genero": "Aventura",
          "Desenvolvedora": "Hoyoverse",
          "Descricao": "Um jogo de aventura em um mundo rico",
          "PrecoAluguel": 2.0
        },
        {
          "id": 1,
          "Nome": "Persona 5",
          "Genero": "RPG",
          "Desenvolvedora": "Atlus",
          "Descricao": "Persona 5 acontece na Tóquio de hoje e segue um estudante do ensino médio, com o codinome Joker (Coringa), após sua transferência para a Academia Shujin após ser colocado em liberdade condicional por um assalto do qual ele foi falsamente acusado",
          "PrecoAluguel": 8.0
        }
      ],
      "DataEntrega": "2023-12-15T16:46:42.0016033-03:00",
      "CustoTotal": 10.0
    }
  ]
}
```
&nbsp;</p>

Depois instale o server json com o seguinte comando:
```bash
npm install -g json-server
```

Logo em seguida rode o comando:
```bash
json-server --watch db.json
```

A porta padrão é a [http://localhost:3000](http://localhost:3000)

As rotas são:</br>
[http://localhost:3000/jogos](http://localhost:3000/jogos)
</br>
[http://localhost:3000/clientes](http://localhost:3000/clientes)

