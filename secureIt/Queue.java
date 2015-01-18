import java.util.LinkedList;

class Queue {
   private LinkedList list = new LinkedList();
   
	public void enqueue(String file) {
		list.addLast(file);
	}

	public String dequeue() {
		return (String) list.removeFirst();
	}
	
	public String peek() {
		return (String) list.getFirst();
	}

	public boolean hasItems() {
		return !list.isEmpty();
	}

	public int size() {
		return list.size();
	}

	public void addItems(Queue q) {
		while (q.hasItems())
			list.addLast(q.dequeue());
	}
	
	// Queue test function
   
	public static void main(String[] args) {
   
		Queue q = new Queue();
		
		q.enqueue("One");
		q.enqueue("Two");
		q.enqueue("Three");
		q.enqueue("Four");
		q.enqueue("Five");
		
		System.out.println(q.peek());
		System.out.println(q.peek());
		System.out.println(q.peek());
		
		while (q.hasItems())
			System.out.println(q.dequeue());
	}

   
}

