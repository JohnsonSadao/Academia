using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoRosangela.Domain.Caracteristicas.Excecoes;
using ProjetoRosangela.Domain.Caracteristicas.Livros;

namespace ProjetoRosangela.Aplicacao.Caracteristicas.Livros
{
    public class LivroService : ILivroService
    {
        public ILivroRepository _repository;

        public LivroService(ILivroRepository repository)
        {
            _repository = repository;
        }

        public Livro Atualizar(Livro livro)
        {
            if (livro.Id < 1)
                throw new IdentificadorIndefinidoException();
            livro.Validar();
            return _repository.Atualizar(livro); 

        }

        public void Deletar(Livro livro)
        {
            if (livro.Id < 1)
                throw new IdentificadorIndefinidoException();
            _repository.Delete(livro);
        }

        public Livro Obter(long id)
        {
            if (id < 0)
                throw new IdentificadorIndefinidoException();
            return _repository.Obter(id);
        }

        public IEnumerable<Livro> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public Livro Salvar(Livro livro)
        {
            livro.Validar();
            return _repository.Salvar(livro);
        }
    }
}
