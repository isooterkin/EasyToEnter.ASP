using Class = EasyToEnter.ASP.Models.Models.PaymentModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationPayment
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Бюджет"
                },
                new Class // 2
                {
                    Name = "Платно"
                }
            });

            Context.SaveChanges();
        }
    }
}