namespace DefaultNamespace
{
    public class MaxAndMinHeap
    {
        
    }

    public interface IHeap
    {
        int getParent(int i);
        int getLeft(int i);
        int getRight(int i);
        int extractMin();
        void decreaseKey(int i, int newValue);
        int getMin();
        void deleteKey(int i);
        void insertKey(int i);
    }

    public class MinHeap : IHEap
    {
        
    }
}