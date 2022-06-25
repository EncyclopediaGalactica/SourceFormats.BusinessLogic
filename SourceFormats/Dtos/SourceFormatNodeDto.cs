﻿namespace EncyclopediaGalactica.SourceFormats.Dtos;

using System.Text.Json.Serialization;

public class SourceFormatNodeDto
{
    public SourceFormatNodeDto()
    {
    }

    public SourceFormatNodeDto(string name)
    {
        Name = name;
    }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("is_root_node")]
    public int IsRootNode { get; set; }
}