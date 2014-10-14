using Gallery.Data.DBInteractions.Interface;

namespace Gallery.Data.DBInteractions.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IDbFactory _databaseFactory;
        private GalleryContext _dataContext;

        public UnitOfWork(IDbFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }

        protected GalleryContext DataContext
        {
            get { return _dataContext ?? (_dataContext = _databaseFactory.Get()); }
        }
        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
