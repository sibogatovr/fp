﻿using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TagsCloudContainer.TagsCloud;
using TagsCloudContainer.Utility;

namespace TagsCloudContainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                    .WithParsed(options =>
                    {
                        using (var serviceProvider = Startup.ConfigureServices())
                        {
                            var tagCloudApp = serviceProvider.GetRequiredService<TagCloudApp>();
                            tagCloudApp.Run(options);
                        }
                    });
        }
    }
}
