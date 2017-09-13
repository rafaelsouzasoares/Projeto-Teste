using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using excel = Microsoft.Office.Interop.Excel;
using OpenQA.Selenium.Support.UI;
using Integracao;
using System.IO;

namespace ProgramaTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            //Obtendo o caminho onde a aplicação está sendo executada
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;

            //Obtendo o caminho do arquivo com a fonte de dados
            string arquivo = Path.Combine(startupPath, "origem de dados.xlsx");

            String nomeUsuario;
            String cpf;

            excel.Application x1app = new excel.Application();

            //Atribuindo o arquivo xls de onde buscaremos os dados
            excel.Workbook arquivoTrabalho = x1app.Workbooks.Open(arquivo);

            //Pegando a pasta de trabalho(Aba) do excel onde estão os dados
            excel.Worksheet abaTrabalho = arquivoTrabalho.Sheets[1];

            //Obtendo o valor das células preenchidas do arquivo
            excel.Range celulas = abaTrabalho.UsedRange;
            
            //Número de linhas utilizadas no arquivo
            int numLinhas = celulas.Cells.Rows.Count;
            

            //Iniciando processo de passagem de dados para integração
            Integracao.IntegrarDados integracao = new Integracao.IntegrarDados();

            integracao.integrar();

            for (int i = 2000; i <= numLinhas; i++)
            {
                nomeUsuario = (celulas.Cells[i, 1] as excel.Range).Value.ToString();
                cpf = (celulas.Cells[i, 2] as excel.Range).Value.ToString();

                integracao.Pesquisar(nomeUsuario, cpf);
            }

            //Finalizando ChromeWebDrive
            integracao.Finalizar();
            arquivoTrabalho.Close(0);
            x1app.Quit();            

            Console.Clear();
            Console.WriteLine("----------Processo finalizado!------------");
            Environment.Exit(0);
                        
        }
    }
}
