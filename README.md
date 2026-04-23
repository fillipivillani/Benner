# Network Connectivity - Teste Técnico

## 📌 Descrição

Este projeto implementa uma classe `Network` em C# capaz de gerenciar conexões entre elementos, permitindo verificar conectividade direta e indireta, além de calcular o nível de conexão entre dois elementos.

O problema foi modelado como um **grafo não-direcionado**, utilizando **lista de adjacência com HashSet** para melhor performance.

---

## 🛠️ Tecnologias

* C#
* .NET
* Estrutura de dados (Grafos)
* BFS (Breadth-First Search)

---

## 🧠 Abordagem

* Cada elemento é representado como um nó do grafo.
* As conexões entre elementos são arestas bidirecionais.
* Para verificar conectividade e calcular distância, foi utilizado o algoritmo **BFS (Breadth-First Search)**.

Essa abordagem foi escolhida pois permite:

* Verificar conexões diretas e indiretas
* Calcular a menor distância entre dois elementos
* Suportar remoção de conexões (`disconnect`) de forma simples

---

## ⚙️ Funcionalidades

A classe `Network` possui os seguintes métodos:

### 🔗 Connect(int a, int b)

Conecta dois elementos.

### ❌ Disconnect(int a, int b)

Remove a conexão entre dois elementos.

### 🔍 Query(int a, int b)

Retorna `true` se os elementos estiverem conectados (direta ou indiretamente), caso contrário `false`.

### 📏 LevelConnection(int a, int b)

Retorna:

* `0` → se não estão conectados
* `1` → se estão diretamente conectados
* `2+` → se estão conectados indiretamente (nível de distância)

---

## 🛡️ Validações

* O construtor exige um número inteiro positivo.
* Os métodos validam se os elementos estão dentro do intervalo permitido.
* Conexões duplicadas são evitadas automaticamente com `HashSet`.
* Auto-conexões são ignoradas.

---

## 🧪 Exemplo de uso

```csharp
var net = new Network(8);

net.Connect(1, 2);
net.Connect(2, 6);
net.Connect(2, 4);
net.Connect(5, 8);

Console.WriteLine(net.Query(1, 6)); // true
Console.WriteLine(net.Query(7, 4)); // false
Console.WriteLine(net.LevelConnection(1, 4)); // 2
Console.WriteLine(net.LevelConnection(5, 6)); // 0
```

---

## 🚀 Como executar

1. Certifique-se de ter o .NET instalado
2. Clone o repositório:

```bash
git clone <seu-repositorio>
cd <seu-repositorio>
```

3. Execute o projeto:

```bash
dotnet run
```

>> Observação: não é necessário um programa de console para utilização da classe, conforme especificado no teste.
