using System;
using System.Diagnostics;
using GLFW;
using OpenGL;
using RETCON.Core.Event;

namespace RETCON.Core.Graphics
{
    public class Window
    {
        public required string title { get; init; }
        public required uint width { get; init; }
        public required uint height { get; init; }
        
        public delegate void EventCallbackFunction(BaseEvent e);

        public EventCallbackFunction EventCallback { get; private set; }

        public GLFW.Window glWindow { get; protected set; } = GLFW.Window.None;
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
            CreateWindow(out var window);
            glWindow = window;

            if (glWindow == GLFW.Window.None)
            {
                throw new AggregateException("Failed to create window");
            }
            
            // Basic OpenGL setup
            Glfw.MakeContextCurrent(glWindow);
            Glfw.SwapInterval(1);
            Glfw.SetFramebufferSizeCallback(glWindow,
                (win, sizeWidth, sizeHeight) => Gl.glViewport(0, 0, sizeWidth, sizeHeight));

            // Create Events
            Glfw.SetWindowFocusCallback(glWindow, (win, focusing) =>
                {
                    if (focusing)
                    {
                        var focusEvent = new WindowFocusEvent(this);
                        focusEvent.Dispatch();
                        return;
                    }
                    
                    var unfocusEvent = new WindowLostFocusEvent(this);
                    unfocusEvent.Dispatch(); 
                });
            
            WindowOpenEvent openEvent = new WindowOpenEvent(this);
            openEvent.Dispatch();
        }

        public virtual void Update(float dt)
        {
            // Window Events
            if (Glfw.WindowShouldClose(glWindow))
            {
                WindowCloseEvent closeEvent = new WindowCloseEvent(this);
                closeEvent.Dispatch();
                
                Terminate();
            }

            Glfw.PollEvents();
            
            AppUpdateEvent updateEvent = new AppUpdateEvent(dt);
            updateEvent.Dispatch();
            
            Glfw.SwapBuffers(glWindow);
        }

        public virtual void Terminate()
        {
            // Close window
            Glfw.DestroyWindow(glWindow);
            Glfw.Terminate();
            
            // Clean up OpenGL
            // Gl.glDeleteProgram(_program);
            
            // Dispatch close event
            WindowCloseEvent closeEvent = new WindowCloseEvent(this);
            closeEvent.Dispatch();
        }

        public void SetEventCallback(EventCallbackFunction func)
        {
            EventCallback = func;
        }

        public void ChangeTitle(string newTitle)
        {
            Glfw.SetWindowTitle(glWindow, title);
        }
    }

    public static class Input
    {
        // Keys
        public static bool IsKeyPressed(Keys key, GLFW.Window window)
        {
            return Glfw.GetKey(window, key) == InputState.Press;
        }
        
        public static bool IsKeyReleased(Keys key, GLFW.Window window)
        {
            return Glfw.GetKey(window, key) == InputState.Release;
        }
        
        public static bool IsKeyHeld(Keys key, GLFW.Window window)
        {
            return Glfw.GetKey(window, key) == InputState.Repeat;
        }

        // Mouse
        public static bool IsMouseButtonPressed(GLFW.MouseButton button, GLFW.Window window)
        {
            return Glfw.GetMouseButton(window, button) == InputState.Press;
        }
        
        public static bool IsMouseButtonReleased(GLFW.MouseButton button, GLFW.Window window)
        {
            return Glfw.GetMouseButton(window, button) == InputState.Release;
        }
        
        public static bool IsMouseButtonHeld(GLFW.MouseButton button, GLFW.Window window)
        {
            return Glfw.GetMouseButton(window, button) == InputState.Repeat;
        }
        
        public static (double x, double y) GetMousePosition(GLFW.Window window)
        {
            Glfw.GetCursorPosition(window, out var x, out var y);
            return (x, y);
        }
        
        public static void SetMousePosition(double x, double y, GLFW.Window window)
        {
            Glfw.SetCursorPosition(window, x, y);
        }
    }
}
