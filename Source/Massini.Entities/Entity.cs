
using Massini.Collections;

namespace Massini.Entities
{
    public sealed class Entity : IResettable, IComparable<Entity>
    {
        public Table Table => in_table!;

        public int CompareTo(Entity? i_other)
        {
            if (i_other == null) return 1;
            return in_row.CompareTo(i_other.in_row);
        }

        public void TryReset()
        {
            in_row = -1;
            in_table = null;
        }

        public override string ToString()
        {
            return $"Row: {in_row} Components: {string.Join(", ", in_table?.Components.Select(GetFormattedGenericTypeName) ?? ["NONE"])}";
        }

        // Row in the table.
        internal int in_row = -1;
        internal Table? in_table = null;

        private static string GetFormattedGenericTypeName(Type i_type)
        {
            if (!i_type.IsGenericType)
            {
                return i_type.Name;
            }

            // Get the generic type definition (e.g., List<>)
            Type genericTypeDefinition = i_type.GetGenericTypeDefinition();
            string baseName = genericTypeDefinition.Name!.Split('`')[0]; // Remove `1, `2 etc.

            // Get the generic arguments (e.g., int for List<int>)
            Type[] genericArguments = i_type.GetGenericArguments();

            string[] argumentNames = new string[genericArguments.Length];

            for (int i = 0; i < genericArguments.Length; i++)
            {
                argumentNames[i] = GetFormattedGenericTypeName(genericArguments[i]);
            }

            return $"{baseName}<{string.Join(", ", argumentNames)}>";
        }
    }
}
