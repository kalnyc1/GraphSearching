using System;
using System.Collections.Generic;

namespace TraverseSearching
{
    class Program
    {
        /// <summary>
        /// Node class
        /// </summary>
        public class Node
        {
            // Node value
            public int m_nValue { get; set; }

            // Any neighboring nodes
            public IList<Node> m_listNeighborNodes { get; set; }

            // Constructor
            public Node()
            {
                m_listNeighborNodes = new List<Node>();
            }
        }

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main( string[] args )
        {
            // Create graph like so
            //          1
            //        / | \
            //       2  3  4
            //      /  / \  \
            //     5  6   7  8
            //     |  |
            //     9  10

            // Top node
            Node objNode = new Node()
            {
                m_nValue = 1
            };

            // Add neighbor nodes
            objNode.m_listNeighborNodes.Add(
                new Node()
                {
                    // Set value
                    m_nValue = 2,

                    // Add neighbor nodes
                    m_listNeighborNodes = new List<Node>()
                    {
                        new Node()
                        {
                            m_nValue = 5,

                            m_listNeighborNodes = new List<Node>()
                            {
                                new Node()
                                {
                                    m_nValue = 9
                                }
                            }
                        }
                    }
                } );

            objNode.m_listNeighborNodes.Add(
                new Node()
                {
                    m_nValue = 3,

                    m_listNeighborNodes = new List<Node>()
                    {
                        new Node()
                        {
                            m_nValue = 6,

                            m_listNeighborNodes = new List<Node>()
                            {
                                new Node()
                                {
                                    m_nValue = 10
                                }
                            }
                        },
                        new Node()
                        {
                            m_nValue = 7
                        }
                    }
                } );

            objNode.m_listNeighborNodes.Add(
                new Node()
                {
                    m_nValue = 4,

                    m_listNeighborNodes = new List<Node>()
                    {
                        new Node()
                        {
                            m_nValue = 8
                        }
                    }
                } );

            Console.WriteLine( "Breadth First Search ------------------------" );

            // Breadth First Search uses a queue - FIFO.
            // Each neighboring node is added to the queue, thus when
            // dequeued we stay at the same level until it is completed. 
            Queue<Node> objQueue = new Queue<Node>();
            List<int> listVisited = new List<int>();

            // Set top node as visited and add to queue
            listVisited.Add( objNode.m_nValue );
            objQueue.Enqueue( objNode );

            while ( objQueue.Count > 0 )
            {
                Node objNodeItem = objQueue.Dequeue();
                Console.WriteLine( $"Dequeued: {objNodeItem.m_nValue}" );

                // Has neighbor nodes
                if ( objNodeItem.m_listNeighborNodes.Count > 0 )
                {
                    Console.WriteLine( objNodeItem.m_nValue );

                    foreach ( Node objNeighborNode in objNodeItem.m_listNeighborNodes )
                    {
                        if ( !listVisited.Contains( objNeighborNode.m_nValue ) )
                        {
                            // Set node as visited and add to queue
                            listVisited.Add( objNeighborNode.m_nValue );
                            objQueue.Enqueue( objNeighborNode );
                            Console.WriteLine( $"Enqueued: {objNeighborNode.m_nValue}" );
                        }
                    }
                }
                // No neighbor nodes
                else
                {
                    Console.WriteLine( objNodeItem.m_nValue );
                }
            }

            Console.WriteLine();
            Console.WriteLine( "Depth First Search ------------------------" );

            // Depth First Search uses a stack - LIFO.
            // Each neighboring node is pushed on to the stack, thus when
            // popped we go to a lower level each time until completed. 
            Stack<Node> objStack = new Stack<Node>();
            listVisited.Clear();

            // Set top node as visited and push onto stack
            listVisited.Add( objNode.m_nValue );
            objStack.Push( objNode );

            while ( objStack.Count > 0 )
            {
                Node objNodeItem = objStack.Pop();
                Console.WriteLine( $"StackPopped: {objNodeItem.m_nValue}" );

                // Has neighbor nodes
                if ( objNodeItem.m_listNeighborNodes.Count > 0 )
                {
                    Console.WriteLine( objNodeItem.m_nValue );

                    foreach ( Node objNeighborNode in objNodeItem.m_listNeighborNodes )
                    {
                        if ( !listVisited.Contains( objNeighborNode.m_nValue ) )
                        {
                            // Set node as visited and push onto stack
                            listVisited.Add( objNeighborNode.m_nValue );
                            objStack.Push( objNeighborNode );
                            Console.WriteLine( $"StackPushed: {objNeighborNode.m_nValue}" );
                        }
                    }
                }
                // No neighbor nodes
                else
                {
                    Console.WriteLine( objNodeItem.m_nValue );
                }
            }
        }
    }
}
