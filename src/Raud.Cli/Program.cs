﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Raud.Core.Features.FileSystem;
using Raud.Core.Extensions;
using System.IO;
using Raud.Core.Features.Generator;
using Raud.Core.Features.Markdown;

namespace Raud.Cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Raud Generator -- Static Site Build");

            var inputArg = args.ElementAtOrDefault(0) ?? ".";
            var outputArg = args.ElementAtOrDefault(1) ?? Path.Combine(inputArg, "output");

            var inputPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, inputArg));
            var outputPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, outputArg));

            Console.WriteLine("Input Directory: " + inputPath);
            Console.WriteLine("Output Directory: " + outputPath);

            var fileSystem = new DiskFileSystem();

            var generator = new RaudGenerator(fileSystem, inputPath, outputPath);
            generator.AddProcessor(new MarkdownFileProcessor(fileSystem));

            await generator.Generate();
        }
    }
}
