using System.Collections.Generic;
using System.Xml.Serialization;
using Gallery.Entities;

namespace Gallery.Services.Interfaces
{
    public interface IDescriptionService
    {
        IEnumerable<DbDescription> GetDescriptions();
        DbDescription GetDescriptionById(long id);
        void CreateDescription(DbDescription description);
        void UpdateDescription(DbDescription description);
        void DeleteDescription(long id);
        void SaveDescription();
    }
}
