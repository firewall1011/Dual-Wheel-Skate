using System;
using System.Collections.Generic;
public static class TypeChecker
{
    private static List<string> primitiveTypes = new List<string>() { "int", "float", "double", "string", "bool", "object" };
    public static bool VerifyExistence(string @class, string @namespace)
    {
        Type typeExists = Type.GetType(String.Format("{0}.{1}", @namespace, @class));
        return typeExists != null || primitiveTypes.Contains(@class);
    }
}