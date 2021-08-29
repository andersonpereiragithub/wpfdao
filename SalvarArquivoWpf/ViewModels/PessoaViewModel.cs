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
        }

        private void Notificar(object? resultadoExpressao, [CallerMemberName] string nomePropriedade = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private ICommand comandoCadastrar = null;
        private Pessoa objeto = null;
    }
}
