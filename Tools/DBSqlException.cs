using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;

namespace EasyToEnter.ASP.Tools
{
    public static class DBSqlException
    {
        public static void CheckedDBSqlException(Exception exception, ModelStateDictionary modelStateDictionary)
        {
            if (exception.GetBaseException().GetType() == typeof(SqlException))
                if (exception.InnerException != null)
                    switch (((SqlException)exception.InnerException).Number)
                    {
                        case 2627:
                            modelStateDictionary.AddModelError("", "Ошибка уникального ограничения");
                            break;
                        case 547:
                            modelStateDictionary.AddModelError("", "Нарушение проверки ограничений");
                            break;
                        case 2601:
                            modelStateDictionary.AddModelError("", "Ошибка дублированной строки ключа");
                            break;
                        default:
                            break;
                    }
        }
    }
}