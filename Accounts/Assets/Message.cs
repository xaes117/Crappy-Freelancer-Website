namespace Accounts.Assets
{
    public class Message
    {
        private int accountHolder;
        private int accountCommunicator;
        private string message;
        private string timestamp;
        public Message(int accountHolder, int accountCommunicator, string message, string timestamp)
        {
            this.accountHolder = accountHolder;
            this.accountCommunicator = accountCommunicator;
            this.message = message;
            this.timestamp = timestamp;
        }

        public int getAccount()
        {
            return this.accountHolder;
        }

        public int getCommunicator()
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