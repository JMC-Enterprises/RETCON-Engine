using System;
using RETCON.Core.Graphics;

namespace RETCON.Core.OpenGL;

public struct GlfWwindow : IEquatable<GlfWwindow>
{
    private readonly IntPtr _handle;

    public GlfWwindow(IntPtr handle)
    {
        _handle = handle;
    }
    
    // Operators
    public static explicit operator GlfWwindow(IntPtr handle) => new GlfWwindow(handle);
    public static implicit operator IntPtr(GlfWwindow window) => window._handle;

    public override string ToString()
    {
        return _handle.ToString();
    }

    public override bool Equals(object? obj)
    {
        return obj is GlfWwindow other && Equals(other);
    }

    public override int GetHashCode()
    {
        return _handle.GetHashCode();
    }

    public bool Equals(GlfWwindow other)
    {
        return _handle.Equals(other._handle);
    }
}