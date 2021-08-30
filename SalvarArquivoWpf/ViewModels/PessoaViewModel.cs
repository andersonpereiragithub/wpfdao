using SalvarArquivoWpf.Models;
using SalvarArquivoWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SalvarArquivoWpf.ViewModels
{
    class PessoaViewModel : INotifyPropertyChanged
    {
        public PessoaViewModel(Pessoa pessoa) => objeto = pessoa;

        public string Nome { get => objeto.Nome; set => Notificar(objeto.Nome = value); }
        public int Idade { get => objeto.Idade; set => Notificar(objeto.Idade = value); }

        public ICommand Cadastrar
        {
            get
            {
                if (comandoCadastrar == null)
                    comandoCadastrar = new MeuComando(ComandoCadastrar);

                return comandoCadastrar;
            }
        }

        public void ComandoCadastrar()
        {
            objeto.Cadastrar();
            Notificar(null, "Nome");
            Notificar(null, "Idade");
        }
        public ICommand ObterTodos
        {
            get
            {
                if (comandoObterTodos == null)
                    comandoObterTodos = new MeuComando(ComandoObterTodos);

                return comandoObterTodos;
            }
        }

        public void ComandoObterTodos()
        {
            objeto.ObterTodos();
            Notificar(null, "Nome");
            Notificar(null, "Idade");
        }
        public ICommand OrdenarPorNome
        {
            get
            {
                if (comandoOrdenarPorNome == null)
                    comandoOrdenarPorNome = new MeuComando(ComandoOrdenarPorNome);

                return comandoOrdenarPorNome;
            }
        }

        public void ComandoOrdenarPorNome()
        {
            objeto.OrdenarPorNome();
            Notificar(null, "Nome");
            Notificar(null, "Idade");
        }

        private void Notificar(object? resultadoExpressao, [CallerMemberName] string nomePropriedade = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private ICommand comandoOrdenarPorNome = null;
        private ICommand comandoObterTodos = null;
        private ICommand comandoCadastrar = null;
        private Pessoa objeto = null;
    }
}
