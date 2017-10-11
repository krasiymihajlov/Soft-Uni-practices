using System;
using System.Text;

namespace _03.Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }
        public string Model { get { return "488-Spider"; } }

        public string Driver { get; set; }

        private string UseBrackes()
        {
            return "Brakes!";
        }

        private string PushTheGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Model).Append("/").Append(this.UseBrackes() + "/").Append(this.PushTheGasPedal() + "/").AppendLine(this.Driver);
            return sb.ToString().Trim();
        }
    }
}
