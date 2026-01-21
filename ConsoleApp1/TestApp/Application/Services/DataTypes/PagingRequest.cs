namespace TestApp.Infrastructure.DataTypes;

public record PagingRequest(int PageNum = 1, int PageSize = 5);