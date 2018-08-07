using System.Collections.Generic;

namespace IronBeard.Core.Features.FileSystem
{
    public class OutputFile : InputFile
    {
        public string Content { get; set; }
        public InputFile Input { get; set; }
        public bool DirectCopy { get; set; }
        public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();

        public static OutputFile FromInputFile(InputFile file){
            return new OutputFile()
            {
                Name = file.Name,
                Extension = file.Extension,
                RelativeDirectory = file.RelativeDirectory,
                BaseDirectory = file.BaseDirectory,
                Input = file
            };
        }
    }
}