# Cannot build in .NET 7 when referencing Microsoft.Extensions.Logging.AzureAppServices

I was trying to upgrade a couple of NuGet packages in my C# ASP.NET Core application, including **Microsoft.Extensions.Logging.AzureAppServices 8.0.0**.

I cannot compile with this NuGet. At least not with .NET 7.0. It fails with this error message:

> Startup.cs(18,18): error CS0121: The call is ambiguous
between the following methods or properties: 'Microsoft.Extensions.DependencyInjection.OptionsBuilderExtensions.Validat
eOnStart<TOptions>(Microsoft.Extensions.Options.OptionsBuilder<TOptions>)' and 'Microsoft.Extensions.DependencyInjectio
n.OptionsBuilderExtensions.ValidateOnStart<TOptions>(Microsoft.Extensions.Options.OptionsBuilder<TOptions>)'

The code line it complains about looks like this: 

```
services.AddOptions<MyOptions>()
    .Bind(Configuration.GetSection(MyOptions.Name))
    .ValidateDataAnnotations()
    .ValidateOnStart();
```

I have tried to rewrite this to call the method in **Microsoft.Extensions.DependencyInjection.OptionsBuilderExtensions** explicitly. That did not help. I haven't found any workaround that lets me compile this against .NET 7.0.