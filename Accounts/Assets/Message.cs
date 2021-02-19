namespace Accounts.Assets
{
    public class Message
    {
        private Account accountHolder;
        private Account accountCommunicator;
        private string message;
        private string timestamp;
        public Message(Account accountHolder, Account accountCommunicator, string message, string timestamp)
        {
            this.accountHolder = accountHolder;
            this.accountCommunicator = accountCommunicator;
            this.message = message;
            this.timestamp = timestamp;
        }

        public Account getAccount()
        {
            return this.accountHolder;
        }

        public Account getCommunicator()
        {
            return this.accountCommunicator;
        }

        public string getMessage()
        {
            return this.message;
        }

        public string getTimestamp()
        {
            return this.timestamp;
        }
    }
}