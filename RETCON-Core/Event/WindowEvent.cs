using System.Diagnostics;
using RETCON.Core.Graphics;

namespace RETCON.Core.Event
{
    public class WindowBaseEvent : BaseEvent
    {
        protected Window _window;
        
        public WindowBaseEvent(Window window)
        {
            _category = EventCategory.Window;
            
            _window = window;
        }

        public void Dispatch()
        {
            _window.EventCallback(this);
        }
    }
    
    public class WindowResizeEvent : WindowBaseEvent
    {
        private uint _width;
        private uint _height;

        public WindowResizeEvent(Window window, uint width, uint height) : base(window)
        {
            _width = width;
            _height = height;
            
            _type = EventType.WindowResize;
            _window = window;
        }

        uint GetWidth() { return _width; }
        uint GetHeight() { return _height; }

        public override string ToString()
        {
            return $"{nameof(WindowResizeEvent)}: {_width}, {_height}";
        }
    }

    public class WindowCloseEvent : WindowBaseEvent
    {
        public WindowCloseEvent(Window window) : base(window)
        {
            _type = EventType.WindowClose;
            _window = window;
        }

        public override string ToString()
        {
            return $"{_window.title} closed";
        }
    }
    
    public class WindowOpenEvent : WindowBaseEvent
    {
        public WindowOpenEvent(Window window) : base(window)
        {
            _type = EventType.WindowOpen;
            _window = window;
        }
    }

    public class WindowFocusEvent : WindowBaseEvent
    {
        public WindowFocusEvent(Window window) : base(window)
        {
            _type = EventType.WindowFocus;
            _window = window;
        }
    }

    public class WindowLostFocusEvent : WindowBaseEvent
    {
        public WindowLostFocusEvent(Window window) : base(window)
        {
            _type = EventType.WindowLostFocus;
            _window = window;
        }
    }

    public class WindowMovedEvent : WindowBaseEvent
    {
        private uint _x;
        private uint _y;

        public uint GetX() { return _x; }
        public uint GetY() { return _y; }

        public WindowMovedEvent(Window window, uint x, uint y) : base(window)
        {
            _x = x;
            _y = y;

            _type = EventType.WindowMoved;
        }

        public override string ToString()
        {
            return $"{nameof(WindowMovedEvent)}: {_x}, {_y}";
        }
    }

    // Application Events
    public class AppTickEvent : BaseEvent
    {
        public AppTickEvent()
        {
            _category = EventCategory.Application;
            _type = EventType.AppTick;
        }
    }

    public class AppUpdateEvent : BaseEvent
    {
        private float _dt; // dt = Delta Time (time since last update)

        public float GetDeltaTime() { return _dt; }

        public AppUpdateEvent(float dt)
        {
            _dt = dt;

            _category = EventCategory.Application;
            _type = EventType.AppUpdate;
        }

        public override void Dispatch()
        {
            base.Dispatch();
            Logger.Logger.Engine.Log($"Update took {this}", Logger.LogColors.Trace);
        }

        public override string ToString()
        {
            return $"{_dt * 1000}ms";
        }
    }

    public class AppRenderEvent : BaseEvent
    {
        public AppRenderEvent()
        {
            _category = EventCategory.Application;
            _type = EventType.AppRender;
        }
    }
}
