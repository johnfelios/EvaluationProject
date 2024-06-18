namespace BlazorApp1.Services
{
    public interface IAppState
    {
        string Username { get; set; }
        void ClearUsername();
    }
}
