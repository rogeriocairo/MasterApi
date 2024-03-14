namespace MasterApi.Infra.Shared
{
    public class Rota
    {
        public required string Origem { get; set; }
        public required string Destino { get; set; }
        public decimal Valor { get; set; }
    }

    public class Grafo
    {
        public Dictionary<string, Dictionary<string, decimal>> vertices = new();

        public void Add_vertex(string name, Dictionary<string, decimal> edges)
        {
            vertices[name] = edges;
        }

        public Tuple<List<string>, decimal> Shortest_path(string start, string finish = "")
        {
            var previous = new Dictionary<string, string>();
            var distances = new Dictionary<string, decimal>();
            var nodes = new List<string>();

            List<string>? path = null;

            foreach (var vertex in vertices)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = decimal.MaxValue;
                }

                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => decimal.Compare(distances[x], distances[y]));

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == finish)
                {
                    path = new List<string>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == decimal.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in vertices[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            return Tuple.Create(path, distances[finish]);
        }
    }
}
