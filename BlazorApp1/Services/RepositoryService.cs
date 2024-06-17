using BlazorApp1.Components.Pages;
using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly MyAppContext _context;

        public RepositoryService(MyAppContext context)
        {
            _context = context;
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
    }
}

