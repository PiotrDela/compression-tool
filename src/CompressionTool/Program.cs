// See https://aka.ms/new-console-template for more information
using CommandLine;
using CompressionTool;

var options = Parser.Default.ParseArguments<Options>(args).WithParsed(options => {

    if (File.Exists(options.InputFilePath) == false)
    {
        throw new FileNotFoundException("File not found", options.InputFilePath);
    }

    var inputFileName = options.InputFilePath;
    var outputFileName = options.OutputFilePath;

    using (var fileStream = File.OpenWrite(outputFileName))
    {
        fileStream.Seek(0, SeekOrigin.Begin);
        HuffmanEncoding.Encode(File.ReadAllText(inputFileName), fileStream);
    }

    Console.WriteLine($"Saved in file: {outputFileName}");
});