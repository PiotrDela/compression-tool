using CommandLine;

namespace CompressionTool
{
    public class Options
    { 
        [Option('i', "input", Required = true, HelpText = "Input file path.")]
        public string InputFilePath { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output file path.")]
        public string OutputFilePath { get; set; }
    }
}
