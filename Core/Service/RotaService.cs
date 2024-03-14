using MasterApi.Core.Entity;
using MasterApi.Core.Interface.Repository;
using MasterApi.Core.Interface.Services;
using MasterApi.Core.Model;
using MasterApi.Infra.Shared;

namespace MasterApi.Core.Service
{
    public class RotaService : IRotaService
    {
        private readonly IRotaRepository _repository;

        public RotaService(IRotaRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(RotaModel _entity)
        {
            var _rota = new RotaEntity(0, _entity.Origem, _entity.Destino, _entity.Valor);
            await _repository.AddAsync(_rota);
        }

        public async Task Delete(int id)
        {
            var _rota = new RotaEntity(id);
            await _repository.DeleteAsync(_rota);
        }

        public async Task<RotaModel?> GetAsync(int id)
        {
            var _rota = await _repository.GetAsync(id);

            if (_rota == null)
            {
                return default;
            }

            return new RotaModel
            {
                Id = _rota.Id,
                Destino = _rota.Destino,
                Origem = _rota.Origem,
                Valor = _rota.Valor
            };
        }

        public async Task Update(RotaModel rota)
        {
            var _rota = new RotaEntity(rota.Id, rota.Origem, rota.Destino, rota.Valor);
            await _repository.UpdateAsync(_rota, rota.Id);
        }

        public async Task<IEnumerable<RotaModel>> GetAllAsync()
        {
            var _rotas = await _repository.GetAllAsync();
            var _entities = new List<RotaModel>();

            foreach (var _rota in _rotas)
            {
                _entities.Add(new RotaModel
                {
                    Id = _rota.Id,
                    Destino = _rota.Destino,
                    Origem = _rota.Origem,
                    Valor = _rota.Valor,
                });
            }

            return _entities;
        }

        public async Task<string> CaminhoMaisEconomicoAsync(RotasDto rotasDto)
        {
            var _rotas = await _repository.GetAllAsync();
            var g = new Grafo();

            foreach (var _rota in _rotas)
            {
                if (!g.vertices.TryGetValue(_rota.Origem, out Dictionary<string, decimal>? value))
                {
                    g.Add_vertex(_rota.Origem, new Dictionary<string, decimal>() { { _rota.Destino, _rota.Valor } });
                }
                else
                {
                    value.Add(_rota.Destino, _rota.Valor);
                }

                // Adicione o destino como um vértice, se ainda não estiver no grafo
                if (!g.vertices.ContainsKey(_rota.Destino))
                {
                    g.Add_vertex(_rota.Destino, new Dictionary<string, decimal>());
                }
            }

            var result = g.Shortest_path(rotasDto.Origem, rotasDto.Destino);
            var rota = string.Join(" - ", result.Item1.Reverse<string>());
            var valorFormatado = result.Item2.ToString("C");
            return ($"A melhor rota é: {rota} ao custo de {valorFormatado}");
        }
    }
}

