using System.Collections.Generic;
using System;
namespace DataStructures
{
    namespace Heap
    {
      
        class BinaryNode<T> where T: IComparable<T>
        {
            public BinaryNode<T> head;
            public BinaryNode<T> leftnode;
            public BinaryNode<T> rightnode;
            public T obj;
            public int id;
        }

        class Heap<T> where T : IComparable<T>
        {
            private int numberofnodes = 0;
            private BinaryNode<T> root, last_added_node;
            private Clock clock = new Clock();
            private Iproperties<T> property;
            public Heap(bool MaxHeap = false)
            {
                
                if (MaxHeap)
                    property = new max_heap<T>();
                else
                    property = new min_heap<T>();

                root = new BinaryNode<T>() { head = null, id = 1 };
            }

            private BinaryNode<T> Head_traversal(string binary)
            {
                string path = binary.Remove(0, 1);
                BinaryNode<T> node_pointer = root;
                if (path.Length == 1)
                {
                    return node_pointer;
                }
                for (int i = 0; i < path.Length - 1; ++i)
                {
                    if (path[i] == '1')
                    {
                        node_pointer = node_pointer.rightnode;
                    }
                    else
                    {
                        node_pointer = node_pointer.leftnode;
                    }
                }
                return node_pointer;

            }
            private BinaryNode<T> Leaf_traversal(string binary)
            {
                string path = binary.Remove(0, 1);
                BinaryNode<T> node_pointer = root;
                for (int i = 0; i < path.Length; ++i)
                {
                    if (path[i] == '1')
                    {
                        node_pointer = node_pointer.rightnode;
                    }
                    else
                    {
                        node_pointer = node_pointer.leftnode;
                    }
                }
                return node_pointer;

            }

            public void Add(T item)
            {
                if (numberofnodes == 0)
                {
                    root.obj =item;
                    numberofnodes += 1;
                }
                else
                {

                    string binary = Convert.ToString(numberofnodes + 1, 2);
                    BinaryNode<T> tmp = Head_traversal(binary);
                    //Node to be Added
                    BinaryNode<T> added_node = new BinaryNode<T>() { head = tmp, obj=item, id = numberofnodes + 1 };

                    if (binary[binary.Length - 1] == '1')
                    {
                        tmp.rightnode = added_node;
                    }
                    else
                    {
                        tmp.leftnode = added_node;
                    }
                    //increment number of nodes
                    numberofnodes += 1;

                   property.arranger(added_node);
                    last_added_node = added_node;
                }

            }
            public void Add(List<T> node)
            {

               for (int j = 0; j < node.Count; ++j)
                 Add(node[j]);

            }
            public T ExtractRoot()
            {
                T root_val = root.obj;


                root.obj= last_added_node.obj;

                if (last_added_node.id != 1)
                {
                    if (numberofnodes % 2 == 0)
                    {
                        last_added_node.head.leftnode = null;
                    }
                    else
                    {
                        last_added_node.head.rightnode = null;
                    }
                    last_added_node = null;
                    numberofnodes -= 1;

                }

               property.propagation(root);
                last_added_node = Leaf_traversal(Convert.ToString(numberofnodes, 2));

                return root_val;
            }
          
            public int get_number_of_nodes()
            {
                return numberofnodes;
            }

        }
         interface Iproperties<T> where T: IComparable<T>{
             void arranger(BinaryNode<T> last_added_node);
             void propagation(BinaryNode<T> root);
            }
            
      
        
    }
}
