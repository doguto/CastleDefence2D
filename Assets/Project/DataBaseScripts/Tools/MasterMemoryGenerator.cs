using System.Diagnostics;
using UnityEditor;
using UnityEngine;


namespace Project.MasterDataScripts
{
    public class MasterMemoryGenerator
    {
        [MenuItem("MasterMemory/CodeGenerate")]
        static void GenerateMasterMemory()
        {
            ExecuteMasterMemoryCodeGenerator();
        }

        static void ExecuteMasterMemoryCodeGenerator()
        {
            UnityEngine.Debug.Log($"{nameof(ExecuteMasterMemoryCodeGenerator)} : start");

            var exProcess = new Process();

            var rootPath = Application.dataPath + "/..";
            var filePath = rootPath + "/GeneratorTools/MasterMemory.Generator";
            var exeFileName = "";
#if UNITY_EDITOR_WIN
            exeFileName = "/win-x64/MasterMemory.Generator.exe";
#elif UNITY_EDITOR_OSX
        exeFileName = "/osx-x64/MasterMemory.Generator";
#elif UNITY_EDITOR_LINUX
        exeFileName = "/linux-x64/MasterMemory.Generator";
#else
        return;
#endif
            var psi = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                FileName = filePath + exeFileName,
                // TODO: 使用する場合はPath, Argumentsを変更してください
                Arguments =
                    $@"-i ""{Application.dataPath}/Project/DataBaseScripts"" -o ""{Application.dataPath}/Scripts/Generated/MasterMemory"" -c -n Generated",
            };

            var p = Process.Start(psi);

            p.EnableRaisingEvents = true;
            p.Exited += (object sender, System.EventArgs e) =>
            {
                var data = p.StandardOutput.ReadToEnd();
                UnityEngine.Debug.Log($"{data}");
                UnityEngine.Debug.Log($"{nameof(ExecuteMasterMemoryCodeGenerator)} : end");
                p.Dispose();
                p = null;
            };
        }
    }
}