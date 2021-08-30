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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cvsCadastro.Visibility = Visibility.Visible;
        }

        private void sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            cvsCadastro.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cvsCadastro.Visibility = Visibility.Hidden;
        }

        private void ListaPessoas_Click(object sender, RoutedEventArgs e)
        {
            Pessoa p = new Pessoa();
            var lista = p.ObterTodos();

            PessoasView.Visibility = Visibility.Visible;
        }
    }
}
