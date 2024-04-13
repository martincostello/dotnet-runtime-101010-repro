# dotnet/runtime#101010 Repro

Repro for [dotnet/runtime#101010](https://github.com/dotnet/runtime/issues/101010).

To reproduce the issue, run the following commands:

```console
dotnet publish
./artifacts/publish/dotnet-runtime-101010-repro/release/repro
```

The output should be similar to the following:

```console
> dotnet publish
> ./artifacts/publish/dotnet-runtime-101010-repro/release/repro
Restore complete (0.6s)
You are using a preview version of .NET. See: https://aka.ms/dotnet-support-policy
  dotnet-runtime-101010-repro succeeded (13.2s) → artifacts\publish\dotnet-runtime-101010-repro\release\

Build succeeded in 14.0s
Unhandled exception. System.TypeInitializationException: A type initializer threw an exception. To determine which type, inspect the InnerException's StackTrace property.
 ---> System.NotSupportedException: Cannot retrieve a MethodInfo for this delegate because the method it targeted (Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetService(IServiceProvider, Type, Type, Boolean, Object)) was not enabled for metadata.
   at Internal.Reflection.Extensions.NonPortable.DelegateMethodInfoRetriever.GetDelegateMethodInfo(Delegate) + 0x24e
   at Microsoft.Extensions.DependencyInjection.ActivatorUtilities..cctor() + 0xd7
   at System.Runtime.CompilerServices.ClassConstructorRunner.EnsureClassConstructorRun(StaticClassConstructionContext*) + 0xb9
   --- End of inner exception stack trace ---
   at System.Runtime.CompilerServices.ClassConstructorRunner.EnsureClassConstructorRun(StaticClassConstructionContext*) + 0x145
   at System.Runtime.CompilerServices.ClassConstructorRunner.CheckStaticClassConstructionReturnGCStaticBase(StaticClassConstructionContext*, Object) + 0xd
   at Microsoft.Extensions.DependencyInjection.ActivatorUtilities.TryFindPreferredConstructor(Type, Type[], ActivatorUtilities.ConstructorInfoEx[], ConstructorInfo&, Nullable`1[]&) + 0x11a
   at Microsoft.Extensions.DependencyInjection.ActivatorUtilities.FindApplicableConstructor(Type, Type[], ActivatorUtilities.ConstructorInfoEx[], ConstructorInfo&, Nullable`1[]&) + 0x36
   at Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateFactoryReflection(Type, Type[]) + 0x44
   at System.Threading.LazyInitializer.EnsureInitializedCore[T](T&, Boolean&, Object&, Func`1) + 0x43
   at Microsoft.Extensions.Http.DefaultTypedHttpClientFactory`1.Cache.get_Activator() + 0x4c
   at Microsoft.Extensions.Http.DefaultTypedHttpClientFactory`1.CreateClient(HttpClient) + 0x25
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitDisposeCache(ServiceCallSite, RuntimeResolverContext) + 0xe
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite, TArgument) + 0xb7
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.Resolve(ServiceCallSite, ServiceProviderEngineScope) + 0x3d
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(ServiceIdentifier, ServiceProviderEngineScope) + 0xa3
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(Type) + 0x2b
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService(IServiceProvider, Type) + 0x57
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService[T](IServiceProvider) + 0x29
   at Program.<<Main>$>d__0.MoveNext() + 0x111
--- End of stack trace from previous location ---
   at Program.<Main>(String[] args) + 0x24
```
