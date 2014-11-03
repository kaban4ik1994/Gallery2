using System.Collections.Generic;
using System.Linq;
using Gallery.Util.Interfaces;
using Gallery.WebUI.Models.Menu;

namespace Gallery.WebUI.Helpers
{
    public class MenuHelper
    {
        public static IEnumerable<MenuItem> GetMenuItems(IDepartamentUtil departamentUtil)
        {
            var departaments = departamentUtil.GetDepartaments();
            return departaments.Select(departament => new MenuItem {IsActive = false, Item = departament.DepartamentName}).ToList();
        }
    }
}