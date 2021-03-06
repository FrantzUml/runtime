using System;
using System.ComponentModel;

/// <summary>
/// Tests that the System.ComponentModel.TypeDescriptor.ComObjectType
/// property works as expected when used in a trimmed application.
/// </summary>
class Program
{
    static int Main(string[] args)
    {
        Type type = TypeDescriptor.ComObjectType;

        // Tests that the ctor for System.ComponentModel.TypeDescriptor+TypeDescriptorComObject is not trimmed out.
        object obj = Activator.CreateInstance(type);
        string expectedObjTypeNamePrefix = "System.ComponentModel.TypeDescriptor+TypeDescriptorComObject, System.ComponentModel.TypeConverter, Version=";

        return obj != null && obj.GetType().AssemblyQualifiedName.StartsWith(expectedObjTypeNamePrefix)
            ? 100
            : -1;
    }
}
