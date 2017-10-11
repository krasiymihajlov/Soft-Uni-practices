using System;
using System.Linq;
using System.Text;

namespace _04.Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public Smartphone(string[] phoneNumbers, string[] sites)
        {
            this.PhoneNumbers = phoneNumbers;
            this.Sites = sites;
        }

        string[] PhoneNumbers { get; set; }

        string[] Sites { get; set; }
        
        string IBrowseable.Browsing()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Sites.Length; i++)
            {
                if (this.Sites[i].Any(x => char.IsDigit(x)))
                {
                    sb.AppendLine($"Invalid URL!");
                    continue;
                }

                sb.AppendLine($"Browsing: {this.Sites[i]}!");
            }

            return sb.ToString().Trim();
        }

        string ICallable.CallNumbers()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.PhoneNumbers.Length; i++)
            {
                if (this.PhoneNumbers[i].Any(x => !char.IsDigit(x)))
                {
                    sb.AppendLine($"Invalid number!");
                    continue;
                }

                sb.AppendLine($"Calling... {this.PhoneNumbers[i]}");
            }

            return sb.ToString().Trim();
        }
    }
}
