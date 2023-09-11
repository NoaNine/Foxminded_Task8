using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
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

        public MainWindow(IRepository<Course> courseRepository, IRepository<Student> studentRepository, 
            IRepository<Teacher> teacherRepository, IRepository<Group> groupRepository)
        {
            InitializeComponent();
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _groupRepository = groupRepository;
        }
    }
}
