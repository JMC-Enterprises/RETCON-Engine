using System.Runtime.InteropServices;

namespace RETCON.Core.OpenGL;

public class RetconGl
{
    private const string LIBRARY = "libRETCON_GLFW";
    
    [DllImport(LIBRARY, EntryPoint = "init", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool Init();
}