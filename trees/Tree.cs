namespace Trees
{
    public class Tree
    {
        private Node _head;

        public Tree() : this(null) {}

        public Tree(int headData) : this(new Node(headData)) {}

        public Tree(Node head)
        {
            _head = head;
        }

        public void Insert(int data)
        {
            CreateNewHeadIfNull(data);

            _head.Insert(data);
        }

        private void CreateNewHeadIfNull(int data) {
            if(_head == null) {
                _head = new Node(data);
            }
        }
    }
}