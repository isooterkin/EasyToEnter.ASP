using Class = EasyToEnter.ASP.Models.Models.SubjectReplacementModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationSubjectReplacement
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 00
                {
                    
                }
            });

            Context.SaveChanges();
        }
    }
}