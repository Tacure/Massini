
using System.Runtime.InteropServices;
using System.Text;

namespace Massini.Core.Interop
{
    public unsafe static class UnsafeString
    {
        /// <summary>
        /// Encodes a managed string into UTF8 enconding and stores it on unmanaged memory.
        /// </summary>
        /// <remarks> Use <see cref="UnsafeMemory.Free(void*)"/> to free the memory. </remarks>
        public static UnsafeAlloc StringToPtrUTF8(string i_str)
        {
            // Get the required buffer size.
            int byteCount = Encoding.UTF8.GetByteCount(i_str);

            // Add 1 for the null terminator '\0'
            nuint totalSize = (nuint)byteCount + 1;

            // Create buffer.
            UnsafeAlloc bufferAlloc = UnsafeMemory.Alloc(totalSize);
            byte* buffer = (byte*)bufferAlloc.ToRawPtr();
            Span<byte> destination = new(buffer, byteCount);

            // Encode the string.
            Encoding.UTF8.GetBytes(i_str, destination);

            // Add the null terminator.
            buffer[byteCount] = 0;

            return bufferAlloc;
        }

        /// <summary>
        /// Takes a pointer to an UTF8 encoded string and decodes it into a managed string.
        /// </summary>
        /// <param name="i_ptr"></param>
        /// <returns></returns>
        public static string? PtrToStringUTF8(void* i_ptr)
        {
            return Marshal.PtrToStringUTF8((IntPtr)i_ptr);
        }
    }
}
