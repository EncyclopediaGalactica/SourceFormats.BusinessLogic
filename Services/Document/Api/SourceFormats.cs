namespace EncyclopediaGalactica.SourceFormats.Api;

public struct SourceFormats
{
    public const string Route = "/api/sourceformats";

    public struct SourceFormatNode
    {
        public const string Route = SourceFormats.Route + "/sourceformatnode";

        public const string Add = "/add";
        public const string GetAll = "/get";
        public const string Update = "/update";
        public const string Delete = "/delete";
        public const string GetById = "/getbyid";
        public const string AddChildToParent = "/addchildtoparent";
    }

    public struct Document
    {
        public const string Route = SourceFormats.Route + "/document";

        public const string Add = "/add";
        public const string GetById = "/getbyid";
    }
}