using System.Reflection;

namespace Application
{
    public static class AssemblyReference
    {
        public static Assembly AddApplicationAssembly() => 
            typeof(AssemblyReference).Assembly;
    }
}
