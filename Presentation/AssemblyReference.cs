using System.Reflection;

namespace Presentation
{
    public static class AssemblyReference
    {
        public static Assembly AddPresentationAssembly() =>
            typeof(AssemblyReference).Assembly;
    }
}