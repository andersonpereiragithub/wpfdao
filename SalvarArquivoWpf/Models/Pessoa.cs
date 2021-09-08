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

                        string[] linha = sr.ReadLine().Split(";");
                        string nome = linha[0];
                        int idade = Convert.ToInt32(linha[1]);

                        listaPessoas.Add(new Pessoa { Nome = nome, Idade = idade });
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
            ObservableCollection<Pessoa> lista = ObterTodos();
            listaPessoas = new ObservableCollection<Pessoa>(lista.OrderBy(i => i.Nome));

            return listaPessoas;
        }
        public ObservableCollection<Pessoa> OrdenarPorIdade()
        {
            ObservableCollection<Pessoa> lista = ObterTodos();
            listaPessoas = new ObservableCollection<Pessoa>(lista.OrderBy(i => i.Idade));

            return listaPessoas;
        }
        public void Deletar(Pessoa p)
        {
            ObservableCollection<Pessoa> lista = ObterTodos();
            ObservableCollection<Pessoa> newLista = new ObservableCollection<Pessoa>();
            foreach (var item in lista)
            {
                if (item.Nome != p.Nome)
                {
                    newLista.Add(item);
                }
            }
            SalvarNovaLista(newLista);
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
        public void SalvarNovaLista(ObservableCollection<Pessoa> novaLista)
        {
            var path = @"D:\ADS_CURSO\OTTO\3o Periodo\ManipularArquivos\ManipularArquivos\BDpessoas.txt";
            var backup = @$"D:\ADS_CURSO\OTTO\3o Periodo\ManipularArquivos\ManipularArquivos\BDpessoas_Backup_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".txt";

            try
            {
                if (File.Exists(path))
                {
                    File.Move(path, backup);
                }
                else
                {
                    File.Create(path);
                }

                using (StreamWriter sw = File.AppendText(path))
                {
                    foreach (var p in novaLista)
                    {
                        sw.WriteLine($"{p.Nome};{p.Idade}");
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Erro");
            }
            finally
            {
                MessageBox.Show("Pessoa DELETADA com sucesso!", "Deletada", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }
        public override int GetHashCode()
        {
            return Nome.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (!(obj is Pessoa))
            {
                return false;
            }
            Pessoa outro = obj as Pessoa;

            return Nome.Equals(outro.Nome);
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
        
        private string nome;
        private int idade;
    }
}
