﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using University.DAL;

#nullable disable

namespace University.DAL.Migrations
{
    [DbContext(typeof(UniversityContext))]
    [Migration("20231023103246_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("University.DAL.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Courses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "",
                            Name = "Прикладна математика"
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            Name = "Комп`ютерна інженерія"
                        },
                        new
                        {
                            Id = 3,
                            Description = "",
                            Name = "Електроніка та електромеханіка"
                        },
                        new
                        {
                            Id = 4,
                            Description = "",
                            Name = "Юридичне право"
                        });
                });

            modelBuilder.Entity("University.DAL.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Groups", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 111,
                            CourseId = 1,
                            Name = "SR-11"
                        },
                        new
                        {
                            Id = 112,
                            CourseId = 1,
                            Name = "SR-12"
                        },
                        new
                        {
                            Id = 113,
                            CourseId = 1,
                            Name = "SR-13"
                        },
                        new
                        {
                            Id = 121,
                            CourseId = 2,
                            Name = "PI-21"
                        },
                        new
                        {
                            Id = 131,
                            CourseId = 3,
                            Name = "EE-31"
                        },
                        new
                        {
                            Id = 141,
                            CourseId = 4,
                            Name = "YP-41"
                        });
                });

            modelBuilder.Entity("University.DAL.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Ія",
                            GroupId = 111,
                            LastName = "Атрощенко"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Гаїна",
                            GroupId = 111,
                            LastName = "Троцька"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Устина",
                            GroupId = 111,
                            LastName = "Глущак"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Шанетта",
                            GroupId = 111,
                            LastName = "Морачевська"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Уляна",
                            GroupId = 111,
                            LastName = "Савула"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Глафира",
                            GroupId = 111,
                            LastName = "Шамрай"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Корнелія",
                            GroupId = 111,
                            LastName = "Магура"
                        },
                        new
                        {
                            Id = 8,
                            FirstName = "Фелікса",
                            GroupId = 111,
                            LastName = "Коник"
                        },
                        new
                        {
                            Id = 9,
                            FirstName = "Улита",
                            GroupId = 111,
                            LastName = "Фартушняк"
                        },
                        new
                        {
                            Id = 10,
                            FirstName = "Ада",
                            GroupId = 111,
                            LastName = "Варивода"
                        },
                        new
                        {
                            Id = 11,
                            FirstName = "Есфіра",
                            GroupId = 111,
                            LastName = "Мороз"
                        },
                        new
                        {
                            Id = 12,
                            FirstName = "Йоган",
                            GroupId = 112,
                            LastName = "Рижук"
                        },
                        new
                        {
                            Id = 13,
                            FirstName = "Вітан",
                            GroupId = 112,
                            LastName = "Боровий"
                        },
                        new
                        {
                            Id = 14,
                            FirstName = "Яртур",
                            GroupId = 112,
                            LastName = "Жук"
                        },
                        new
                        {
                            Id = 15,
                            FirstName = "Славобор",
                            GroupId = 112,
                            LastName = "Сливенко"
                        },
                        new
                        {
                            Id = 16,
                            FirstName = "Кий",
                            GroupId = 112,
                            LastName = "Бузинний"
                        },
                        new
                        {
                            Id = 17,
                            FirstName = "Дантур",
                            GroupId = 112,
                            LastName = "Горовенко"
                        },
                        new
                        {
                            Id = 18,
                            FirstName = "Ярчик",
                            GroupId = 112,
                            LastName = "Чічка"
                        },
                        new
                        {
                            Id = 19,
                            FirstName = "Матвій",
                            GroupId = 112,
                            LastName = "Білявський"
                        },
                        new
                        {
                            Id = 20,
                            FirstName = "Недан",
                            GroupId = 112,
                            LastName = "Баліцький"
                        },
                        new
                        {
                            Id = 21,
                            FirstName = "Щек",
                            GroupId = 112,
                            LastName = "Удовенко"
                        },
                        new
                        {
                            Id = 22,
                            FirstName = "Орест",
                            GroupId = 113,
                            LastName = "Колосовський"
                        },
                        new
                        {
                            Id = 23,
                            FirstName = "Йонас",
                            GroupId = 113,
                            LastName = "Вихрущ"
                        },
                        new
                        {
                            Id = 24,
                            FirstName = "Наслав",
                            GroupId = 113,
                            LastName = "Прокопчук"
                        },
                        new
                        {
                            Id = 25,
                            FirstName = "Куйбіда",
                            GroupId = 113,
                            LastName = "Лемешко"
                        },
                        new
                        {
                            Id = 26,
                            FirstName = "Ліпослав",
                            GroupId = 113,
                            LastName = "Мовчан"
                        },
                        new
                        {
                            Id = 27,
                            FirstName = "Снозір",
                            GroupId = 113,
                            LastName = "Назарук"
                        },
                        new
                        {
                            Id = 28,
                            FirstName = "Дорогосил",
                            GroupId = 113,
                            LastName = "Тарасович"
                        },
                        new
                        {
                            Id = 29,
                            FirstName = "Юхим",
                            GroupId = 113,
                            LastName = "Забродський"
                        },
                        new
                        {
                            Id = 30,
                            FirstName = "Яртур",
                            GroupId = 113,
                            LastName = "Цвєк"
                        },
                        new
                        {
                            Id = 31,
                            FirstName = "Лук`ян",
                            GroupId = 121,
                            LastName = "Григоренко"
                        },
                        new
                        {
                            Id = 32,
                            FirstName = "Хорив",
                            GroupId = 121,
                            LastName = "Горбачевський"
                        },
                        new
                        {
                            Id = 33,
                            FirstName = "Царко",
                            GroupId = 121,
                            LastName = "Киричук"
                        },
                        new
                        {
                            Id = 34,
                            FirstName = "Творимир",
                            GroupId = 121,
                            LastName = "Яхненко"
                        },
                        new
                        {
                            Id = 35,
                            FirstName = "Яснолик",
                            GroupId = 121,
                            LastName = "Рошко"
                        },
                        new
                        {
                            Id = 36,
                            FirstName = "Живорід",
                            GroupId = 121,
                            LastName = "Керножицький"
                        },
                        new
                        {
                            Id = 37,
                            FirstName = "Нестор",
                            GroupId = 121,
                            LastName = "Засядько"
                        },
                        new
                        {
                            Id = 38,
                            FirstName = "Йомер",
                            GroupId = 121,
                            LastName = "Павличенко"
                        },
                        new
                        {
                            Id = 39,
                            FirstName = "Малик",
                            GroupId = 121,
                            LastName = "Білоскурський"
                        },
                        new
                        {
                            Id = 40,
                            FirstName = "Осемрит",
                            GroupId = 121,
                            LastName = "Синиця"
                        },
                        new
                        {
                            Id = 41,
                            FirstName = "Явір",
                            GroupId = 131,
                            LastName = "Сливенко"
                        },
                        new
                        {
                            Id = 42,
                            FirstName = "Колодар",
                            GroupId = 131,
                            LastName = "Гайдабура"
                        },
                        new
                        {
                            Id = 43,
                            FirstName = "Макар",
                            GroupId = 131,
                            LastName = "Гембицький"
                        },
                        new
                        {
                            Id = 44,
                            FirstName = "Радогоста",
                            GroupId = 131,
                            LastName = "Гаркуша"
                        },
                        new
                        {
                            Id = 45,
                            FirstName = "Юдихва",
                            GroupId = 131,
                            LastName = "Степура"
                        },
                        new
                        {
                            Id = 46,
                            FirstName = "Млада",
                            GroupId = 131,
                            LastName = "Сенько"
                        },
                        new
                        {
                            Id = 47,
                            FirstName = "Римма",
                            GroupId = 131,
                            LastName = "Пашко"
                        },
                        new
                        {
                            Id = 48,
                            FirstName = "Цвітана",
                            GroupId = 131,
                            LastName = "Могиленко"
                        },
                        new
                        {
                            Id = 49,
                            FirstName = "Марта",
                            GroupId = 131,
                            LastName = "Кирей"
                        },
                        new
                        {
                            Id = 50,
                            FirstName = "Глафіра",
                            GroupId = 131,
                            LastName = "Любенецька"
                        },
                        new
                        {
                            Id = 51,
                            FirstName = "Віра",
                            GroupId = 131,
                            LastName = "Тарасовна"
                        },
                        new
                        {
                            Id = 52,
                            FirstName = "Жадана",
                            GroupId = 141,
                            LastName = "Заяць"
                        },
                        new
                        {
                            Id = 53,
                            FirstName = "Тава",
                            GroupId = 141,
                            LastName = "Андрусенко"
                        },
                        new
                        {
                            Id = 54,
                            FirstName = "Ядвіга",
                            GroupId = 141,
                            LastName = "Воронюк"
                        },
                        new
                        {
                            Id = 55,
                            FirstName = "Стелла",
                            GroupId = 141,
                            LastName = "Рибенчук"
                        },
                        new
                        {
                            Id = 56,
                            FirstName = "Мокрина",
                            GroupId = 141,
                            LastName = "Трегуб"
                        });
                });

            modelBuilder.Entity("University.DAL.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId")
                        .IsUnique();

                    b.ToTable("Teachers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Олександр",
                            GroupId = 111,
                            LastName = "Полухін"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Світлана",
                            GroupId = 112,
                            LastName = "Савченко"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Раїса",
                            GroupId = 113,
                            LastName = "Халявкіна"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Генадій",
                            GroupId = 121,
                            LastName = "Василенко"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Петро",
                            GroupId = 131,
                            LastName = "Моденов"
                        },
                        new
                        {
                            Id = 9,
                            FirstName = "Анна",
                            GroupId = 141,
                            LastName = "Колісник"
                        });
                });

            modelBuilder.Entity("University.DAL.Models.Group", b =>
                {
                    b.HasOne("University.DAL.Models.Course", "Course")
                        .WithMany("Groups")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("University.DAL.Models.Student", b =>
                {
                    b.HasOne("University.DAL.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("University.DAL.Models.Teacher", b =>
                {
                    b.HasOne("University.DAL.Models.Group", "Group")
                        .WithOne("Tutor")
                        .HasForeignKey("University.DAL.Models.Teacher", "GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("University.DAL.Models.Course", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("University.DAL.Models.Group", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Tutor")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
