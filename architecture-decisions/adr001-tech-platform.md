# ADR 001: Tech Platform

2021-08-03

Two [constraints](../README.md#constraints) in particular provide the context:
- the client application must run on multiple operating systems
- use dotnet

## Decision

I will use [ASP.NET Core Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-5.0); more specifically, an [ASP.NET Core hosted Blazor WebAssembly (wasm) app](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-5.0#blazor-webassembly).
The client application will support PWA so that it can be installed.

## Status

Accepted

## Consequences
- Platform
  - I am familiar with dotnet, ASP.NET Core, and C#
  - I have to learn the Blazor framework
- wasm Hosting Model (ASP.NET)
  - wasm app (UI/client)
    - written as C#, rendered as HTML and CSS for wide browser support
    - backend serves the app to the browser
    - app has higher download size
      - dotnet.wasm which is the cross-platform runtime
      - assemblies
      - JS, CSS
    - restricted to the capabilities of the browser
    - PWA support
  - ASP.NET Core backend
    - will contain the Web API
      - required for accessing secure resources like those needing credentials
