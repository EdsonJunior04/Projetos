using Patrimonio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Patrimonio.Test.Utils
{
    public class CriptografiaTests
    {
        [Fact] //Descricao
        public void Deve_Retornar_Hash_Em_BCrypt()
        {
            //Pré-condição / Arrange
            var senha = Criptografia.GerarHash("123456789");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");


            //Procedimento / Act
            var retorno = regex.IsMatch(senha);

            //Resultado esperado / Assert
            Assert.True(retorno);
        }

        [Fact]
        public void Deve_retornar_Comparacao_Valida()
        {
            // Pré-condição
            var senha = "123456789";
            var hashBanco = "$2a$11$i6RX43YtbLYxj8bu34ppMOTs3eVjL27jRoqVrFjKbttKPsnSCdWke";

            // Procedimento
            var comparacao = Criptografia.Comparar(senha, hashBanco);

            //Resultado esperado
            Assert.True(comparacao);
        }
    }
}
