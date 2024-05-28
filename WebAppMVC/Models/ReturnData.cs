namespace WebAppMVC.Models
{
    public class ReturnData
    {
        public int ReturnCode { get; set; }
        public string? ReturnMsg { get; set; }
    }
    public class UserLoginReturnData : ReturnData
    {
        public string? userName { get; set; }
        public string? token { get; set; }

        public string? refeshToken { get; set; }

        public int IsAdmin { get; set; }
    }
}
