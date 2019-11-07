using System;
 namespace DataStructures
{
    namespace Heap
    {
  class min_heap<T>:Iproperties<T> where T :IComparable<T>
        {

            //Min Heap
            public void arranger(BinaryNode<T> last_added_node)
            {
                bool Flag = true;
                while (Flag)
                {
                    //if the parent is null stop this mean we are at the root
                    if (last_added_node.head != null)
                    {
                             //last_added_node.head.obj > last_added_node.obj
                        if (last_added_node.head.obj.CompareTo(last_added_node.obj) == 1 )
                        {
                            T tmp = last_added_node.head.obj;
                            last_added_node.head.obj = last_added_node.obj;
                            last_added_node.obj = tmp;
                            //change last_added_node to head
                            //so we can go up in the tree
                            last_added_node = last_added_node.head;
                        }
                        else
                            Flag = false;
                    }
                    else
                        Flag = false;
                }

            }
            public void propagation(BinaryNode<T> root)
            {
                //always propagate from the root
                BinaryNode<T> node_pointer = root;
                bool Flag = true;
                T val;
                while (Flag)
                {
                    if (node_pointer.leftnode != null && node_pointer.rightnode != null)
                    {       // node_pointer.leftnode.obj < node_pointer.rightnode.obj
                        if (node_pointer.leftnode.obj.CompareTo(node_pointer.rightnode.obj) ==-1)
                        {
                            if (node_pointer.leftnode.obj.CompareTo(node_pointer.obj) ==-1)
                            {
                                val = node_pointer.obj;
                                node_pointer.obj = node_pointer.leftnode.obj;
                                node_pointer.leftnode.obj = val;

                                node_pointer = node_pointer.leftnode;
                            }
                            else
                            {
                                Flag = false;
                            }
                        }
                            //node_pointer.rightnode.obj <= node_pointer.obj
                        else if (node_pointer.rightnode.obj.CompareTo(node_pointer.obj) == -1 || node_pointer.rightnode.obj.CompareTo(node_pointer.obj)== 0)
                        {

                            val = node_pointer.obj;
                            node_pointer.obj = node_pointer.rightnode.obj;
                            node_pointer.rightnode.obj = val;

                            node_pointer = node_pointer.rightnode;

                        }
                        else
                        {
                            Flag = false;
                        }
                    }
                    else if (node_pointer.leftnode != null && node_pointer.rightnode == null)
                    {      //node_pointer.leftnode.obj < node_pointer.obj
                        if (node_pointer.leftnode.obj.CompareTo( node_pointer.obj) == -1)
                        {
                            val = node_pointer.obj;
                            node_pointer.obj = node_pointer.leftnode.obj;
                            node_pointer.leftnode.obj = val;

                            node_pointer = node_pointer.leftnode;
                        }
                        else
                        {
                            Flag = false;
                        }
                    }
                    else if (node_pointer.leftnode == null && node_pointer.rightnode != null)
                    {    //node_pointer.rightnode.obj <=node_pointer.obj
                        if (node_pointer.rightnode.obj.CompareTo (node_pointer.obj) == -1 || node_pointer.rightnode.obj.CompareTo (node_pointer.obj) == 0)
                        {
                            val = node_pointer.obj;
                            node_pointer.obj = node_pointer.rightnode.obj;
                            node_pointer.rightnode.obj = val;

                            node_pointer = node_pointer.rightnode;
                        }
                        else
                        {
                            Flag = false;
                        }
                    }
                    else
                    {
                        //leaf node
                        Flag = false;
                    }
                }

            }
        }
    }
}