using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultivariateTesting.SplitDefinitions
{
    public static class SplitDefinition
    {
        //Split names/keys
        public const string SPLIT_FOUNDON = "FoundOnSplit";
        public const string SPLIT_QUALIFYING_TAGS = "QualifyingTagsSplit";
        public const string SPLIT_VIEWSPLIT = "ViewSplit";
        public const string SPLIT_EMPTYSEARCHSPLIT = "EmptySearchSplit";

        //Experience names/keys
        public const string EXPERIENCE_DEFAULT = "Default";
        public const string EXPERIENCE_CONTROL = "Control";
        public const string EXPERIENCE_FOUNDON = "FoundOn";
        public const string EXPERIENCE_QUALIFYING_TAGS = "QualifyingTags";
        public const string EXPERIENCE_NEWSADS = "NewAds";
    }
}
