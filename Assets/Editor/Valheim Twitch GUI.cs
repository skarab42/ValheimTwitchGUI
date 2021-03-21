using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEditor.Compilation;
using System.Linq;
using UnityEditor.Build.Player;

public class CreateAssetBundles : MonoBehaviour
{
    private const string filename = "ValheimTwitchGUI";
    private const string destDir = "C:\\Users\\skarab\\source\\repos\\ValheimTwitch\\ValheimTwitch\\Assets";

    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        
        if(!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        
        CompilationPipeline.compilationFinished += OnCompilationFinished;

        var input = new ScriptCompilationSettings
        {
            target = BuildTarget.StandaloneWindows,
            group = BuildTargetGroup.Standalone,
        };

        string dllpath = $"{Application.streamingAssetsPath}/Assemblies";

        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }

        PlayerBuildInterface.CompilePlayerScripts(input, dllpath);

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, 
                                        BuildAssetBundleOptions.None, 
                                        BuildTarget.StandaloneWindows);

        string source = $"{assetBundleDirectory}/valheimtwitchgui";
        string target = $"{destDir}\\valheimtwitchgui";   
        
        FileUtil.ReplaceFile(source, target);
    }

    private static void OnCompilationFinished(object sender) {
        CompilationPipeline.compilationFinished -= OnCompilationFinished;
    
        var assemblies = CompilationPipeline.GetAssemblies(AssembliesType.Player);

        var assembly = assemblies.FirstOrDefault(e => {
            return e.name.Equals("Assembly-CSharp");
        });

        if (assembly == null)
            return;

        string target = $"{destDir}\\{filename}.dll";

        File.Copy(assembly.outputPath, target);
    }
}