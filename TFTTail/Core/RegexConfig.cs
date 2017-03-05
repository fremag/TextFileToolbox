using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace TFT.Tail.Core
{
    public enum FilterMode { KeepIfMatch, IgnoreIfMatch }

    public class RegexConfig
    {
        public string Name { get; set; }
        public bool IgnoreCase { get; set; }
        private string regex;
        public string Regex
        {
            get
            {
                return regex;
            }

            set
            {
                regex = value;
                var options = RegexOptions.Compiled;
                if( IgnoreCase )
                {
                    options |= RegexOptions.IgnoreCase;
                }
                CompiledRegex = new Regex(regex, options);
            }
        }

        [Browsable(false)]
        [XmlIgnore]
        public Regex CompiledRegex { get; private set; }
    }
}
