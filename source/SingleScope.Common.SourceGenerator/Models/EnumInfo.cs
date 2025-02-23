using System.Collections.Generic;

namespace SingleScope.Common.SourceGenerator.Models
{
    internal class EnumInfo
    {
        public string NameSpace { get; }

        public string EnumName { get; }

        public List<EnumMemberInfo> Members { get; }

        public EnumInfo(string nameSpace, string enumName, List<EnumMemberInfo> members)
        {
            NameSpace = nameSpace;
            EnumName = enumName;
            Members = members;
        }
    }
}
