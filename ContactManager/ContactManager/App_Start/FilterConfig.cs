using System.Web;
using System.Web.Mvc;

/*
Этот код добавляет в приложение фильтры Authorize и RequireHttps.
Фильтр Authorize не позволяет анонимным пользователям получить доступ к методам в приложении. 
С помощью атрибута AllowAnonymous вы сможете отказаться от обязательной авторизации в 
соответствующих методах, чтобы анонимные пользователи могли входить в систему и просматривать
главную страницу. Фильтр RequireHttps требует использования HTTPS для доступа к веб-приложению. 
*/
namespace ContactManager
{
    public class FilterConfig
    {
        //фильтры добавляются ко всему приложению а не к чему то конкретному
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           // filters.Add(new System.Web.Mvc.AuthorizeAttribute());

            //временно выключим https - сертификацию
            //filters.Add(new RequireHttpsAttribute());

        }
    }
}
