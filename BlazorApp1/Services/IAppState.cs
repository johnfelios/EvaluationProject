﻿namespace BlazorApp1.Services
{
    public interface IAppState
    {
        string Username { get; set; }
        int AccountId { get; set; }
        void ClearAppState();
    }
}
