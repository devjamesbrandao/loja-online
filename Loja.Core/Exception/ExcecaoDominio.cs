namespace Loja.Core.Exceptions
{
    public class ExcecaoDominio : Exception
    {
        public ExcecaoDominio()
        { }

        public ExcecaoDominio(string message) : base(message)
        { }

        public ExcecaoDominio(string message, Exception innerException) : base(message, innerException)
        { }
    }
}