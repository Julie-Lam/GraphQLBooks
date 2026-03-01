namespace GraphQLBooks.GraphQL
{
    public class Subscription
    {

        [Subscribe]
        public Book BookAdded([EventMessage]Book newBook) 
        {
            return newBook; 
        }
    }
}
