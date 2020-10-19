using AppMvcBasica.Models;
using DevIO.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking().Include(navigationPropertyPath: f => f.Fornecedor)
                .FirstOrDefaultAsync(predicate: p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking().Include(navigationPropertyPath: f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
        }
    }
}
