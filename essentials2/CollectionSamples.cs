using learning;

namespace essentials2
{
    public static class CollectionSamples
    {
        public static void Queue()
        {
            var q = new System.Collections.Queue();
            q.Enqueue("firstItem");
            q.Enqueue("secondItem");

            string? item = null;

            Console.WriteLine("Using a Queue");
            while ((item = (string?)q.Dequeue()) != null)
            {
                Console.WriteLine(item);
                if (q.Count <= 0)
                    break;
            }
        }

        public static void Stack()
        {
            var stk = new System.Collections.Generic.Stack<string>();
            stk.Push("firstItem");
            stk.Push("secondItem");

            string? stkItem = null;
            Console.WriteLine();
            Console.WriteLine("Using a stack");

            while ((stkItem = stk.Pop()) != null)
            {
                Console.WriteLine(stkItem);
                if (stk.Count <= 0)
                    break;
            }
        }

        private static List<Client> clients;

        static CollectionSamples()
        {
            //initialize new clients and add to list
            clients = new List<Client>();

            for (int i = 1; i < 11; i++)
            {
                clients.Add(
                    new Client
                    {
                        Id = i,
                        Name = i.ToString(),
                        ContractStart = new DateOnly(2021, 10, i),
                        ContractEnd = new DateOnly(2022, 10, i)
                        Industry = 
                    });
            }
        }

        public static void Indexing()
        {
            //get an item at a specific index
            var clientThree = clients[2];
            Console.WriteLine($"Found client {clientThree.Id} at index 2");

            //check if a collection contains an item
            string doesContain = clients.Contains(clientThree) ? "does" : "doesn't";
            Console.WriteLine($"Clients {doesContain} contain this client.");
            //FOLLOW UP: What if you created a new client object with the same property values?
            //FOLLOW UP: Same as before, but what if client was a record type or value type instead of a class?

            //use a predicate to find an item in the collection
            var clientSeven = clients.Find(ClientIsMatch);

            if (clientSeven != null)
            {
                Console.WriteLine($"Found client {clientSeven.Id}");
            }
            else
            {
                Console.WriteLine("No client found with that ID.");
            }

        }

        private static bool ClientIsMatch(Client c)
        {
            return c.Id == 7;
            //FOLLOW UP: What happens if your expression matches more than one item?
        }

        public static void Iterating()
        {
            //reverse the order of the list
            clients.Reverse();

            IEnumerator<Client> custEnum = clients.GetEnumerator();
            while (custEnum.MoveNext())
            {
                Client current = custEnum.Current;
                Console.WriteLine($"{current.FirstName} {current.LastName}");
            }

            //sort the clients
            clients.Sort();  // or in our case, Reverse would do the same

            //or using foreach
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.FirstName} {client.LastName}");
            }
        }
    }
}