using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Enum;
using TechChallenge.Domain.Repository;
using TechChallenge.Domain.ValueObjects;
using TechChallenge.SharedKernel.Data;

namespace TechChallenge.Infrastructure.Data.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        public IUnitOfWork UnitOfWork => _context;

        public ContatoRepository(TechChallengeDbContext context)
        {
            _context = context;
        }

        private readonly TechChallengeDbContext _context;

        public void Atualizar(Contato contato) => _context.Contatos.Update(contato);


        public async Task<Contato?> BuscarPorId(Guid contatoId) =>
            await _context.Contatos.FirstOrDefaultAsync(contato => Equals(contato.Id, contatoId));

        public void Cadastrar(Contato contato) => _context.Contatos.Add(contato);

        public void Excluir(Contato contato) => _context.Contatos.Remove(contato);

        public async Task<IEnumerable<Contato>> Listar() => await _context.Contatos.ToListAsync();

        public async Task<IEnumerable<Contato>> BuscarPorEstado(Estado estado)
        {
            return await _context.Contatos
                .Where(contato => contato.Regiao.Estado == estado)
                .ToListAsync();
        }

        public async Task<IEnumerable<Contato>> BuscarPorDDD(int ddd)
        {
            return await _context.Contatos
                .Where(contato => contato.Regiao.DDD == ddd)
                .ToListAsync();
        }

        public async Task<IEnumerable<Contato>> BuscarPorRegiao(Regiao regiao)
        {
            return await _context.Contatos
                .Where(contato =>
                    contato.Regiao.Estado == regiao.Estado &&
                    contato.Regiao.DDD == regiao.DDD
                )
                .ToListAsync();
        }

        public void Dispose() => _context.Dispose();
    }
}
