using RETCON.Core.Event;
using RETCON.Core.Logger;
using static RETCON.Core.OpenGL.RetconGl;

namespace RETCON.Core.Graphics
{
    public class Window
    {
        public required string title { get; init; }
        public required uint width { get; init; }
        public required uint height { get; init; }
        
        public delegate void EventCallbackFunction(BaseEvent e);

        public EventCallbackFunction EventCallback { get; private set; }
        private uint _program = 0;

        public void Run()
        {
            // var window = CreateWindow(350, 350, "Hello World");
            // Terminate();

            WindowOpenEvent openEvent = new WindowOpenEvent(this);
            openEvent.Dispatch();
        }

        public virtual void Update(float dt)
        {
            // App Events
            AppUpdateEvent updateEvent = new AppUpdateEvent(dt);
            updateEvent.Dispatch();

            // Window Events
        }

        public virtual void Terminate()
        {
            // Close window

            // Dispatch close event
            WindowCloseEvent closeEvent = new WindowCloseEvent(this);
            closeEvent.Dispatch();
        }

        public void SetEventCallback(EventCallbackFunction func)
        {
            EventCallback = func;
        }
    }

    // public static class Input
    // {
    //     // Keys
    //     public static bool IsKeyPressed(Keys key, GLFW.Window window)
    //     {
    //         return Glfw.GetKey(window, key) == InputState.Press;
    //     }
    //     
    //     public static bool IsKeyReleased(Keys key, GLFW.Window window)
    //     {
    //         return Glfw.GetKey(window, key) == InputState.Release;
    //     }
    //     
    //     public static bool IsKeyHeld(Keys key, GLFW.Window window)
    //     {
    //         return Glfw.GetKey(window, key) == InputState.Repeat;
    //     }
    //
    //     // Mouse
    //     public static bool IsMouseButtonPressed(GLFW.MouseButton button, GLFW.Window window)
    //     {
    //         return Glfw.GetMouseButton(window, button) == InputState.Press;
    //     }
    //     
    //     public static bool IsMouseButtonReleased(GLFW.MouseButton button, GLFW.Window window)
    //     {
    //         return Glfw.GetMouseButton(window, button) == InputState.Release;
    //     }
    //     
    //     public static bool IsMouseButtonHeld(GLFW.MouseButton button, GLFW.Window window)
    //     {
    //         return Glfw.GetMouseButton(window, button) == InputState.Repeat;
    //     }
    //     
    //     public static (double x, double y) GetMousePosition(GLFW.Window window)
    //     {
    //         Glfw.GetCursorPosition(window, out var x, out var y);
    //         return (x, y);
    //     }
    //     
    //     public static void SetMousePosition(double x, double y, GLFW.Window window)
    //     {
    //         Glfw.SetCursorPosition(window, x, y);
    //     }
    // }
}
