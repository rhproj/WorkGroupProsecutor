using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Server.Controllers;
using WorkGroupProsecutor.Server.Data.Repositories;
using WorkGroupProsecutor.Shared.Models.Participants;
using WorkGroupProsecutor.Tests.Services;

namespace WorkGroupProsecutor.Tests.ControllersTests
{
    public class DepartmentControllerTests
    {
        private DepartmentController _departmentController;
        private Mock<IDepartmentRepository> _departmentRepositoryMock;

        public DepartmentControllerTests()
        {
            _departmentRepositoryMock = new Mock<IDepartmentRepository>();
            _departmentRepositoryMock.Setup(m => m.GetAllDepartments()).ReturnsAsync(GetTestGeneratedDepartments());
            _departmentController = new DepartmentController(_departmentRepositoryMock.Object);
        }

        [Fact]
        public async Task Get_ShouldCall_GetAllDepartments()
        {
            await _departmentController.Get();
            _departmentRepositoryMock.Verify(m=>m.GetAllDepartments(), Times.AtLeastOnce);
        }

        [Fact]
        public async Task GetById_ShouldReturn_OkObjectResult()
        {
            var okObjectresult = await _departmentController.Get(It.IsAny<int>());
            Assert.IsType<OkObjectResult>(okObjectresult);
        }

        [Fact]
        public async Task Get_ShouldReturn_ModelType_IEnumerableOfDepartment()
        {
            var actionResutl = await _departmentController.Get();
            var okObjectresult = Assert.IsType<OkObjectResult>(actionResutl);
            Assert.IsAssignableFrom<IEnumerable<Department>>(okObjectresult.Value);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(55)]
        public async Task Get_ShouldPass_GivenNumberOf_DepartmentObjects(int generatedCount)
        {
            _departmentRepositoryMock.Setup(m => m.GetAllDepartments()).ReturnsAsync(GetTestGeneratedDepartments(generatedCount));
            _departmentController = new DepartmentController(_departmentRepositoryMock.Object);

            var actionResutl = await _departmentController.Get();
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResutl).Value;
            var resultCollection = Assert.IsAssignableFrom<IEnumerable<Department>>(okObjectResult);

            Assert.Equal(generatedCount, resultCollection.Count());
        }

        [Fact]
        public async Task Get_ShouldPass_ExpectedCollection()
        {
            //Arrange
            var Id1 = GetRandom.Id();
            var Id2 = GetRandom.Id();
            var DepartmentIndex1 = GetRandom.String();
            var DepartmentIndex2 = GetRandom.String();
            var DepartmentName1 = GetRandom.String();
            var DepartmentName2 = GetRandom.String();

            var department1 = new Department { Id = Id1, DepartmentIndex = DepartmentIndex1, DepartmentName = DepartmentName1 };
            var department2 = new Department { Id = Id2, DepartmentIndex = DepartmentIndex2, DepartmentName = DepartmentName2 };

            var expectedCollection = new Department[] { department1, department2 };

            _departmentRepositoryMock.Setup(m => m.GetAllDepartments()).ReturnsAsync(expectedCollection);
            _departmentController = new DepartmentController(_departmentRepositoryMock.Object);

            //Act
            var actionResutl = await _departmentController.Get();
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResutl).Value;
            var resultCollection = Assert.IsAssignableFrom<IEnumerable<Department>>(okObjectResult);

            //Assert
            Assert.Equal(expectedCollection, resultCollection);
            Assert.Collection(expectedCollection,
                t => { Assert.Equal(Id1, t.Id); Assert.Equal(DepartmentIndex1, t.DepartmentIndex); Assert.Equal(DepartmentName1, t.DepartmentName); },
                t => { Assert.Equal(Id2, t.Id); Assert.Equal(DepartmentIndex2, t.DepartmentIndex); Assert.Equal(DepartmentName2, t.DepartmentName); });
        }

        [Fact]
        public async Task GetById_ShouldReturn_ExpectedDepartment()
        {
            //Arrange
            int testId = 5;
            int arrayIndex = 5;
            int departmensCount = 10;

            var testCollection = GetTestGeneratedDepartments(departmensCount);
            var expectedDepartment = SetIdForElemntOfCollection(testId, arrayIndex, testCollection);

            _departmentRepositoryMock.Setup(m => m.GetDepartmentById(testId)).ReturnsAsync(expectedDepartment);
            _departmentController = new DepartmentController(_departmentRepositoryMock.Object);

            //Act
            var actionResutl = await _departmentController.Get(testId);
            var result = Assert.IsType<OkObjectResult>(actionResutl).Value;

            //Assert
            Assert.Equal(expectedDepartment, result);
        }

        private Department[] GetTestGeneratedDepartments(int count = 1)
        {
            var result = new Department[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = (new Department()
                {
                    Id = GetRandom.Id(),
                    DepartmentIndex = GetRandom.String(),
                    DepartmentName = GetRandom.String()
                });
            }
            return result;
        }

        private Department SetIdForElemntOfCollection(int value, int index, Department[] collection)
        {
            if (index >= collection.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            collection[index].Id = value;
            return collection[index];
        }
    }
}
