using System.Collections.Generic;
using System.Linq;
using Gallery.Util.Interfaces;
using MenuItem = Gallery.WebUI.Models.Menu.MenuItem;

namespace Gallery.WebUI.Helpers
{
    public class MenuHelper
    {
        public static IEnumerable<MenuItem> GetMenuItems(IDepartamentUtil departamentUtil, string dep)
        {
            var departaments = departamentUtil.GetDepartaments().ToList();
            var menuItems = departaments.Select(departament => new MenuItem { IsActive = departament.DepartamentName == dep, Item = departament.DepartamentName }).ToList();
            menuItems.Insert(0, new MenuItem{IsActive = departaments.All(x => x.DepartamentName != dep), Item = "All"});
            return menuItems;
        }
    }
}