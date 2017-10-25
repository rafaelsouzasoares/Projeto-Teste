using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using excel = Microsoft.Office.Interop.Excel;


namespace ProgramaTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            excel.Application x1app = new excel.Application();
            //Setando o arquivo de origem
            excel.Workbook x1workbook = x1app.Workbooks.Open(@"C:\Users\Rafael\Desktop\origem de dados.xlsx");
            
            //Pegando todos os valores da primeira pasta de trabalho do excel, onde estão os valores.
            excel.Worksheet x1worksheet = x1workbook.Sheets[1];

            //Pega o conteúdo das linhas da pasta de trabalho do excel
            excel.Range x1range = x1worksheet.UsedRange;

            string nomeUsuario;
            string cpf;
            int linhasArquivo = x1range.Cells.Rows.Count;

            //Começando a contagem da segunda linha, pois a primeira é título de coluna
            for (int i = 2; i <= linhasArquivo; i++)
            {
                //nomeUsuario = (x1range.Cells[i, 1] as excel.Range).Value.ToString();
                //cpf = (x1range.Cells[i, 2] as excel.Range).Value.ToString();
                
            }

            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("https://esgcorpfirm.novajus.com.br");

            driver.Close();

        }
    }
}
