using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EventHorizon.Blazor.TypeScript.Interop.Generator.Model.Writer;
using FluentAssertions;
using Moq;
using Xunit;

namespace EventHorizon.Blazor.TypeScript.Interop.Generator.Tests.GenerateClassStatementStringTests
{
    public class ActualStringGenerationTest
    {
        [Fact]
        [Trait("Category", "Multiple Generation")]
        public void ShouldGenerateSourceForEverythingDefinition()
        {
            // Given
            var projectAssembly = "ProjectAssembly";
            var sourceDirectory = "";
            var sourceFileName = "MultipleGeneration.d.ts";
            var sourceFile = Path.Combine(
                ".",
                "SourceFiles",
                sourceFileName
            );
            var sourceFiles = new List<string>
            {
                sourceFile
            };
            var generationList = new List<string>
            {
                "Mesh",
                "Mesh",
                "Engine",
                "Vector3",
            };
            var typeOverrideMap = new Dictionary<string, string>();

            var writerMock = new Mock<IWriter>();

            // When
            var generateSource = new GenerateSource();
            var actual = generateSource.Run(
                projectAssembly,
                sourceDirectory,
                sourceFiles,
                generationList,
                writerMock.Object,
                typeOverrideMap
            );


            // Then
            actual.Should().BeTrue();
        }
    }
}