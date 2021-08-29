using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManipularArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            //File.WriteAllText(@"D:\ADS_CURSO\OTTO\3o Periodo\ManipularArquivos\ManipularArquivos\teste.txt", "Teste\nde\ngravação");

            var prod1 = new Produto() { Codigo = 1, Descricao = "Teste 1", Preco = 1.11 };
            var prod2 = new Produto() { Codigo = 2, Descricao = "Teste 2", Preco = 2.11 };
            var prod3 = new Produto() { Codigo = 3, Descricao = "Teste 3", Preco = 3.11 };
            var listaProdutos = new List<Produto> { prod1, prod2, prod3 };

            Persistir(@"D:\ADS_CURSO\OTTO\3o Periodo\ManipularArquivos\ManipularArquivos\teste.txt", listaProdutos);
            
         }
        static void Persistir<T>(string caminho, List<T> lista)
        {
            using (var stream = new StreamWriter(caminho, false, Encoding.UTF8))
            {
                var tipo = typeof(T);

                if (lista != null && lista.Count > 0)
                {
                    var primeiroObjeto = lista[0];
                    var separador = "";

                    foreach (var prop in primeiroObjeto.GetType().GetProperties())
                    {
                        stream.Write(separador + prop.Name);
                        separador = ";";
                    }
                    
                    foreach (var obj in lista)
                    {
                        separador = "";
                        foreach (var prop in tipo.GetProperties())
                        {
                            stream.Write(separador + prop.Name);
                            separador = ";";
                        }
                    }
                }
            }
        }
    }
}
