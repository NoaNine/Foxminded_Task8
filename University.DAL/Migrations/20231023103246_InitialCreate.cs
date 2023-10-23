using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace University.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "", "Прикладна математика" },
                    { 2, "", "Комп`ютерна інженерія" },
                    { 3, "", "Електроніка та електромеханіка" },
                    { 4, "", "Юридичне право" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CourseId", "Name" },
                values: new object[,]
                {
                    { 111, 1, "SR-11" },
                    { 112, 1, "SR-12" },
                    { 113, 1, "SR-13" },
                    { 121, 2, "PI-21" },
                    { 131, 3, "EE-31" },
                    { 141, 4, "YP-41" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName" },
                values: new object[,]
                {
                    { 1, "Ія", 111, "Атрощенко" },
                    { 2, "Гаїна", 111, "Троцька" },
                    { 3, "Устина", 111, "Глущак" },
                    { 4, "Шанетта", 111, "Морачевська" },
                    { 5, "Уляна", 111, "Савула" },
                    { 6, "Глафира", 111, "Шамрай" },
                    { 7, "Корнелія", 111, "Магура" },
                    { 8, "Фелікса", 111, "Коник" },
                    { 9, "Улита", 111, "Фартушняк" },
                    { 10, "Ада", 111, "Варивода" },
                    { 11, "Есфіра", 111, "Мороз" },
                    { 12, "Йоган", 112, "Рижук" },
                    { 13, "Вітан", 112, "Боровий" },
                    { 14, "Яртур", 112, "Жук" },
                    { 15, "Славобор", 112, "Сливенко" },
                    { 16, "Кий", 112, "Бузинний" },
                    { 17, "Дантур", 112, "Горовенко" },
                    { 18, "Ярчик", 112, "Чічка" },
                    { 19, "Матвій", 112, "Білявський" },
                    { 20, "Недан", 112, "Баліцький" },
                    { 21, "Щек", 112, "Удовенко" },
                    { 22, "Орест", 113, "Колосовський" },
                    { 23, "Йонас", 113, "Вихрущ" },
                    { 24, "Наслав", 113, "Прокопчук" },
                    { 25, "Куйбіда", 113, "Лемешко" },
                    { 26, "Ліпослав", 113, "Мовчан" },
                    { 27, "Снозір", 113, "Назарук" },
                    { 28, "Дорогосил", 113, "Тарасович" },
                    { 29, "Юхим", 113, "Забродський" },
                    { 30, "Яртур", 113, "Цвєк" },
                    { 31, "Лук`ян", 121, "Григоренко" },
                    { 32, "Хорив", 121, "Горбачевський" },
                    { 33, "Царко", 121, "Киричук" },
                    { 34, "Творимир", 121, "Яхненко" },
                    { 35, "Яснолик", 121, "Рошко" },
                    { 36, "Живорід", 121, "Керножицький" },
                    { 37, "Нестор", 121, "Засядько" },
                    { 38, "Йомер", 121, "Павличенко" },
                    { 39, "Малик", 121, "Білоскурський" },
                    { 40, "Осемрит", 121, "Синиця" },
                    { 41, "Явір", 131, "Сливенко" },
                    { 42, "Колодар", 131, "Гайдабура" },
                    { 43, "Макар", 131, "Гембицький" },
                    { 44, "Радогоста", 131, "Гаркуша" },
                    { 45, "Юдихва", 131, "Степура" },
                    { 46, "Млада", 131, "Сенько" },
                    { 47, "Римма", 131, "Пашко" },
                    { 48, "Цвітана", 131, "Могиленко" },
                    { 49, "Марта", 131, "Кирей" },
                    { 50, "Глафіра", 131, "Любенецька" },
                    { 51, "Віра", 131, "Тарасовна" },
                    { 52, "Жадана", 141, "Заяць" },
                    { 53, "Тава", 141, "Андрусенко" },
                    { 54, "Ядвіга", 141, "Воронюк" },
                    { 55, "Стелла", 141, "Рибенчук" },
                    { 56, "Мокрина", 141, "Трегуб" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName" },
                values: new object[,]
                {
                    { 1, "Олександр", 111, "Полухін" },
                    { 4, "Світлана", 112, "Савченко" },
                    { 5, "Раїса", 113, "Халявкіна" },
                    { 6, "Генадій", 121, "Василенко" },
                    { 7, "Петро", 131, "Моденов" },
                    { 9, "Анна", 141, "Колісник" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Name",
                table: "Courses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseId",
                table: "Groups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_GroupId",
                table: "Teachers",
                column: "GroupId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
