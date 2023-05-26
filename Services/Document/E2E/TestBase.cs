namespace EncyclopediaGalactica.SourceFormats.E2E;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using EncyclopediaGalactica.Sdk.Core;
using EncyclopediaGalactica.Sdk.Core.Interfaces;
using Host.RestApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Sdk;
using Sdk.Document;
using Sdk.Interfaces;
using Sdk.SourceFormatNode;

public class TestBase : SourceFormatWebApplicationFactory<Program>
{
    protected readonly HttpClient _httpClient;
    protected readonly ISourceFormatsSdk SourceFormatsSdk;
    protected readonly SourceFormatWebApplicationFactory<Program> WebApplicationFactory;

    public TestBase()
    {
        WebApplicationFactory = new SourceFormatWebApplicationFactory<Program>();
        _httpClient = WebApplicationFactory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
        _httpClient.BaseAddress = new Uri("http://localhost");
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        ISdkCore sdkCore = new SdkCore(_httpClient);
        ISourceFormatNodeSdk sourceFormatNodeSdk = new SourceFormatNodeSdk(sdkCore);
        IDocumentsSdk documentsSdk = new DocumentSdk(sdkCore);
        SourceFormatsSdk = new SourceFormatsSdk(sourceFormatNodeSdk, documentsSdk);
    }
}