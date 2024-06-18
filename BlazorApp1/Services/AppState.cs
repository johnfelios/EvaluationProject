namespace BlazorApp1.Services
{

    ///Use: Holds Username, AccountId for the session
    public class AppState : IAppState
    {
        public string Username { get; set; }
        public int AccountId { get; set; }

        //Used on Logout
        public void ClearAppState()
        {
            Username = null;
            AccountId = 0;

        }
    }
}
