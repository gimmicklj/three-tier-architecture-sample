using System.Reflection;

namespace BLL;

public class AssemblyReference
{
    internal static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}