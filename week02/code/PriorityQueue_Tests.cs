using Microsoft.VisualStudio.TestTools.UnitTesting; 
 
// TODO Problem 2 - Write and run test cases and fix the code to match requirements. 
 
[TestClass] 
public class PriorityQueueTests 
{ 
    [TestMethod] 
    // Scenario: Add three items with different priorities to the queue and remove them.
    // Expected Result: The item with the highest priority should be removed first, followed by the next highest priority.
    // Defect(s) Found: 
    public void TestPriorityQueue_1() 
    { 
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    } 
 
    [TestMethod] 
    // Scenario: Add three items with the same priority to the queue.
    // Expected Result: The items should be removed in the same order they were added because the queue uses FIFO when priorities are equal.
    // Defect(s) Found: 
    public void TestPriorityQueue_2() 
    { 
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    } 

    [TestMethod]
    // Scenario: Add items with different priorities and verify that each item is added to the queue and removed according to its priority.
    // Expected Result: The item with the highest priority should be removed first, followed by the remaining items in priority order.
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 4);
        priorityQueue.Enqueue("Third", 1);

        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to remove an item from an empty priority queue.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}