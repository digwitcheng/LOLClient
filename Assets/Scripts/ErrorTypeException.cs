using System;
using System.Runtime.Serialization;

[Serializable]
internal class ErrorTypeException : Exception
{
    public string Error { get; set; }
    public ErrorTypeException()
    {
        this.Error = "错误的模块类型";
    }

    public ErrorTypeException(string message) : base(message)
    {
        this.Error = message;
    }

    public ErrorTypeException(string message, Exception innerException) : base(message, innerException)
    {
    }
}