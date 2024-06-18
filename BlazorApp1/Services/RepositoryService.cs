using AutoMapper;
using BlazorApp1.Components.Pages;
using BlazorApp1.Data;
using BlazorApp1.Entities;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly MyAppContext _context;
        private readonly IMapper _mapper;

        public RepositoryService(MyAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<StudentCoursesDto>> GetStudentCoursesAsync(int accountId)
        {

            var courses = await _context.StudentsCourses
             .Where(sc => sc.StudentAccountId == accountId)
             .Select(sc => new StudentCoursesDto
             {
                 CourseTitle = sc.Course.CourseTitle,
                 OralMark = sc.OralMark,
                 WritingMark = sc.WritingMark
             })
             .ToListAsync();

            return courses;
        }


        public async Task<List<TeacherScheduleDto>> GetTeacherScheduleAsync(int accountId)
        {
            var teacherSchedules = await _context.Courses
                .Where(c => c.TeacherAccountId == accountId)
                .SelectMany(c => c.CourseTimeSlots)
                .Join(_context.TimeSlots,
                    cts => cts.TimeSlotId,
                    ts => ts.TimeSlotId,
                    (cts, ts) => new TeacherScheduleDto
                    {
                        CourseTitle = cts.Course.CourseTitle,
                        Day = ts.Day,
                        StartTime = ts.StartTime,
                        EndTime = ts.EndTime
                    })
                .ToListAsync();

            return teacherSchedules;
        }

        public async Task<List<CleanerScheduleDto>> GetCleanerScheduleAsync(int accountId)
        {

            var results = await _context.Cleaners
                .Where(c => c.AccountId == accountId)
                .Join(
                    _context.CleanerTimeSlots,
                    c => c.AccountId,
                    ct => ct.CleanerAccountId,
                    (c, ct) => new { Cleaner = c, CleanerTimeSlot = ct }
                )
                .Join(
                    _context.TimeSlots,
                    combined => combined.CleanerTimeSlot.TimeSlotId,
                    ts => ts.TimeSlotId,
                    (combined, ts) => new CleanerScheduleDto
                    {
                        Day = ts.Day,
                        StartTime = ts.StartTime,
                        EndTime = ts.EndTime
                    }
                )
                .ToListAsync(); ;

            return results;
        }


        public async Task<List<StudentViewModel>> GetAllStudentsAsync()
        {
            var students = await _context.Students
                .Select(s => new StudentViewModel
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Age = s.Age,
                    StartDate = s.StartDate
                })
                .ToListAsync();

            return students;

        }

        public async Task<List<TeacherViewModel>> GetAllTeachersAsync()
        {
            var teachers = await _context.Teachers
                .Select(t => new TeacherViewModel
                {
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Age = t.Age,
                    Wage = t.Wage,
                    StartDate = t.StartDate
                })
                .ToListAsync();

            return teachers;
        }

        public async Task<List<BoardingMemberViewModel>> GetAllBoardingMembersAsync()
        {
            var boardingMembers = await _context.BoardingMembers
                .Select(bm => new BoardingMemberViewModel
                {
                    FirstName = bm.FirstName,
                    LastName = bm.LastName,
                    Age = bm.Age,
                    Wage = bm.Wage,
                    StartDate = bm.StartDate,
                    Position = bm.Position,
                    YearsOfService = bm.YearsOfService
                })
                .ToListAsync();

            return boardingMembers;
        }

        public async Task<List<CleanerViewModel>> GetAllCleanersAsync()
        {
            var cleaners = await _context.Cleaners
                .Select(c => new CleanerViewModel
                { FirstName = c.FirstName,
                LastName = c.LastName,
                Age = c.Age,
                Wage = c.Wage,
                StartDate = c.StartDate
                })
                .ToListAsync ();

            return cleaners;
        }

        public async Task AddStudentAsync(StudentViewModel studentModel, string username, string password)
        {
            var account = new Account
            {
                Username = username,
                Password = password
            };
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();


            var student = new Entities.Student
            {
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Age = studentModel.Age,
                StartDate = studentModel.StartDate,
                AccountId = account.AccountId
            };
            await _context.Students.AddAsync(student); 

            await _context.SaveChangesAsync();
        }

        public async Task RemoveStudentAsync(StudentViewModel studentModel)
        {
            var student = await _context.Students.
                FirstOrDefaultAsync(s =>s.FirstName == studentModel.FirstName && s.LastName == studentModel.LastName);

            if (student != null)
            {
                var accountId = student.AccountId;

                _context.Students.Remove(student);

                var account = await _context.Accounts.FindAsync(accountId);
                if (account != null)
                {
                    _context.Accounts.Remove(account);
                }

                await _context.SaveChangesAsync();
            }
        }

    }
}

