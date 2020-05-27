using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CommandResult: ICommandResult
    {
        public CommandResult()
        {
            
        }
        public CommandResult(bool sucess, string message)
        {
            Sucess = sucess;
            Message = message;
        }

        private bool Sucess { get; set; }
        private string Message { get; set; }

    }
}