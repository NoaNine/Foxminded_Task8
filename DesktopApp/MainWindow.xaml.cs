using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using University.Dal.UnitOfWork;
using University.DAL;
using University.DAL.Models;
using University.DAL.Repositories;

namespace DesktopApp
{
    public partial class MainWindow : Window
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Teacher> _teacherRepository;
        private readonly IRepository<Group> _groupRepository;
        private readonly UniversityContext _universityContext;
        private readonly IUnitOfWork _unitOfWork;

        public MainWindow(IRepository<Course> courseRepository, IRepository<Student> studentRepository, 
            IRepository<Teacher> teacherRepository, IRepository<Group> groupRepository, UniversityContext universityContext, IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _groupRepository = groupRepository;
            _universityContext = universityContext;
            _unitOfWork = unitOfWork;

            //var listCourses = _courseRepository.GetAll();

            //treeWiewCourses.ItemsSource = listCourses;

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _universityContext.Groups.Load();
            DataContext = _universityContext.Groups.Local.ToObservableCollection();
        }
    }
}
