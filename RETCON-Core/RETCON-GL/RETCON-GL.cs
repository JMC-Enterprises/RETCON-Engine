using System.Runtime.InteropServices;
using System.Text;

namespace RETCON.Core.OpenGL;

public unsafe class RetconGl
{
    private const string LIBRARY = "libRETCON_GLFW";
    
    [DllImport(LIBRARY, EntryPoint = "init", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool Init();
    
    [DllImport(LIBRARY, EntryPoint = "createWindow", CallingConvention = CallingConvention.Cdecl)]
    public static extern GlfWwindow CreateWindow(int width, int height, byte[] title);

    public static GlfWwindow CreateWindow(int width, int height, string title)
        => CreateWindow(width, height, Encoding.Unicode.GetBytes(title));
    
    [DllImport(LIBRARY, EntryPoint = "terminate", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Terminate();
    
    [DllImport(LIBRARY, EntryPoint = "swapBuffers", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SwapBuffers(GlfWwindow window);
}