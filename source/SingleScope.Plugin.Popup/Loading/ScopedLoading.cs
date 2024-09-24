namespace SingleScope.Plugin.Popup.Loading
{
    internal class ScopedLoading : PageLoading, IScopedLoading
    {
        private bool _isDisposed;

        ~ScopedLoading()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                Hide();

                _isDisposed = true;
            }
        }
    }
}
