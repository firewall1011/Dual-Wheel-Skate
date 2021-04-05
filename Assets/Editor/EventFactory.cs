using System.IO;
using System.Threading.Tasks;

public static class EventFactory
{
    public static void GenerateEventCode(string @class, string @namespace, string path)
    {
        string _type = @class.Trim();
        string _upperType = _type.ToUpper()[0] + @class.Substring(1);

        string result = @"
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have " + _type + @" as argument
/// </summary>

[CreateAssetMenu(menuName = ""Events/" + _upperType + @"Event Channel"")]
public class " + _upperType + @"EventChannelSO : ScriptableObject
{
    public UnityAction<" + _type + @"> OnEventRaised;
    
    public void RaiseEvent(" + _type + @" value)
    {
        if (OnEventRaised != null)
            OnEventRaised.Invoke(value);
    }
}
";
        if (!string.IsNullOrEmpty(@namespace))
        {
            result = $@"using {@namespace};
" + result;
        }

        string _path = Path.Combine(path, _upperType + "EventChannelSO.cs");
        File.WriteAllText(_path, result);
    }

    public static void GenerateListenerCode(string @class, string @namespace, string path)
    {
        string _type = @class.Trim();
        string _upperType = _type.ToUpper()[0] + @class.Substring(1);

        string result = @"
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// To use a generic UnityEvent type you must override the generic type.
/// </summary>
[System.Serializable]
public class " + _upperType + @"Event : UnityEvent<" + _type + @">{}

/// <summary>
/// A flexible handler for " + _type + @" events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
/// </summary>
public class " + _upperType + @"EventListener : MonoBehaviour
{
	[SerializeField] private " + _upperType + @"EventChannelSO _channel = default;

	public " + _upperType + @"Event OnEventRaised;

	private void OnEnable()
	{
		if (_channel != null)
			_channel.OnEventRaised += Respond;
	}

	private void OnDisable()
	{
		if (_channel != null)
			_channel.OnEventRaised -= Respond;
	}

	private void Respond(" + _type + @" value)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(value);
	}
}
";
        if (!string.IsNullOrEmpty(@namespace))
        {
            result = $@"using {@namespace};
" + result;
        }

        string _path = Path.Combine(path, _upperType + "EventListener.cs");
        File.WriteAllText(_path, result);
    }

    public static Task[] GenerateAllEventCode(string @class, string @namespace, string path)
    {
        Task eventCodeTask = Task.Run(()=>GenerateEventCode(@class, @namespace, path));
        Task listenerCodeTask = Task.Run(()=>GenerateListenerCode(@class, @namespace, path));

        return new Task[2] { eventCodeTask, listenerCodeTask };
    }
}
