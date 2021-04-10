namespace Accounts.Assets
{
    public class Message
    {
        public int sender;
        public int receiver;
        public string message;
        public string timestamp;
        public Message(int sender, int receiver, string message, string timestamp)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.message = message;
            this.timestamp = timestamp;
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