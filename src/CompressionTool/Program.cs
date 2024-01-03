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

    var fileContent = File.ReadAllText(inputFileName);

    File.WriteAllText(outputFileName, HuffmanEncoding.Encode(fileContent));

    Console.WriteLine($"Saved in file: {outputFileName}");
});