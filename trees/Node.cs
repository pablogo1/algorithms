namespace Trees
{
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            Data = data;
        }

        public void Insert(int data) {
            var childNode = data <= this.Data ? Left : Right;

            if(childNode == null) {
                childNode = new Node(data);
            } else {
                childNode.Insert(data);
            }
        }
    }
}