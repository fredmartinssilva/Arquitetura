using Demo.Domain.Entities;
using Demo.Domain.Interface;
using Demo.Domain.Interface.Application;
using Demo.Domain.Interface.Service;
using System;
using System.Collections.Generic;

namespace Demo.Application
{
    public class ProdutoApplication : ApplicationBase<Produto>, IProdutoApplication
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        
        public ProdutoApplication(IProdutoService produtoService, IProdutoRepository produtoRepository) : base(produtoService, produtoRepository)
        {
            _produtoService = produtoService;
            _produtoRepository = produtoRepository;
        }
    }
}
