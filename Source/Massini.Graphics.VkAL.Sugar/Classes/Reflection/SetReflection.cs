
namespace Massini.Graphics.VkAL.Sugar.Classes.Reflection
{
    public class SetReflection
    {
        public required uint SetNumber { get; init; }   
        public required SetBindingReflection[] Bindings { get; init; }

        public SetBindingReflection? GetBinding(string i_name)
        {
            return Bindings.FirstOrDefault(b => b != null && b.Name == i_name, null);
        }

        public SetBindingReflection? GetBinding(uint i_bindingNumber)
        {
            return Bindings.FirstOrDefault(b => b != null && b.BindingNumber == i_bindingNumber, null);
        }
    }   
}
