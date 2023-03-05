using MathApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MathApi.Tests.Services;

public class MathServiceTests
{
    private readonly ServiceProvider services;

    public MathServiceTests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<IMathService, MathService>();

        this.services = serviceCollection.BuildServiceProvider();
    }

    [Fact]
    public async Task ShouldAddTwoNumbersCorrectly()
    {
        // Given
        var mathService = services.GetRequiredService<IMathService>();
        var a = 1;
        var b = 2;

        // When
        var result = await mathService.AddAsync(a, b, CancellationToken.None);

        // Then
        Assert.Equal(3, result);
    }

    [Theory]
    [InlineData(long.MaxValue, 1)]
    [InlineData(long.MinValue, -1)]
    public async Task ThrowsOverflowExceptionWhenNotInRange(long a, long b)
    {
        // Given
        var mathService = services.GetRequiredService<IMathService>();

        // When
        var task = async () => await mathService.AddAsync(a, b, CancellationToken.None);

        // Then
        await Assert.ThrowsAsync<OverflowException>(task);
    }
}