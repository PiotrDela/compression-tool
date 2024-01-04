using CommandLine;

namespace CompressionTool
{
    public class Options
    {
        private const string EncodeSetName = nameof(EncodeSetName);
        private const string DecodeSetName = nameof(DecodeSetName);
        
        [Option('i', "input", Required = true, HelpText = "Input file path.", SetName = EncodeSetName)]
        public string InputFilePath { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output file path.", SetName = EncodeSetName)]
        public string OutputFilePath { get; set; }
    }
}
