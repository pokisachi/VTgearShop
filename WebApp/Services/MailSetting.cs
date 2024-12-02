namespace WebApp.Services;


public class MailSettings{
    
    public string Host { get; set; } = null!;
    public short Port { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name {get; set;} = null!;
}