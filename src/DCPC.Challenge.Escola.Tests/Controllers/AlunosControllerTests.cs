using DCPC.Challenge.Escola.Api.Controllers;
using DCPC.Challenge.Escola.Api.Data;
using DCPC.Challenge.Escola.Api.Data.Repositories;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using Moq.AutoMock;

namespace DCPC.Challenge.Escola.Tests.Controllers
{
    public class AlunosControllerTests
    {
        private readonly AlunosController _service;
        private readonly IAlunoRepository _repository;
        private readonly ApplicationDbContext _context;
        private AutoMocker _mocker;
        public AlunosControllerTests() 
        {
            _mocker = new AutoMocker();

            _context = _mocker.CreateInstance<ApplicationDbContext>();
            _repository = _mocker.CreateInstance<AlunoRepository>();
            _service = new AlunosController(_repository, _context);
        }

        [Fact(DisplayName = "#01 - Get Alunos Controller")]
        [Trait("Category", "Success")]
        public async Task GetAll_ReturnAlunos_Success()
        {
            //Arrange

            //Act
            var result = await _service.GetAll(CancellationToken.None);

            //Assert

        }
    }
}
