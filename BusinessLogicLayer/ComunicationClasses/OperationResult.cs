
namespace BusinessLogicLayer.ComunicationClasses
{
    public class OperationResult
    {
        public bool success;
        public string? message;

        public OperationResult(bool success, string? message = null)
        {
            this.success = success;
            this.message = message;
        }
    }
}
