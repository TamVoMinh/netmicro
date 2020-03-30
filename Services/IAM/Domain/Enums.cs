namespace Nmro.IAM.Domain
{
    /// <summary>
    /// OpenID Connect subject types.
    /// </summary>
    public enum SubjectTypes
    {

        Global = 0,
        Ppid = 1
    }

    public enum AccessTokenType
    {
        Jwt = 0,
        Reference = 1
    }

    public enum TokenUsage
    {
        ReUse = 0,
        OneTimeOnly = 1
    }
    public enum TokenExpiration
    {
        Sliding = 0,
        Absolute = 1
    }


}
