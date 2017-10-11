namespace BashSoftProgram.Contracts.Tester
{
    public interface IContentComparer
    {
        void CompareContent(string userOutputPath, string expectedOutputPath);
    }
}
