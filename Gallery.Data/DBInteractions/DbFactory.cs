namespace Gallery.Data.DBInteractions
{
    public class DbFactory: Disposable, IDbFactory
    {
        private GalleryContext _galleryContext;

        public GalleryContext Get()
        {
            return _galleryContext ?? (_galleryContext = new GalleryContext());
        }

        protected override void DisposeCore()
        {
            if (_galleryContext != null)
            _galleryContext.Dispose();
        }
    }
}
