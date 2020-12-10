using Nyous.Api.NoSql.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous.Api.NoSql.Interfaces
{
    interface IEventoRepository
    {
        List<EventoDomain> Listar();

        void Adicionar  (EventoDomain evento);

        void Atualizar  (EventoDomain evento, string id);

        void Remover    (string id);

        void BuscarPorId(string id);
    }
}
