using System;
using System.Net.Mime;

namespace Facade {
    internal class Program {
        static void Main(string[] args) {
            //  Section 4
            //  Client chooses to deal with the facade
            var compiler = new Compiler();
            var bin = compiler.Compile("source.cpp");
        }
    }

    //  Section 1
    //  Constituent, but also independent API
    class Preprocessor {
        public byte[] Process(byte[] source) {
            return source;
        }
    }

    class CodeGenerator {
        public string Generate(byte[] source) {
            return "gen_output";
        }
    }

    class Assembler {
        public string Assemble(string source) {
            return "assembly_output";
        }
    }

    class Linker {
        public string Link(string source) {
            return "out.o";
        }
    }

    //  Section 2
    //  Service provider facade
    class Compiler {
        //  Provides a unified and simple interface to the clients
        public string Compile(string sourceFileName) {
            //  Section 3
            //  Constituent API calls are handled in the facade
            //  Please note that the constituents are not hidden
            var preProcessor = new Preprocessor();
            var codeGenerator = new CodeGenerator();
            var assembler = new Assembler();
            var linker = new Linker();

            var preProcessorOutput =
                preProcessor.Process(System.Text.Encoding.UTF8.GetBytes("this is the source code"));
            var codeGeneratorOutput = codeGenerator.Generate(preProcessorOutput);
            var assemblerOutput = assembler.Assemble(codeGeneratorOutput);
            var linkerOutput = linker.Link(assemblerOutput);
            return linkerOutput;
        }
    }
}
