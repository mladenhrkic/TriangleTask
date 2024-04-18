using System.Reflection;

namespace Domain
{
    public static class AssemblyReference
    {
        public static Assembly AddDomainAssembly() => 
            typeof(AssemblyReference).Assembly;
    }
}
