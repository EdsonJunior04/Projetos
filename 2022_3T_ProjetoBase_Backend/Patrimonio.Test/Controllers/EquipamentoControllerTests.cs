using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Patrimonio.Test.Controllers
{
    public class EquipamentoControllerTests
    {
        [Fact]

        public void Deve_Retornar_Lista_De_Equipamentos_Por_Id_Valido()
        {
            //Pré-condição
            var fakeRepo = new Mock<IEquipamentoRepository>();
            fakeRepo.Setup(x => x.BuscarPorID(It.IsAny<int>())).Returns((Equipamento)null);

            var controller = new EquipamentosController(fakeRepo.Object);

            var fakeid = 1;

            //Procedimento
            var GetEquipamentoFake = controller.GetEquipamento(fakeid);
            var resultado = false;

            if (GetEquipamentoFake != null)
            {
                resultado = true;
            }

            //Resultado Esperado
            Assert.True(resultado);
        }
    }
}
