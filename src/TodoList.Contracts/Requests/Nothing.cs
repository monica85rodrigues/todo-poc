namespace TodoList.Contracts.Requests
{
    public sealed class Nothing
    {
        public static readonly Nothing Instance = new Nothing();
        
        private Nothing()
        {
        }
    }
}