using UnityEngine;
using UnityEditor;
using System.Threading.Tasks;

public class EventFactoryWindow : EditorWindow
{
    public string @namespace = "";
    public string type = "";
    public string eventPath = "";
    public string listenerPath = "";
    public bool IsInNameSpace = false;
    public bool checkTypes = false;


    // Add menu named "My Window" to the Window menu
    [MenuItem("Window/Script Factory/Event")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        EventFactoryWindow window = (EventFactoryWindow)EditorWindow.GetWindow(typeof(EventFactoryWindow));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Customization Settings", EditorStyles.boldLabel);
        IsInNameSpace = EditorGUILayout.Toggle("Include namespace?", IsInNameSpace);
        
        GUILayout.Label("Type Settings", EditorStyles.boldLabel);
        if (IsInNameSpace)
            @namespace = EditorGUILayout.TextField("Namespace", @namespace);
        else @namespace = string.Empty;
        type = EditorGUILayout.TextField("Type", type);

        GUILayout.Label("Project Organization Settings", EditorStyles.boldLabel);
        eventPath = EditorGUILayout.TextField("Event Folder path", eventPath);
        listenerPath = EditorGUILayout.TextField("Event Listener Folder path", listenerPath);



        if (GUILayout.Button(new GUIContent(text: "Create Event Script",
            tooltip: $"Press Button to create C# script for an implementation of Event using ScriptableObject and an Event Listener of type {type} in path {eventPath}")))
        {
            if (!IsInNameSpace)
            {
                if (checkTypes && !TypeChecker.VerifyExistence(type, @namespace))
                {
                    Debug.LogError($"Type {type} does not exist");
                }
                else GenerateCode();
            }
            else GenerateCode();

            AssetDatabase.Refresh();
        }
    }

    private void GenerateCode()
    {
        Task[] tasks = 
        {
            Task.Run(()=>EventFactory.GenerateEventCode(type, @namespace, eventPath)),
            Task.Run(()=>EventFactory.GenerateListenerCode(type, @namespace, listenerPath))
        };
        Task.WaitAll(tasks);
    }
}
