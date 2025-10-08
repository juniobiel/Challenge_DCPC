using DCPC.Challenge.Escola.Api.Controllers;
using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;

namespace DCPC.Challenge.Escola.Tests.Controllers
{
    public class AlunosControllerTests
    {
        private AlunosController _controller;
        private IAlunosService _alunosService;
        private AutoMocker _mocker;

        [Fact(DisplayName = "#01 - Get Alunos Controller Success")]
        [Trait("Category", "Success")]
        public async Task GetAll_ReturnAlunos_Success()
        {
            //Arrange
            var idGerado = Guid.NewGuid();
            var serviceMoq = new Mock<IAlunosService>();
            serviceMoq.Setup(x => x.ListarAsync())
                .ReturnsAsync(new List<Aluno>
                {
                    new Aluno
                    {
                        Nome = "Fulano",
                        Ativo = true,
                        DataNascimento = DateOnly.FromDateTime(DateTime.Now.AddDays(-10220)),
                        Email = "teste@gmail.com",
                        Id = idGerado,
                        Matriculas = new Matricula[] { }
                    }
                })
                .Verifiable();

            _alunosService = serviceMoq.Object;
            _controller = new AlunosController(_alunosService);

            //Act
            var result = await _controller.GetAll();

            //Assert
            Assert.Equal("Fulano", result.Result.As<OkObjectResult>().Value.As<IEnumerable<Aluno>>().FirstOrDefault().Nome);
            Assert.Equal(true, result.Result.As<OkObjectResult>().Value.As<IEnumerable<Aluno>>().FirstOrDefault().Ativo);
            Assert.Equal(DateOnly.FromDateTime(DateTime.Now.AddDays(-10220)), result.Result.As<OkObjectResult>().Value.As<IEnumerable<Aluno>>().FirstOrDefault().DataNascimento);
            Assert.Equal("teste@gmail.com", result.Result.As<OkObjectResult>().Value.As<IEnumerable<Aluno>>().FirstOrDefault().Email);
            Assert.Equal(idGerado, result.Result.As<OkObjectResult>().Value.As<IEnumerable<Aluno>>().FirstOrDefault().Id);
            Assert.Empty(result.Result.As<OkObjectResult>().Value.As<IEnumerable<Aluno>>().FirstOrDefault().Matriculas);

            serviceMoq.Verify(x => x.ListarAsync(), Times.Once);
        }
    }
}
