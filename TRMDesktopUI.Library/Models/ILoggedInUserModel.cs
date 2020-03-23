using System;

namespace SWADesktopUI.Library.Models
{
    public interface ILoggedInUserModel
    {
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Id { get; set; }
        string Token { get; set; }
        DateTime CreatedDate { get; set; }
    }
}