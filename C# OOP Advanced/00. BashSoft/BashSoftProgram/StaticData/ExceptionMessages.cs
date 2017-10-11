namespace BashSoftProgram.StaticData
{
    public static class ExceptionMessages
    {
        public const string ExampleExceptionMessage = "Example message!";

        public const string DataAlreadyInitialisedException = "DataAlreadyInitialisedException";

        public const string DataNotInitializedExceptionMessage = "The data structure must be initialised first in order to make any operations with it.";

        public const string NonExistingCourseInDataBase = "The course you are trying to get does not exist in the data base!";

        public const string NonExistingStudentInDataBase = "The user name for the student you are trying to get does not exist!";

        public const string UnauthorizedAccessExceptionMessage = "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch.";        

        public const string UnableToGoHigherInPartitionHierarchy = " Unable to go higher in partition hierarcy.";        

        public const string InvalidStudentFilter = "The given filter is not one of the following: excellent/average/poor";

        public const string InvalidComparisonQuery = "The comparison query you want, does not exist in the context of the current program!";

        public const string InvalidTakeCommand = "The take command is not valid";

        public const string InvalidNumberOfScores = "The number of scores for the given course is greater than the possible.";

        public const string InvalidScore = "The number for the score you've entered is not in the range of 0 - 100";

        public const string NullOrEmptyValue = "The value of the variable CANNOT be null or empty!"; 
    }
}
