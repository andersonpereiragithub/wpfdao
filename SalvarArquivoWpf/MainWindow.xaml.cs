using SalvarArquivoWpf.Models;
using SalvarArquivoWpf.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace SalvarArquivoWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            this.DataContext = new PessoaViewModel(new Pessoa());
            InitializeComponent();
        }

        private void Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Clear();
            txtIdade.Clear();
            cvsCadastro.Visibility = Visibility.Visible;
        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Pessoa p = new Pessoa();
            cvsCadastro.Visibility = Visibility.Hidden;
            
        }

        private void CancelarCadastro_Click(object sender, RoutedEventArgs e)
        {
            cvsCadastro.Visibility = Visibility.Hidden;
        }

        private void ListaPessoas_Click(object sender, RoutedEventArgs e)
        {
            Pessoa p = new Pessoa(); 
            PessoasView.ItemsSource = p.ObterTodos();

            PessoasView.Visibility = Visibility.Visible;
        }

        private void OrdenaPorNome_Click(object sender, RoutedEventArgs e)
        {
            if (PessoasView.Visibility == Visibility.Visible)
            {
                PessoasView.Visibility = Visibility.Hidden;
            }
            Pessoa p = new Pessoa();
            PessoasView.ItemsSource = p.OrdenarPorNome();

            PessoasView.Visibility = Visibility.Visible;
        }
        private void OrdenaPorIdade_Click(object sender, RoutedEventArgs e)
        {
            if (PessoasView.Visibility == Visibility.Visible)
            {
                PessoasView.Visibility = Visibility.Hidden;
            }
            Pessoa p = new Pessoa();
            PessoasView.ItemsSource = p.OrdenarPorIdade();

            PessoasView.Visibility = Visibility.Visible;
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Clear();
            txtIdade.Clear();
            cvsCadastro.Visibility = Visibility.Visible;
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Pessoa p = new Pessoa();

            p.Nome = txtNome.Text;
            p.Idade = Convert.ToInt32(txtIdade.Text);

            p.Deletar(p);
            
            txtNome.Clear();
            txtIdade.Clear();
            cvsCadastro.Visibility = Visibility.Hidden;
            
        }
    }
}
