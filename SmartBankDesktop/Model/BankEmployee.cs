namespace SmartBankDesktop.Model
{
    public class BankEmployee
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(UserName)}: {UserName}, {nameof(Password)}: {Password}, {nameof(Salt)}: {Salt}";
        }
    }
}