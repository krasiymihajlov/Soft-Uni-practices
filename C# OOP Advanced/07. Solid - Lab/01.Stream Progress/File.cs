namespace _01.Stream_Progress
{
    public abstract class File
    {
        //private string name;

        public File(int length, int bytesSent)
        {
            // this.name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}