using System;
using System.CodeDom.Compiler;
using System.IO;
using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;

namespace taskt.Core.Automation.Commands
{
    public static class CSharpCodeCompilerControls
    {
        private const string defaultOutFileName = "tasktOnTheFly.exe";

        /// <summary>
        /// read here
        /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version?WT.mc_id=AI-MVP-123445
        /// </summary>
        private const string defaultLangVersion = "default";

        public static CompilerResults CompileInput(string codeInput, string langVersion = "", string outFileName = "")
        {
            //if (string.IsNullOrEmpty(langVersion)) 
            //{ 
            //    langVersion = defaultLangVersion;
            //}
            //if (string.IsNullOrEmpty(outFileName)) 
            //{ 
            //    outFileName = defaultOutFileName;
            //}

            //if (!outFileName.EndsWith(".exe"))
            //{
            //    outFileName += ".exe";
            //}

            //string outFilePath;
            //if (string.IsNullOrEmpty(Path.GetDirectoryName(outFileName)))
            //{
            //    outFilePath = Path.Combine(IO.Folders.GetTasktTemporaryFolderPath(), outFileName);
            //}
            //else
            //{
            //    var fn = Path.GetFileName(outFileName);
            //    outFilePath = Path.Combine(IO.Folders.GetTasktTemporaryFolderPath(), fn);
            //}

            //// create provider
            ////CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
            //var roslyn = new Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider();

            //// create compile parameters
            //var parameters = new CompilerParameters
            //{
            //    GenerateExecutable = true,
            //    OutputAssembly = outFilePath,
            //    CompilerOptions = $"-langversion:{langVersion}",
            //};

            //// compile
            //return roslyn.CompileAssemblyFromSource(parameters, codeInput);

            return CompileProcess(new Func<CSharpCodeProvider, CompilerParameters, CompilerResults>((r, p) =>
            {
                return r.CompileAssemblyFromSource(p, codeInput);
            }), langVersion, outFileName);
        }

        /// <summary>
        /// general compile action
        /// </summary>
        /// <param name="roslynCompileFunc"></param>
        /// <param name="langVersion"></param>
        /// <param name="outFileName"></param>
        /// <returns></returns>
        private static CompilerResults CompileProcess(Func<CSharpCodeProvider, CompilerParameters, CompilerResults> roslynCompileFunc, string langVersion = "", string outFileName = "")
        {
            if (string.IsNullOrEmpty(langVersion))
            {
                langVersion = defaultLangVersion;
            }
            if (string.IsNullOrEmpty(outFileName))
            {
                outFileName = defaultOutFileName;
            }

            if (!outFileName.EndsWith(".exe"))
            {
                outFileName += ".exe";
            }

            string outFilePath;
            if (string.IsNullOrEmpty(Path.GetDirectoryName(outFileName)))
            {
                outFilePath = Path.Combine(IO.Folders.GetTasktTemporaryFolderPath(), outFileName);
            }
            else
            {
                var fn = Path.GetFileName(outFileName);
                outFilePath = Path.Combine(IO.Folders.GetTasktTemporaryFolderPath(), fn);
            }

            // create provider
            //CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
            var roslyn = new CSharpCodeProvider();

            // create compile parameters
            var parameters = new CompilerParameters
            {
                GenerateExecutable = true,
                OutputAssembly = outFilePath,
                CompilerOptions = $"-langversion:{langVersion}",
            };

            return roslynCompileFunc(roslyn, parameters);
        }
    }
}
