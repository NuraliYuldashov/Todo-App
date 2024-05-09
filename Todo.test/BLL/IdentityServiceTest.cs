using Application.DTOs.ApplicationUserDtos;
using Application.Interfaces;
using Moq;

namespace Todo.test.BLL;

public class IdentityServiceTest
{
    [Test]
    [TestCaseSource(typeof(MockData),
                    nameof(MockData.RegisterUsers))]
    public void RegisterUser_WhenUserIsNotRegistered_ShoulNotThrowExeption
        (RegisterUser register) 
    {
        var mockService = new Mock<IIdentityService>();
        mockService.Setup(ms => ms.CreateAsync(It.IsAny<RegisterUser>()));
        Assert.DoesNotThrowAsync(()  => mockService.Object.CreateAsync(register));
    }

    //[Test]
    //public void 
}
