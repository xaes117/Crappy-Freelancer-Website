namespace Accounts.Assets
{
    public class Message
    {
        public int sender;
        public int receiver;
        public string sender_name;
        public string receiver_name;
        public string message;
        public string timestamp;
        public Message(int sender, int receiver, string sender_name, string receiver_name, string message, string timestamp)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.message = message;
            this.timestamp = timestamp;

            this.sender_name = sender_name;
            this.receiver_name = receiver_name;
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