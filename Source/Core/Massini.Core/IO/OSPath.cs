
namespace Massini.Core.IO
{
    public readonly struct OSPath : IEquatable<OSPath>
    {
        public OSPath(string i_path)
        {
            if (i_path.Length == 0)
            {
                m_path = string.Empty;
                return;
            }

            string path = i_path.Replace(ALT_SEPARATOR, SEPARATOR);

            // Remove duplicate separators.
            string[] tokens = path.Split(SEPARATOR);
            tokens = [.. tokens.Where(i_token => i_token != string.Empty)];
            m_path = string.Join(SEPARATOR, tokens);
        }

        public static implicit operator OSPath(string i_path)
            => new(i_path);

        public static implicit operator string(OSPath i_path)
            => i_path.m_path;

        public static bool operator ==(OSPath i_path1, OSPath i_path2)
            => i_path1.m_path == i_path2.m_path;

        public static bool operator !=(OSPath i_path1, OSPath i_path2)
            => i_path1.m_path == i_path2.m_path;

        /// <summary>
        /// Combine two paths.
        /// </summary>
        /// <param name="i_path1"></param>
        /// <param name="i_path2"></param>
        /// <returns></returns>
        public static OSPath operator /(OSPath i_path1, OSPath i_path2)
            => new(Path.Combine(i_path1.m_path, i_path2.m_path));

        public const char SEPARATOR = '/';

        public const char ALT_SEPARATOR = '\\';

        public static OSPath Empty => new(string.Empty);

        public static readonly IEnumerable<char> InvalidPathChars = [.. Path.GetInvalidPathChars()];

        /// <summary>
        /// Returns the path with backslashes.
        /// </summary>
        public string WindowsStylePath => m_path.Replace(SEPARATOR, ALT_SEPARATOR);

        public OSPath FullPath => Path.GetFullPath(m_path);

        public string Name => Path.GetFileName(m_path);

        public string Extension => Path.GetExtension(m_path);

        public OSPath Parent => new(Path.GetDirectoryName(m_path) ?? string.Empty);

        public bool IsValid
        {
            get
            {
                foreach (char c in m_path)
                {
                    if (InvalidPathChars.Contains(c))
                        return false;
                }
                return true;
            }
        }

        public bool IsEmpty => m_path?.Length == 0;

        public static OSPath Make(params string[] i_paths)
        {
            return new(Path.Combine(i_paths));
        }

        public bool IsChildOf(OSPath i_parent)
        {
            //return m_path.StartsWith(i_parent.m_path);

            // Based on IsChildOf method from: https://github.com/meziantou/Meziantou.Framework/blob/main/src/Meziantou.Framework.FullPath/FullPath.cs.

            if (IsEmpty)
                throw new InvalidOperationException("Path is empty");
            if (i_parent.IsEmpty)
                throw new ArgumentException("Root path is empty", nameof(i_parent));

            if (m_path.Length <= i_parent.m_path.Length)
                return false;

            if (!m_path.StartsWith(i_parent.m_path, StringComparison.Ordinal))
                return false;

            // rootpath: /a/b
            // current:  /a/b/c => true
            // current:  /a/b/  => false
            // current:  /a/bc  => false
            return m_path[i_parent.m_path.Length] == SEPARATOR && m_path.Length > i_parent.m_path.Length + 1;
        }

        public void ThrowIfInvalid()
        {
            if (!IsValid)
            {
                throw new Exception($"The path [{m_path}] contains invalid characters.");
            }
        }

        /// <summary>
        /// Returns the path as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return m_path;
        }

        public override bool Equals(object? i_obj)
        {
            if (i_obj is OSPath path)
            {
                return m_path == path.m_path;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return m_path.GetHashCode();
        }

        public bool Equals(OSPath i_other)
        {
            return m_path == i_other.m_path;
        }

        private readonly string m_path;
    }
}
