namespace Leisurebooker.DataAccess.EF.Connection
{
    public static class ContextFactory
    {
        private static Context _context;

        public static Context GetContext() => _context ?? (_context = new Context());

        public static void Refresh()
        {
            _context = new Context();
        }

        public static void Refresh(Context context)
        {
            _context = context;
        }
    }
}
