using MongoDB.Driver;
using Nyous.Api.NoSql.Context;
using Nyous.Api.NoSql.Domains;
using Nyous.Api.NoSql.Interfaces;
using System;
using System.Collections.Generic;

namespace Nyous.Api.NoSql.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly IMongoCollection<EventoDomain> _eventos;

        public EventoRepository(INyousDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _eventos = database.GetCollection<EventoDomain>(settings.EventosCollectionName);
        }


        public void Adicionar(EventoDomain evento)
        {
            try
            {
                _eventos.InsertOne(evento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(EventoDomain evento, string id)
        {
            try
            {
                _eventos.ReplaceOne(c => c.Id == id, evento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EventoDomain> Listar()
        {
            try
            {
                return _eventos.AsQueryable<EventoDomain>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(string id)
        {
            try
            {
                _eventos.DeleteOne(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
