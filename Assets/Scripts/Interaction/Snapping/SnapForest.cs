using System;
using System.Collections.Generic;

namespace Interaction.Snapping
{
    public class SnapForest: ISnapForest
    {
        private class Node
        {
            public Node( Snapable val )
            {
                this.val = val;
            }

            public void AddChild(Node newChild)
            {
                newChild.parent = this;
                children.Add(newChild);
            }

            public void RemoveChild(Node oldChild)
            {
                oldChild.parent = null;
                children.Remove(oldChild);
            }

            public Snapable GetVal()
            {
                return val;
            }

            public List<Node> GetChildren()
            {
                return children;
            }

            public Boolean HasParent()
            {
                return parent != null;
            }

            public Node GetParent()
            {
                return parent;
            }

            private Node parent;
            private Snapable val;
            private List<Node> children = new List<Node>();
        }

        private List<Node> roots = new List<Node>();
        
        public void Join(Snapable a, Snapable b)
        {
            Node possible_nodeA = findInForest(a);
            if (possible_nodeA == null) roots.Add( new Node(a));

            Node possible_nodeB = findInForest(b);
            if (possible_nodeB == null) roots.Add( new Node(b));

            Node nodeA = (Node) findInForest(a);
            Node nodeB = (Node) findInForest(b);

            roots.Remove(nodeB);
            nodeA.AddChild(nodeB);
        }

        public (List<Snapable>, List<Snapable>) Split(Snapable a, Snapable b)
        {
            Node nodeA = findInForest(a);
            Node nodeB = findInForest(b);

            Node parent;
            Node child;
            
            if (nodeA.GetParent() == nodeB)
            {
                parent = nodeB;
                child = nodeA;
            } else if (nodeB.GetParent() == nodeA)
            {
                parent = nodeA;
                child = nodeB;
            }
            else
            {
                throw new Exception("Not joined, split must fail!");
            }
            
            parent.RemoveChild(child);
            return (FlattenFromAnywhere(parent), FlattenFromRoot(child));

        }

        private List<Snapable> FlattenFromAnywhere(Node node)
        {
            return FlattenFromRoot(GetRoot(node));
        }
        
        private List<Snapable> FlattenFromRoot(Node root)
        {
            List<Snapable> flatList = new List<Snapable>();
            flatList.Add(root.GetVal());
            foreach (var child in root.GetChildren())
            {
                flatList.AddRange(FlattenFromAnywhere(child));
            }

            return flatList;
        }

        private Node GetRoot(Node node)
        {
            Node root = node;
            while (root.HasParent())
            {
                root = root.GetParent();
            }

            return root;
        } 

        private Node findInForest(Snapable needle)
        {
            foreach (var root in roots)
            {
                Node search = findInTree(needle, root);
                if (search != null) return search;
            }

            return null;
        }
        private Node findInTree(Snapable needle, Node node)
        {
            if (node == null) return null;
            if (node.GetVal() == needle) return node;


            foreach (Node child in node.GetChildren())
            {
                Node search = findInTree(needle, child);
                if (search != null) return search;
            }

            return null;
        }
    }
}