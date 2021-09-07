using FluentAssertions;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("a","a")]
        [InlineData("bb","b")]
        public void WhenInvalidInput_Validator_ShouldBeReturnErrors(string name,string surname)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            UpdateAuthorModel model = new UpdateAuthorModel() { Name = name,Surname=surname,BirthDate=System.DateTime.Now.AddYears(-2) };
            command.Model = model;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
