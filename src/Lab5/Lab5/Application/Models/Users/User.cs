namespace Lab5.Application.Models.Users;

public record User(long Id, string Name, string Salt, string PasswordHash, UserRole Role);