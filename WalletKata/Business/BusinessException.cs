namespace WalletKata.Business
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }

        public int Status { get; set; } = 500;

        public object Value { get; set; }
    }
}
