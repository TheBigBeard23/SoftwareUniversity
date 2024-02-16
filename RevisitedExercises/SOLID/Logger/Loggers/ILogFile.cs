namespace Logger.Loggers
{
    public interface ILogFile
    {
        public int Size { get; }
        void Write(string content);
    }
}
