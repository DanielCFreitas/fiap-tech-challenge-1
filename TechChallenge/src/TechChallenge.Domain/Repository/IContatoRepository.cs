using TechChallenge.Domain.Entities;
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
