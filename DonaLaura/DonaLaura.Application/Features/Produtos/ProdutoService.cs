using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonaLaura.Domain.Exceptions.Comum;
using DonaLaura.Domain.Modelo;
using DonaLaura.Infra.Data.Produtos;

namespace DonaLaura.Application.Features.Produtos
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public void Delete(Produto produto)
        {
            _repository.Delete(produto);
        }

        public Produto Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();
            return _repository.Get(id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return _repository.GetAll();
        }

        public bool RegisterWithDependency(int id)
        {
            throw new NotImplementedException();
        }

        public Produto Save(Produto produto)
        {
            produto.Validate();
            return _repository.Save(produto);
        }

        public Produto Update(Produto produto)
        {
            if (produto.Id < 1)
                throw new IdentifierUndefinedException();
            produto.Validate();
            return _repository.Update(produto);
        }
    }
}
