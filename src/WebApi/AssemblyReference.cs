using System.Reflection;

namespace WebApi;

public class AssemblyReference
{
    internal static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}