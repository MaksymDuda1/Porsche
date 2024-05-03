using Microsoft.Extensions.DependencyInjection;

namespace Porsche.Application.Models;

public class LazyInstance<T>(IServiceProvider serviceProvider) : Lazy<T>(serviceProvider.GetRequiredService<T>);