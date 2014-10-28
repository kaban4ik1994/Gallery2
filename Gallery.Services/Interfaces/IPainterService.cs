using System.Collections.Generic;
using Gallery.Entities;

namespace Gallery.Services.Interfaces
{
  public  interface IPainterService
  {
      IEnumerable<DbPainter> GetPainters();
      DbPainter GetPainterById(long id);
      void CreatePainter(DbPainter painter);
      void UpdatePainter(DbPainter painter);
      void DeletePainter(long id);
      void SavePainter();
  }
}
