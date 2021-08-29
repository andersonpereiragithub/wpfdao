﻿using SalvarArquivoWpf.Models;
using SalvarArquivoWpf.ViewModels;
using System;
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
            txtBoxCadastro.Visibility = Visibility.Visible;
            btnCadastro.Visibility = Visibility.Visible;
        }

        private void sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
