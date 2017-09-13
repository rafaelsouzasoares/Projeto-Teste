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

namespace ProgramaTeste
{
    class Program
    {
        static void Main(string[] args)
        {

            excel.Application x1app = new excel.Application();

            excel.Workbook x1workbook = x1app.Workbooks.Open(@"C:\Users\Rafael\Desktop\origem de dados.xlsx");

            //Pegando a pasta de trabalho do excel onde estão os dados
            excel.Worksheet x1worksheet = x1workbook.Sheets[1];

            //Obtendo o valor das linhas do arquivo
            excel.Range x1range = x1worksheet.UsedRange;

            int numLinhas = x1range.Cells.Rows.Count;
            String nomeUsuario;
            String cpf;

            //Iniciando processo de passagem de dados para integração
            Integracao.IntegrarDados integracao = new Integracao.IntegrarDados();

            integracao.integrar();

            for (int i = 2000; i <= numLinhas; i++)
            {
                nomeUsuario = (x1range.Cells[i, 1] as excel.Range).Value.ToString();
                cpf = (x1range.Cells[i, 2] as excel.Range).Value.ToString();

                integracao.Pesquisar(nomeUsuario, cpf);
            }
            //Finalizando ChromeWebDrive
            integracao.Finalizar();


            Console.WriteLine("Processo finalizado!");
            Environment.Exit(0);

                        
        }
    }
}
