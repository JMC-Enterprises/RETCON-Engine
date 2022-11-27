using System;
using GLFW;
using System.IO;
using RETCON.Core.Event;
using static OpenGL.Gl;

namespace RETCON.Core.RET_Window
{
    //TODO: Clean up code and make it more dynamic and implement event support

    public class Window
    {
        public required string title { get; init; }
        public required uint width { get; init; }
        public required uint height { get; init; }
        
        public delegate void EventCallbackFunction(BaseEvent e);

        public EventCallbackFunction EventCallback { get; private set; }

        private GLFW.Window _window = GLFW.Window.None;
        private uint _program = 0;

        protected virtual void CreateWindow(out GLFW.Window window)
        {
            if (!Glfw.Init())
            {
                window = GLFW.Window.None;
                return;
            }

            window = Glfw.CreateWindow((int)width, (int)height, title, GLFW.Monitor.None, GLFW.Window.None);
        }

        public void Run()
        {
            return; // Function isn't done yet
            
            CreateWindow(out _window);

            if (_window == GLFW.Window.None)
            {
                throw new AggregateException("Failed to create window");
            }
            
            Glfw.MakeContextCurrent(_window);
            Glfw.SwapInterval(1);
            
            Glfw.SetFramebufferSizeCallback(_window, (window, width, height) =>
            {
                glViewport(0, 0, width, height);
            });
            
            Glfw.SetKeyCallback(_window, (window, key, scancode, action, mods) =>
            {
                if (key == GLFW.Keys.Escape)
                {
                    Glfw.SetWindowShouldClose(window, true);
                }
            });
        }

        public void SetEventCallback(EventCallbackFunction func)
        {
            EventCallback = func;
        }
    }
}
