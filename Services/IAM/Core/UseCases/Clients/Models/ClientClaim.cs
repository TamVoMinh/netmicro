using System;
using System.Security.Claims;
namespace Nmro.IAM.Core.UseCases.Clients.Models
{
    public class ClientClaim
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public string ValueType { get; set; } = ClaimValueTypes.String;

        public ClientClaim(){}

        public ClientClaim(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public ClientClaim(string type, string value, string valueType)
        {
            Type = type;
            Value = value;
            ValueType = valueType;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Value.GetHashCode();
                hash = hash * 23 + Type.GetHashCode();
                hash = hash * 23 + ValueType.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj is ClientClaim c)
            {
                return (string.Equals(Type, c.Type, StringComparison.Ordinal) &&
                        string.Equals(Value, c.Value, StringComparison.Ordinal) &&
                        string.Equals(ValueType, c.ValueType, StringComparison.Ordinal));
            }
            return false;
        }
    }
}
