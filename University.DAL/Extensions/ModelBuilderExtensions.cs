using Microsoft.EntityFrameworkCore;
using University.DAL.Models;

namespace University.DAL.Extensions;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Name = "Прикладна математика", Description = "" },
            new Course { Id = 2, Name = "Комп`ютерна інженерія", Description = "" },
            new Course { Id = 3, Name = "Електроніка та електромеханіка", Description = "" },
            new Course { Id = 4, Name = "Юридичне право", Description = "" }
            );

        modelBuilder.Entity<Group>().HasData(
            new Group { Id = 111, CourseId = 1, Name = "SR-11" },
            new Group { Id = 112, CourseId = 1, Name = "SR-12" },
            new Group { Id = 113, CourseId = 1, Name = "SR-13" },
            new Group { Id = 121, CourseId = 2, Name = "PI-21" },
            new Group { Id = 131, CourseId = 3, Name = "EE-31" },
            new Group { Id = 141, CourseId = 4, Name = "YP-41" }
            );

        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, GroupId = 111, FirstName = "Ія", LastName = "Атрощенко" },
            new Student { Id = 2, GroupId = 111, FirstName = "Гаїна", LastName = "Троцька" },
            new Student { Id = 3, GroupId = 111, FirstName = "Устина", LastName = "Глущак" },
            new Student { Id = 4, GroupId = 111, FirstName = "Шанетта", LastName = "Морачевська" },
            new Student { Id = 5, GroupId = 111, FirstName = "Уляна", LastName = "Савула" },
            new Student { Id = 6, GroupId = 111, FirstName = "Глафира", LastName = "Шамрай" },
            new Student { Id = 7, GroupId = 111, FirstName = "Корнелія", LastName = "Магура" },
            new Student { Id = 8, GroupId = 111, FirstName = "Фелікса", LastName = "Коник" },
            new Student { Id = 9, GroupId = 111, FirstName = "Улита", LastName = "Фартушняк" },
            new Student { Id = 10, GroupId = 111, FirstName = "Ада", LastName = "Варивода" },
            new Student { Id = 11, GroupId = 111, FirstName = "Есфіра", LastName = "Мороз" },
            new Student { Id = 12, GroupId = 112, FirstName = "Йоган", LastName = "Рижук" },
            new Student { Id = 13, GroupId = 112, FirstName = "Вітан", LastName = "Боровий" },
            new Student { Id = 14, GroupId = 112, FirstName = "Яртур", LastName = "Жук" },
            new Student { Id = 15, GroupId = 112, FirstName = "Славобор", LastName = "Сливенко" },
            new Student { Id = 16, GroupId = 112, FirstName = "Кий", LastName = "Бузинний" },
            new Student { Id = 17, GroupId = 112, FirstName = "Дантур", LastName = "Горовенко" },
            new Student { Id = 18, GroupId = 112, FirstName = "Ярчик", LastName = "Чічка" },
            new Student { Id = 19, GroupId = 112, FirstName = "Матвій", LastName = "Білявський" },
            new Student { Id = 20, GroupId = 112, FirstName = "Недан", LastName = "Баліцький" },
            new Student { Id = 21, GroupId = 112, FirstName = "Щек", LastName = "Удовенко" },
            new Student { Id = 22, GroupId = 113, FirstName = "Орест", LastName = "Колосовський" },
            new Student { Id = 23, GroupId = 113, FirstName = "Йонас", LastName = "Вихрущ" },
            new Student { Id = 24, GroupId = 113, FirstName = "Наслав", LastName = "Прокопчук" },
            new Student { Id = 25, GroupId = 113, FirstName = "Куйбіда", LastName = "Лемешко" },
            new Student { Id = 26, GroupId = 113, FirstName = "Ліпослав", LastName = "Мовчан" },
            new Student { Id = 27, GroupId = 113, FirstName = "Снозір", LastName = "Назарук" },
            new Student { Id = 28, GroupId = 113, FirstName = "Дорогосил", LastName = "Тарасович" },
            new Student { Id = 29, GroupId = 113, FirstName = "Юхим", LastName = "Забродський" },
            new Student { Id = 30, GroupId = 113, FirstName = "Яртур", LastName = "Цвєк" },
            new Student { Id = 31, GroupId = 121, FirstName = "Лук`ян", LastName = "Григоренко" },
            new Student { Id = 32, GroupId = 121, FirstName = "Хорив", LastName = "Горбачевський" },
            new Student { Id = 33, GroupId = 121, FirstName = "Царко", LastName = "Киричук" },
            new Student { Id = 34, GroupId = 121, FirstName = "Творимир", LastName = "Яхненко" },
            new Student { Id = 35, GroupId = 121, FirstName = "Яснолик", LastName = "Рошко" },
            new Student { Id = 36, GroupId = 121, FirstName = "Живорід", LastName = "Керножицький" },
            new Student { Id = 37, GroupId = 121, FirstName = "Нестор", LastName = "Засядько" },
            new Student { Id = 38, GroupId = 121, FirstName = "Йомер", LastName = "Павличенко" },
            new Student { Id = 39, GroupId = 121, FirstName = "Малик", LastName = "Білоскурський" },
            new Student { Id = 40, GroupId = 121, FirstName = "Осемрит", LastName = "Синиця" },
            new Student { Id = 41, GroupId = 131, FirstName = "Явір", LastName = "Сливенко" },
            new Student { Id = 42, GroupId = 131, FirstName = "Колодар", LastName = "Гайдабура" },
            new Student { Id = 43, GroupId = 131, FirstName = "Макар", LastName = "Гембицький" },
            new Student { Id = 44, GroupId = 131, FirstName = "Радогоста", LastName = "Гаркуша" },
            new Student { Id = 45, GroupId = 131, FirstName = "Юдихва", LastName = "Степура" },
            new Student { Id = 46, GroupId = 131, FirstName = "Млада", LastName = "Сенько" },
            new Student { Id = 47, GroupId = 131, FirstName = "Римма", LastName = "Пашко" },
            new Student { Id = 48, GroupId = 131, FirstName = "Цвітана", LastName = "Могиленко" },
            new Student { Id = 49, GroupId = 131, FirstName = "Марта", LastName = "Кирей" },
            new Student { Id = 50, GroupId = 131, FirstName = "Глафіра", LastName = "Любенецька" },
            new Student { Id = 51, GroupId = 131, FirstName = "Віра", LastName = "Тарасовна" },
            new Student { Id = 52, GroupId = 141, FirstName = "Жадана", LastName = "Заяць" },
            new Student { Id = 53, GroupId = 141, FirstName = "Тава", LastName = "Андрусенко" },
            new Student { Id = 54, GroupId = 141, FirstName = "Ядвіга", LastName = "Воронюк" },
            new Student { Id = 55, GroupId = 141, FirstName = "Стелла", LastName = "Рибенчук" },
            new Student { Id = 56, GroupId = 141, FirstName = "Мокрина", LastName = "Трегуб" }
            );

        modelBuilder.Entity<Teacher>().HasData(
            new Teacher { Id = 1, GroupId = 111, FirstName = "Олександр", LastName = "Полухін" },
            //new Teacher { Id = 2, GroupId = 111, FirstName = "Василій", LastName = "Моржов" },
            //new Teacher { Id = 3, GroupId = 112, FirstName = "Іван", LastName = "Куклінський" },
            new Teacher { Id = 4, GroupId = 112, FirstName = "Світлана", LastName = "Савченко" },
            new Teacher { Id = 5, GroupId = 113, FirstName = "Раїса", LastName = "Халявкіна" },
            new Teacher { Id = 6, GroupId = 121, FirstName = "Генадій", LastName = "Василенко" },
            new Teacher { Id = 7, GroupId = 131, FirstName = "Петро", LastName = "Моденов" },
            //new Teacher { Id = 8, GroupId = 141, FirstName = "Ірина", LastName = "Чуба" },
            new Teacher { Id = 9, GroupId = 141, FirstName = "Анна", LastName = "Колісник" }
            );
    }
}
