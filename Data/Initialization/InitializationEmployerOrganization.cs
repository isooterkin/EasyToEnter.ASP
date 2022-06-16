using Class = EasyToEnter.ASP.Models.Models.EmployerOrganizationModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationEmployerOrganization
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    OrganizationId = 1,
                    PersonId = 6,
                },
                new Class // 2
                {
                    OrganizationId = 1,
                    PersonId = 7,
                }
            });

            Context.SaveChanges();
        }
    }
}