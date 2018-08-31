using Demo.Domain.Interface;
using Demo.Domain.Interface.Service;

namespace Demo.Domain.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) {
            _produtoRepository = produtoRepository;
        }
    }
}
