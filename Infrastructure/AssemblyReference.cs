using System.Reflection;

namespace Infrastructure
{
    public static class AssemblyReference
    {
        public static Assembly AddInfrastructureAssembly() => 
            typeof(AssemblyReference).Assembly;
    }
}
