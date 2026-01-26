namespace Bank.UI.Models.Profile.Response
{
    public record UserProfileDetailsResponse(bool Flag, string Message = null!, int UserId = 0, string? Name = null, string? Email = null, string? Mobile = null, string? Address = null, DateTime? DateOfBirth = null, string? Gender = null);
}
