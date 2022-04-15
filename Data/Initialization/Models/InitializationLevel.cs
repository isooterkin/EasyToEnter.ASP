﻿using Class = EasyToEnter.ASP.Models.Models.LevelModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationLevel
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Бакалавриат",
                    Description = "Поступать на программы бакалавриата могут обладатели среднего общего или среднего профессионального образования. Учёба длится 4 года и предполагает общую фундаментальную подготовку. Для поступления в вуз необходимо подать заявление в приёмную комиссию учебного заведения и представить необходимые документы. По окончании бакалавриата студенты защищают выпускную квалификационную работу. По её итогам выдаётся диплом бакалавра с присвоением квалификации «Бакалавр». Выпускники бакалавриата могут работать по профессии и продолжать образование в магистратуре",
                    Code = "03"
                },
                new Class // 2
                {
                    Name = "Магистратура",
                    Description = "Позволяет углубить специализацию по выбранному направлению. На программы магистратуры могут поступать выпускники бакалавриата — бесплатно и специалитета — на платной основе. Обучение длится не менее 2 лет и предусматривает подготовку к научно-исследовательской деятельности. После защиты магистерской диссертации выпускникам выдаётся диплом магистра и присваивается квалификация «Магистр». Выпускники бакалавриата могут работать по профессии и продолжать образование в аспирантуре",
                    Code = "04"
                },
                new Class // 3
                {
                    Name = "Специалитет",
                    Description = "Как и на программы бакалавриата, на специалитет поступают обладатели среднего общего или среднего профессионального образования. В отличие от бакалавриата, программы специалитета относятся ко второму уровню высшего образования и в большей степени ориентируют студентов на самостоятельную практическую работу по выбранной специальности. На них поступают обладатели среднего общего или среднего профессионального образования. Для поступления в вуз необходимо подать заявление в приёмную комиссию учебного заведения и представить необходимые документы. Обучение длится не менее 5 лет. По итогам сдачи экзаменов и защиты дипломной работы выдаётся диплом специалиста с указанием присвоенной квалификации. Выпускники бакалавриата могут работать по профессии и продолжать образование в магистратуре — на платной основе или аспирантуре — бесплатно",
                    Code = "05"
                },
                new Class // 4
                {
                    Name = "Аспирантура",
                    Description = "Форма подготовки научно-педагогических кадров. В аспирантуру могут поступать выпускники магистратуры или специалитета. Основным содержанием является научно-исследовательская работа под руководством научного руководителя. Аспиранты выбирают научное направление, тему исследования для своей диссертации. Обучение на очной форме длится не менее 3 лет, на заочной — не менее 4. По завершении аспирантуры выдаётся заключение о соответствии подготовленной диссертации на соискание учёной степени кандидата наук установленным критериям. По итогам защиты диссертации присваивается степень кандидата наук — первая степень, официально подтверждающая статус учёного. Кандидаты наук допускаются к соисканию степени доктора наук — второй степени, подтверждающей статус учёного. Она присуждается по итогам защиты докторской диссертации",
                    Code = "06"
                },
                new Class // 5
                {
                    Name = "Адъюнктура",
                    Description = "Адъюнктура – это высшая ступень подготовки будущих кадров для правоохранительных органов и других военных ведомств (ФСБ, Вооруженные силы РФ и т.д). Является аналогом аспирантуры, поэтому для успешного поступления необходимо иметь воинское звание и диплом о высшем профессиональном образовании, подтверждающий окончание специалитета или магистратуры",
                    Code = "07"
                },
                new Class // 6
                {
                    Name = "Ординатура",
                    Description = "Завершающая ступень подготовки в области медицины (фармацевтики). К поступлению в ординатуру допускаются обладатели высшего медицинского (или фармацевтического) образования. Обучение длится 2 или 3 года и представляет собой сочетание углублённого изучения основ медицинских наук с практикой в медицинских учреждениях. Выпускникам выдаётся диплом об окончании ординатуры и присваивается квалификация врача по конкретной специальности, дающая право работать в медицинских учреждениях",
                    Code = "08"
                },
                new Class // 7
                {
                    Name = "Ассистентура",
                    Description = "Форма подготовки работников высшей квалификации в области искусств. По программам ассистентуры-стажировки могут обучаться выпускники специалитета или магистратуры в данной области. Обучение не превышает 2 лет. Выпускная работа представляет собой выступление, концерт, показ, выставку, фильм — в зависимости от специализации. По окончании ассистентуры-стажировки выдаётся диплом о её окончании с присвоением квалификации «Концертный исполнитель и преподаватель высшей школы». Выпускники ассистентуры-стажировки имеют право исполнять произведения искусства и работать преподавателями",
                    Code = "09"
                }
            });

            Context.SaveChanges();
        }
    }
}