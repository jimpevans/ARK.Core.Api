using ADotNet.Clients.Builders;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using System;
using System.IO;

namespace ARK.Core.Infrastructure.Builds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string buildScriptPath = "../../../../.github/workflows/dotnet.yml";
            string directoryPath = Path.GetDirectoryName(buildScriptPath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            GitHubPipelineBuilder.CreateNewPipeline()
                .SetName("ARK Core Api Build")
                .OnPush("master")
                .OnPullRequest("master")
                .AddJob("build", job => job
                    .WithName("Build")
                    .RunsOn(BuildMachines.Windows2022)
                        .AddCheckoutStep("Check out")
                        .AddSetupDotNetStep(version: "9.0.101")
                        .AddRestoreStep()
                        .AddBuildStep()
                        .AddTestStep(
                            command: "dotnet test --no-build --verbosity normal --filter " +
                                     "'FullyQualifiedName!~Integrations'"))
                .SaveToFile(buildScriptPath);

        }
    }
}
