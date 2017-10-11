namespace _01HarestingFields
{
    using System;
    using System.Reflection;
    using System.Text;

    public class RichSoilLand
    {
        public string GetPrivateMethods()
        {
            StringBuilder sb = new StringBuilder();
            Type type = typeof(HarvestingFields);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in fields)
            {
                if (field.IsPrivate)
                {
                    int fieldIndex = $"{field.FieldType}".LastIndexOf(".");
                    string fieldType = $"{field.FieldType}".Substring(fieldIndex + 1);

                    sb.AppendLine($"{Accessmodifier(field)} {fieldType} {field.Name}");
                }
            }

            return sb.ToString().Trim();
        }

        public string GetPublicMethods()
        {
            StringBuilder sb = new StringBuilder();
            Type type = typeof(HarvestingFields);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                if (field.IsPublic)
                {
                    int fieldIndex = $"{field.FieldType}".LastIndexOf(".");
                    string fieldType = $"{field.FieldType}".Substring(fieldIndex + 1);

                    sb.AppendLine($"{Accessmodifier(field)} {fieldType} {field.Name}");
                }
            }

            return sb.ToString().Trim();
        }

        public string GetProtectedMethods()
        {
            StringBuilder sb = new StringBuilder();
            Type type = typeof(HarvestingFields);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in fields)
            {
                if (!field.IsPrivate && !field.IsPublic)
                {
                    int fieldIndex = $"{field.FieldType}".LastIndexOf(".");
                    string fieldType = $"{field.FieldType}".Substring(fieldIndex + 1);

                    sb.AppendLine($"{Accessmodifier(field)} {fieldType} {field.Name}");
                }
            }

            return sb.ToString().Trim();
        }

        public string GetAllMethods()
        {
            StringBuilder sb = new StringBuilder();
            Type type = typeof(HarvestingFields);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {
                int fieldIndex = $"{field.FieldType}".LastIndexOf(".");
                string fieldType = $"{field.FieldType}".Substring(fieldIndex + 1);

                sb.AppendLine($"{Accessmodifier(field)} {fieldType} {field.Name}");
            }

            return sb.ToString().Trim();
        }

        private string Accessmodifier(FieldInfo fieldInfo)
        {
            if (fieldInfo.IsPrivate)
            {
                return "private";
            }

            if (fieldInfo.IsFamily)
            {
                return "protected";
            }

            if (fieldInfo.IsAssembly)
            {
                return "internal";
            }

            if (fieldInfo.IsPublic)
            {
                return "public";
            }

            return "Error";
        }
    }
}
