using UnityEngine;
using UnityEditor;
using System.Threading.Tasks;

public class VariableFactoryWindow : EditorWindow
{
    public string @namespace = "";
    public string @class = "";
    public string path = "";
    public bool VerifyTypeExistence = true;

    private Task _runningTask = null;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Window/Script Factory/Variable")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        VariableFactoryWindow window = (VariableFactoryWindow)EditorWindow.GetWindow(typeof(VariableFactoryWindow));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Type Settings", EditorStyles.boldLabel);
        @namespace = EditorGUILayout.TextField("Namespace", @namespace);
        @class = EditorGUILayout.TextField("Class", @class);

        GUILayout.Label("Project Organization Settings", EditorStyles.boldLabel);
        path = EditorGUILayout.TextField("Folder path", path);

        GUILayout.Label("Customization Settings", EditorStyles.boldLabel);
        VerifyTypeExistence = EditorGUILayout.Toggle("Verify if Class Exists", VerifyTypeExistence);
        
        if(_runningTask != null && _runningTask.IsCompleted)
        {
            AssetDatabase.Refresh();
            _runningTask = null;
        }
        
        if (_runningTask == null)
        {
            if(GUILayout.Button(new GUIContent(text: "Create Variable Script", 
                tooltip: $"Press Button to create C# script for an implementation of a variable using ScriptableObject of type {@class} in path {path}")))
            {
                if (VerifyTypeExistence)
                {
                    if (!TypeChecker.VerifyExistence(@class, @namespace))
                    {
                        Debug.LogError($"Type {@class} does not exist");
                    }
                    else _runningTask = Task.Run(() => VariableFactory.CreateVariable(@class, @namespace, path));
                }
                else _runningTask = Task.Run(() => VariableFactory.CreateVariable(@class, @namespace, path));
            }
        }
    }
}
