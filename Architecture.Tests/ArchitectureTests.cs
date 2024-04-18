using FluentAssertions;
using NetArchTest.Rules;

namespace Architecture.Tests
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "Domain";
        private const string ApplicationNamespace = "Application";
        private const string InfrastructureNamespace = "Infrastructure";
        private const string PresentationNamespace = "Presentation";
        private const string WebApiNamespace = "WebApi";

        [Test]
        public void Domain_Should_Not_HaveDependencyOnOtherProject()
        {
            var assembly = typeof(Domain.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                ApplicationNamespace,
                InfrastructureNamespace,
                PresentationNamespace,
                WebApiNamespace
            };

            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void Application_Should_Not_HaveDependencyOnOtherProject()
        {
            var assembly = typeof(Application.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                InfrastructureNamespace,
                PresentationNamespace,
                WebApiNamespace
            };
 
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void Handlers_Should_Have_DependencyOnDomain()
        {
            //Arange
            var assembly = typeof(Application.AssemblyReference).Assembly;

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Handler")
                .Should()
                .HaveDependencyOn(DomainNamespace)
                .GetResult();

            //Assert
            testResult.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void Infrastructure_Should_Not_HaveDependencyOnOtherProject()
        {
            var assembly = typeof(Infrastructure.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                ApplicationNamespace,
                PresentationNamespace,
                WebApiNamespace
            };

            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void Presentation_Should_Not_HaveDependencyOnOtherProject()
        {
            var assembly = typeof(Presentation.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                InfrastructureNamespace,
                WebApiNamespace
            };

            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void Controllers_Should_Have_DependencyOnMediatR()
        {
            //Arange
            var assembly = typeof(Presentation.AssemblyReference).Assembly;

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Controller")
                .Should()
                .HaveDependencyOn("MediatR")
                .GetResult();

            //Assert
            testResult.IsSuccessful.Should().BeTrue();
        }
    }
}
