namespace StreamProgress
{
    public class File : IProgressable
    {
        private string name;

        public File(string name, int length, int bytesSent)
        {
            this.name = name;
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
