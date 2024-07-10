namespace Book_Store
{
    public class LibraryEngine
    {
        // 1. User-defined Delegate.
        public delegate string BookFunction(Book B);
        public static void DelegateProcessBooks(List<Book> bList, BookFunction fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }


        // 2. Built-in Func.
        public static void FuncProcessBooks(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }


        // 3. Anonymous Method.
        public static void AnonymousProcessBooks(List<Book> bList, Func<Book, string> fPtr)
        {
            FuncProcessBooks(bList, delegate (Book B)
            {
                return B.ISBN;
            });
        }


        // 4. Lambda Expression.
        public static void LambdaProcessBooks(List<Book> bList, Func<Book, string> fPtr)
        {
            FuncProcessBooks(bList, B => B.PublicationDate.ToString());
        }
    }
}
