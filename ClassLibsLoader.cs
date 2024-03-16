namespace MahoTrans.ClassLibs;

/// <summary>
///     Simple interface to classes hosted in MahoTrans.ClassLibs library.
/// </summary>
public static class ClassLibsLoader
{
    /// <summary>
    ///     Gets full names of classes hosted here.
    /// </summary>
    public static IEnumerable<string> Names
    {
        get { return typeof(ClassLibsLoader).Assembly.GetManifestResourceNames().Where(x => x.EndsWith(".class")); }
    }

    /// <summary>
    ///     Gets streams for classes hosted here. Do not forget to dispose them.
    /// </summary>
    public static List<Stream> GetClasses()
    {
        var list = new List<Stream>();
        var ass = typeof(ClassLibsLoader).Assembly;
        foreach (var name in Names)
        {
            list.Add(ass.GetManifestResourceStream(name)!);
        }

        return list;
    }
}