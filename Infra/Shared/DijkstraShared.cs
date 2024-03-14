namespace MasterApi.Infra.Shared
{
    public class DijkstraShared
    {
        private readonly Dictionary<string, Dictionary<string, decimal>> _grafo;

        public DijkstraShared(Dictionary<string, Dictionary<string, decimal>> grafo)
        {
            _grafo = grafo;
        }

        public string ObterRotaMaisBarata(string origem, string destino)
        {
            // Dicionário para armazenar as distâncias mínimas
            var distancias = new Dictionary<string, decimal>();
            // Dicionário para armazenar os vértices visitados
            var visitados = new Dictionary<string, bool>();

            // Inicializa as distâncias
            foreach (var vertice in _grafo.Keys)
            {
                distancias[vertice] = int.MaxValue;
            }

            // Define a distância do vértice de origem como 0
            distancias[origem] = 0;

            // Fila de prioridade para armazenar os vértices a serem visitados
            var filaPrioridade = new PriorityQueue<string, decimal>();
            filaPrioridade.Enqueue(origem, 0);

            while (filaPrioridade.Count > 0)
            {
                // Obter o vértice com menor distância da fila
                var verticeAtual = filaPrioridade.Dequeue();

                // Se o vértice já foi visitado, continue
                if (visitados.ContainsKey(verticeAtual) && visitados[verticeAtual])
                {
                    continue;
                }

                // Marcar o vértice como visitado
                visitados[verticeAtual] = true;

                // Se o vértice atual for o destino, retornar a rota
                if (verticeAtual == destino)
                {
                    return ReconstruirRota(origem, destino, distancias);
                }

                // Relaxar os vértices adjacentes
                foreach (var adjacente in _grafo[verticeAtual].Keys)
                {
                    var novoCusto = distancias[verticeAtual] + _grafo[verticeAtual][adjacente];

                    if (novoCusto < distancias[adjacente])
                    {
                        distancias[adjacente] = novoCusto;
                        filaPrioridade.Enqueue(adjacente, novoCusto);
                    }
                }
            }

            // Rota não encontrada
            return null;
        }

        private string ReconstruirRota(string origem, string destino, Dictionary<string, decimal> distancias)
        {
            var rota = new List<string>();
            var verticeAtual = destino;

            // Reconstruir a rota do destino até a origem
            while (verticeAtual != origem)
            {
                rota.Add(verticeAtual);

                // Encontrar o vértice anterior na rota com menor distância
                var anterior = "";
                var menorDistancia = decimal.MaxValue;

                foreach (var adjacente in _grafo[verticeAtual].Keys)
                {
                    var distanciaAdjacente = distancias[adjacente];

                    if (distanciaAdjacente + _grafo[adjacente][verticeAtual] < menorDistancia)
                    {
                        menorDistancia = distanciaAdjacente + _grafo[adjacente][verticeAtual];
                        anterior = adjacente;
                    }
                }

                verticeAtual = anterior;
            }

            // Adicionar a origem à rota
            rota.Add(origem);

            // Inverter a ordem da rota
            rota.Reverse();

            // Calcular o custo total da rota
            decimal custoTotal = 0;
            for (var i = 0; i < rota.Count - 1; i++)
            {
                custoTotal += _grafo[rota[i]][rota[i + 1]];
            }

            return string.Join(" - ", rota, custoTotal.ToString());
        }

    }
}
