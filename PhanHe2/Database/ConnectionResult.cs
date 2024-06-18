namespace PhanHe2
{
    public enum ConnectionStatus
    {
        Success, Failure, InvalidCredentials, ConnectionError
    }

    public class ConnectionResult
    {
        public ConnectionStatus Status { get; set; }
        public string Message { get; set; }

        public ConnectionResult(ConnectionStatus status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
