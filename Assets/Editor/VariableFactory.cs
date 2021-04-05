using UnityEngine;
using System.IO;

public static class VariableFactory
{
    public static bool CreateVariable(string @class, string @namespace, string path)
    {
        string _type = @class.Trim();
        string _upperType = _type.ToUpper()[0] + @class.Substring(1);

        string result = @"
using UnityEngine;
[CreateAssetMenu(fileName = "" "+ _upperType + @""", menuName = ""Variables / Primitive / " + _type + @""")]
public class " + _upperType + @"Variable : ScriptableObject
{
    public " + _type + @" Value = default;

    public static implicit operator " + _type + @"(" + _upperType + @"Variable target) => target.Value;
}";

        if (!string.IsNullOrEmpty(@namespace))
        {
            result = $@"using {@namespace};
" + result;
        }
        
        string _path = Path.Combine(path, _upperType + "Variable.cs");
        File.WriteAllText(_path, result);
        return true;
    }
}