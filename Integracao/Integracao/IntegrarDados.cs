using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;

namespace Integracao
{
    public class IntegrarDados
    {
        IWebDriver driver = new ChromeDriver();
        
        [Test]
        public void integrar()
        {
            //Setando a url de destino
            driver.Navigate().GoToUrl("https://esgcorpfirm.novajus.com.br");

            //Instanciando a classe que esperará por um tempo o carregamento de um elemento setado
            WebDriverWait espera = new WebDriverWait(driver, TimeSpan.FromMinutes(5));

            //Verificando se o elemento já está visivel e habilitado para acessar a tela de login
            espera.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("btn-login-onepass")));

            //Selecionando o modo de login para OnePass
            if (driver.FindElements(By.Id("btn-login-onepass")).Count > 0)
            {
                driver.FindElement(By.Id("btn-login-onepass")).Click();
            }


            //Passando dados de login - Usuário e senha
            if (driver.FindElements(By.Id("Username")).Count > 0)
            {
                driver.FindElement(By.Id("Username")).SendKeys("esgcorpfirm.teste03");
            }

            if (driver.FindElements(By.Id("Password")).Count > 0)
            {
                driver.FindElement(By.Id("Password")).SendKeys("Esg@2017");
            }

            //Aguardando botão de login já está visível e habilitado para uso
            espera.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("SignIn")));

            Thread.Sleep(6000);

            if (driver.FindElements(By.Id("SignIn")).Count > 0)
            {
                driver.FindElement(By.Id("SignIn")).Submit();
            }
            
        }



        //Método responsável por pesquisar os contatos buscados da planilha
        public void Pesquisar(string nomeContato, string cpf)
        {
            //Instanciando a classe que aguardará o carregamento de determinado elemento
            WebDriverWait espera = new WebDriverWait(driver, TimeSpan.FromMinutes(5));

            //Verificando se o elemento já está visivel e habilitado para acessar a tela de de Contatos
            espera.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("menucontatos")));

            if (driver.FindElements(By.LinkText("Contatos")).Count > 0)
            {
                driver.FindElement(By.LinkText("Contatos")).Click();
            }

            espera.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("Search")));

            if (driver.FindElements(By.Id("Search")).Count > 0)
            {
                driver.FindElement(By.Id("Search")).Clear();
                driver.FindElement(By.Id("Search")).SendKeys(cpf);
            }

            if (driver.FindElements(By.ClassName("button")).Count > 0)
            {
                driver.FindElement(By.ClassName("button")).Click();
            }

            Thread.Sleep(10000);

            //Caso essa condição seja satisfeita quer dizer que não encontrou nenhum registro na pesquisa
           if(driver.FindElements(By.ClassName("empty-search-box")).Count > 0 )
            {
                Cadastrar(nomeContato, cpf);               
            }                    

        }


        //Método responsável por inserir os contatos que não existirem
        public void Cadastrar(String nomeContato, string cpf)
        {
            //Instanciando a classe que aguardará o carregamento de determinado elemento
            WebDriverWait espera = new WebDriverWait(driver, TimeSpan.FromSeconds(240));
            
            //Chamar tela de cadastro de contato
            if (driver.FindElements(By.LinkText("Nova pessoa física")).Count > 0)
            {
                driver.FindElement(By.LinkText("Nova pessoa física")).Click();
            }
            Thread.Sleep(6000);

            if (driver.FindElements(By.Id("CPF")).Count > 0)
            {
                driver.FindElement(By.Id("CPF")).SendKeys(cpf);
            }
            
            if (driver.FindElements(By.Id("Nome")).Count > 0)
            {
                driver.FindElement(By.Id("Nome")).SendKeys(nomeContato);
            }

            if (driver.FindElements(By.Name("ButtonSave")).Count > 0)
            {
                driver.FindElement(By.Name("ButtonSave")).Click();
            }

            //Aguardando mensagem de contato incluído com sucesso para continuar
            espera.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("top-message")));                        
        }


        public void Finalizar()
        {
            driver.Close();
        }
    }
}
