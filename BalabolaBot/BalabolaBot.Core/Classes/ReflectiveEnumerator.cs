using System.Reflection;

namespace BalabolaBot.Core.Classes;

public static class ReflectiveEnumerator
{
    static ReflectiveEnumerator() { }

    public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
    {
        var objects = Assembly.GetAssembly(typeof(T))
            .GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T)))
            .Select(type => (T)Activator.CreateInstance(type, constructorArgs))
            .ToList();
        return objects;
    }
}