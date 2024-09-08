using UnityEditor;

public static class ScriptTemplates {


    [MenuItem("Assets/Templates/Scripts", priority = 1)]
    public static void CreateScript() {
        string templatePath = "Assets/ScriptsTemplates/Script.cs.txt";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "Script.cs");

    }
}
