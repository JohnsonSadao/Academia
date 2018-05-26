using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoRosangela.Domain.Caracteristicas.Emprestimos;
using ProjetoRosangela.Domain.Caracteristicas.Excecoes;

namespace ProjetoRosangela.Aplicacao.Caracteristicas.Emprestimos
{
    public class EmprestimoService : IEmprestimoService
    {
        public IEmprestimoRepository _repository;

        public EmprestimoService(IEmprestimoRepository repository)
        {
            _repository = repository;
        }

        public Emprestimo Atualizar(Emprestimo emprestimo)
        {
            if (emprestimo.Id < 1)
                throw new IdentificadorIndefinidoException();
            emprestimo.Validar();
            return _repository.Atualizar(emprestimo);
        }

        public void Deletar(Emprestimo emprestimo)
        {
            if (emprestimo.Id < 1)
                throw new IdentificadorIndefinidoException();
            _repository.Delete(emprestimo);
        }

        public Emprestimo Obter(long id)
        {
            if (id < 1)
                throw new IdentificadorIndefinidoException();
            return _repository.Obter(id);
        }

        public IEnumerable<Emprestimo> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public Emprestimo Salvar(Emprestimo emprestimo)
        {
            emprestimo.Validar();
            return _repository.Salvar(emprestimo);
        }
    }
}
