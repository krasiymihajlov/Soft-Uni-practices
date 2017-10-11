public class Hacker
{
    private string username = "securityGod82";
    private string password = "mySuperSecretPassw0rd";

    public string Password
    {
        get => this.password;
        private set => this.password = value;
    }

    public string UserName
    {
        get => this.username;
        private set => this.username = value;
    }
}

