namespace BlazorApp1.Services
{
    public class AppState : IAppState
    {
        public string Username { get; set; }
        public int AccountId { get; set; }

        public void ClearUsername()
        {
            Username = null;
        }
    }
}
