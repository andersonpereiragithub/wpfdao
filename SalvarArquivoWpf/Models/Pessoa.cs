using SalvarArquivoWpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SalvarArquivoWpf.Models
{
    class Pessoa
    {
        ObservableCollection<Pessoa> listaPessoas = new ObservableCollection<Pessoa>();
        public ObservableCollection<Pessoa> ObterTodos()
        {
            var path = @"D:\ADS_CURSO\OTTO\3o Periodo\ManipularArquivos\ManipularArquivos\BDpessoas.txt";

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        Pessoa p = new Pessoa();

                        var linha = sr.ReadLine();
                        string[] dado = linha.Split(";");
                        p.Nome = dado[0];
                        p.idade = Convert.ToInt32(dado[1]);

                        listaPessoas.Add(p);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao ler o arquivo!", "Lista", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return listaPessoas;
        }
        public ObservableCollection<Pessoa> OrdenarPorNome()
        {
            var path = @"D:\ADS_CURSO\OTTO\3o Periodo\ManipularArquivos\ManipularArquivos\BDpessoas.txt";

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        Pessoa p = new Pessoa();

                        var linha = sr.ReadLine();
                        string[] dado = linha.Split(";");
                        p.Nome = dado[0];
                        p.idade = Convert.ToInt32(dado[1]);

                        listaPessoas.Add(p);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao ler o arquivo!", "Lista", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            //ObservableCollection<Pessoa> pessoasOrdenadas = (ObservableCollection<Pessoa>)listaPessoas.OrderBy(p => p.Nome);
            return pessoasOrdenadas;
        }
        public string Nome { get => nome; set => nome = value; }

        public int Idade
        {
            get => idade;
            set
            {
                if (value < 0 || value > 150)
                    throw new Exception("A idade deve estar entre 0 e 150");

                idade = value;
            }
        }
        public void Cadastrar()
        {
            var path = @"D:\ADS_CURSO\OTTO\3o Periodo\ManipularArquivos\ManipularArquivos\BDpessoas.txt";

            Pessoa p = new Pessoa();

            p.Nome = Nome;
            p.Idade = Idade;
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"{p.Nome};{p.Idade}");
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Erro");
            }
            finally
            {
                MessageBox.Show("Pessoa cadastrada com sucesso!", "Cadastro", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private string nome;
        private int idade;
    }
}
