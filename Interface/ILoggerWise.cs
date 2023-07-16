namespace apiwise.Interface
{
    public interface ILoggerWise
    {
        public void LogInformation(string mensaje);
        public void LogError(string mensaje);
        public void LogWarning(string mensaje);
    }
}
