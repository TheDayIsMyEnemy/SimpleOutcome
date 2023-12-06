namespace SimpleOutcome
{
    /// <summary>
    /// Provides constants for commonly used messages in the application.
    /// </summary>
    public static class Message
    {
        public const string InvalidRequest = "The requested action is invalid";
        public const string InsufficientPermissions = "You do not have sufficient permissions to perform this action";
        public const string UnexpectedError = "An unexpected error occurred";
    }

    /// <summary>
    /// Provides format strings for messages with placeholders.
    /// </summary>
    public static class Format
    {
        public const string Created = "{0} has been created successfully";
        public const string Updated = "{0} has been updated successfully";
        public const string Deleted = "{0} has been deleted successfully";
        public const string NotFound = "{0} not found";
        public const string AlreadyExists = "{0} already exists";
        public const string ValidationError = "Validation error: {0}";
    }
}