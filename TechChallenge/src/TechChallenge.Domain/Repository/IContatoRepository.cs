using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Enum;
using TechChallenge.Domain.ValueObjects;
using TechChallenge.SharedKernel.Data;

namespace TechChallenge.Domain.Repository
{
    /// <summary>
    /// Repository com os metodos para camada de acesso a dados referente a contato
    /// </summary>
    public interface IContatoRepository : IBaseRepository<Contato>
    {
        /// <summary>
        /// Cadastra um novo contato no banco de dados
        /// </summary>
        /// <param name="contato">Contato que deve ser cadastrado</param>
        void Cadastrar(Contato contato);

        /// <summary>
        /// ATualiza um contato no banco de dados
        /// </summary>
        /// <param name="contato">Contato que deve ser atualizado</param>
        void Atualizar(Contato contato);

        /// <summary>
        /// Busca um contato por id
        /// </summary>
        /// <param name="contatoId">Id do contato que está sendo buscado</param>
        /// <returns></returns>
        Task<Contato?> BuscarPorId(Guid contatoId);

        /// <summary>
        /// Busca contato por Estado
        /// </summary>
        /// <param name="estado">Estado que servira de filtro</param>
        /// <returns></returns>
        Task<IEnumerable<Contato>> BuscarPorEstado(Estado estado);

        /// <summary>
        /// Busca contato por DDD
        /// </summary>
        /// <param name="ddd">DDD que servira de filtro</param>
        /// <returns></returns>
        Task<IEnumerable<Contato>> BuscarPorDDD(int ddd);

        /// <summary>
        /// Busca contato por Regiao (Leva em consideracao Estado e DDD)
        /// </summary>
        /// <param name="regiao">Regiao que servira de filtro</param>
        /// <returns></returns>
        Task<IEnumerable<Contato>> BuscarPorRegiao(Regiao regiao);

        /// <summary>
        /// Lista os contatos que estão salvos
        /// </summary>
        /// <returns>Lista de todos os contatos cadastrados</returns>
        Task<IEnumerable<Contato>> Listar();

        /// <summary>
        /// Exclui um contato no banco de dados
        /// </summary>
        /// <param name="contato">Contato que deve ser excluido</param>
        void Excluir(Contato contato);
    }
}
