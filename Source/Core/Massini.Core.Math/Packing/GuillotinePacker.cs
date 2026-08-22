
using Massini.Core.Math.Primitives;

namespace Massini.Core.Math.Packing
{
    /// <summary>
    /// Guillotine Rectangle Packing. Inspired by: https://www.david-colson.com/2020/03/10/exploring-rect-packing.html
    /// </summary>
    /// <remarks>
    /// The coordinate system takes to top left corner as origin (0, 0). X axis increases to the right, Y axis increases to the bottom.
    /// </remarks>
    public class GuillotinePacker
    {
        /// <summary>
        /// Creates a new instance with the specified size.
        /// </summary>
        /// <param name="i_size"></param>
        public GuillotinePacker(Vec2<uint> i_size)
        {
            if (i_size.X == 0 || i_size.Y == 0)
            {
                throw new Exception("Invalid size.");
            }

            // Our initial node is the entire space.
            m_binaryTree.Add(new Node { p_position = Vec2<uint>.Zero, p_size = i_size });

            m_size = i_size;
        }

        /// <summary>
        /// Efficiency of the packing. 1.0 is best, 0.0 is worst.
        /// </summary>
        /// <returns>
        /// Space area divided by total area of all rectangles.
        /// </returns>
        public float Efficiency => (float)UsedArea / TotalArea;

        /// <summary>
        /// Space size.
        /// </summary>
        public Vec2<uint> Size => m_size;

        /// <summary>
        /// Returns the number of rectangles.
        /// </summary>
        public int Count => m_packedCount;

        /// <summary>
        /// Returns the used area.
        /// </summary>
        public uint UsedArea => m_usedArea;

        /// <summary>
        /// Returns the total area.
        /// </summary>
        public uint TotalArea => m_size.X * m_size.Y;

        /// <summary>
        /// Returns the free area.
        /// </summary>
        public uint FreeArea => TotalArea - UsedArea;

        /// <summary>
        /// Times the space has been expanded.
        /// </summary>
        public uint ResizeCount => m_resizeCount;

        /// <summary>
        /// Expands the available space.
        /// </summary>
        /// <param name="i_deltaSize">Additional space to add.</param>
        public void Expand(Vec2<uint> i_deltaSize)
        {
            uint oldX = m_size.X;
            uint oldY = m_size.Y;
            m_size.X += i_deltaSize.X;
            m_size.Y += i_deltaSize.Y;

            Node newSmallerNode = new();
            Node newLargerNode = new();

            if (i_deltaSize.Y * oldX > i_deltaSize.X * oldY)
            {
                // The lesser split here will be the top right.
                newSmallerNode.p_position.X = oldX;
                newSmallerNode.p_position.Y = 0;
                newSmallerNode.p_size.X = i_deltaSize.X;
                newSmallerNode.p_size.Y = oldY;

                newLargerNode.p_position.X = 0;
                newLargerNode.p_position.Y = oldY;
                newLargerNode.p_size.X = m_size.X;
                newLargerNode.p_size.Y = i_deltaSize.Y;
            }
            else
            {
                // The lesser split here will be the bottom left.
                newSmallerNode.p_position.X = 0;
                newSmallerNode.p_position.Y = oldY;
                newSmallerNode.p_size.X = oldX;
                newSmallerNode.p_size.Y = i_deltaSize.Y;

                newLargerNode.p_position.X = oldX;
                newLargerNode.p_position.Y = 0;
                newLargerNode.p_size.X = i_deltaSize.X;
                newLargerNode.p_size.Y = m_size.Y;
            }

            m_binaryTree.Add(newLargerNode);
            m_binaryTree.Add(newSmallerNode);

            m_resizeCount++;
        }

        /// <summary>
        /// Packs the specified rectangle.
        /// </summary>
        /// <remarks>
        /// Use <see cref="Expand"/> to expand the available space if packing fails.
        /// </remarks>
        /// <param name="i_size"></param>
        /// <param name="o_position">Position of the packed rectangle.</param>
        /// <returns>Returns true if was packed, false otherwise.</returns>
        public bool Pack(Vec2<uint> i_size, out Vec2<uint> o_position)
        {
            o_position = Vec2<uint>.Zero;

            if (i_size.X == 0 || i_size.Y == 0)
            {
                throw new Exception("Invalid size.");
            }

            // Check if there is enough space.
            if (i_size.X * i_size.Y > FreeArea)
            {
                return false;
            }

            // Binary tree packing algorithm.

            // Iterate over nodes.
            bool done = false;
            //for (int i = m_binaryTree.Count - 1; i >= 0 && !done; i--)
            for (int i = 0; i < m_binaryTree.Count && !done; i++)
            {
                Node node = m_binaryTree[i];

                // If the node is big enough, we've found a suitable spot for our rectangle.
                if (node.p_size.X >= i_size.X && node.p_size.Y >= i_size.Y) 
                {
                    o_position.X = node.p_position.X;
                    o_position.Y = node.p_position.Y;

                    // Split the rectangle, calculating the unused space.
                    uint remainingX = node.p_size.X - i_size.X;
                    uint remainingY = node.p_size.Y - i_size.Y;

                    Node newSmallerNode = new();
                    Node newLargerNode = new();

                    // We can work out which way we need to split by checking which
                    // remaining dimension is larger.
                    if (remainingY > remainingX)
                    {
                        // The lesser split here will be the top right.
                        newSmallerNode.p_position.X = node.p_position.X + i_size.X;
                        newSmallerNode.p_position.Y = node.p_position.Y;
                        newSmallerNode.p_size.X = remainingX;
                        newSmallerNode.p_size.Y = i_size.Y;

                        newLargerNode.p_position.X = node.p_position.X;
                        newLargerNode.p_position.Y = node.p_position.Y + i_size.Y;
                        newLargerNode.p_size.X = node.p_size.X;
                        newLargerNode.p_size.Y = remainingY;
                    }
                    else 
                    {
                        // The lesser split here will be the bottom left.
                        newSmallerNode.p_position.X = node.p_position.X;
                        newSmallerNode.p_position.Y = node.p_position.Y + i_size.Y;
                        newSmallerNode.p_size.X = i_size.X;
                        newSmallerNode.p_size.Y = remainingY;

                        newLargerNode.p_position.X = node.p_position.X + i_size.X;
                        newLargerNode.p_position.Y = node.p_position.Y;
                        newLargerNode.p_size.X = remainingX;
                        newLargerNode.p_size.Y = node.p_size.Y;
                    }

                    // Removing the node we're using up.
                    m_binaryTree.RemoveAt(i);

                    // Adding the new nodes. Smaller node last.
                    m_binaryTree.Add(newLargerNode);
                    m_binaryTree.Add(newSmallerNode);

                    done = true;
                }
            }

            if (!done)
            {
                return false;
            }

            // Update used area.
            m_usedArea += i_size.X * i_size.Y;
            m_packedCount++;

            return true;
        }

        private struct Node
        {
            public Vec2<uint> p_size;
            /// <summary>
            /// Top left corner.
            /// </summary>
            public Vec2<uint> p_position;
        }

        private uint m_usedArea = 0;
        private int m_packedCount = 0;
        private Vec2<uint> m_size;
        private uint m_resizeCount = 0;
        private readonly List<Node> m_binaryTree = [];
    }
}
