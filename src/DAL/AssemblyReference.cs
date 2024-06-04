using System.Reflection;

namespace DAL;

public class AssemblyReference
{
    internal static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}