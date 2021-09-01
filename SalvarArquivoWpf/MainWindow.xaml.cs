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
            InitializeComponent();
            this.DataContext = new PessoaViewModel(new Pessoa());
        }

        private void Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            cvsCadastro.Visibility = Visibility.Visible;
        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            cvsCadastro.Visibility = Visibility.Hidden;

            ListaPessoas_Click(sender, e);
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
            if(PessoasView.Visibility == Visibility.Visible)
            {
                PessoasView.Visibility = Visibility.Hidden;
            }
            Pessoa p = new Pessoa();
            PessoasView.ItemsSource = p.OrdenarPorNome();

            PessoasView.Visibility = Visibility.Visible;
        }
    }
}
