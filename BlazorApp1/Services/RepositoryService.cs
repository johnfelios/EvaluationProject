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
                    StartDate = s.StartDate,
                    AccountId = s.AccountId 
                })
                .ToListAsync();


            var accountIds = students.Select(s => s.AccountId).Distinct().ToList();

            var accounts = await _context.Accounts
                .Where(a => accountIds.Contains(a.AccountId))
                .ToListAsync();

           
            var accountDict = accounts.ToDictionary(a => a.AccountId);

            foreach (var student in students)
            {
                if (accountDict.TryGetValue(student.AccountId, out var account))
                {
                    student.Username = account.Username;
                    student.Password = account.Password;
                }
            }
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
                    StartDate = t.StartDate,
                    AccountId = t.AccountId

                })
                .ToListAsync();

            var accountIds = teachers.Select(t => t.AccountId).Distinct().ToList();

            var accounts = await _context.Accounts
                .Where(a => accountIds.Contains(a.AccountId))
                .ToListAsync();


            var accountDict = accounts.ToDictionary(a => a.AccountId);

            foreach (var teacher in teachers)
            {
                if (accountDict.TryGetValue(teacher.AccountId, out var account))
                {
                    teacher.Username = account.Username;
                    teacher.Password = account.Password;
                }
            }
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
                    YearsOfService = bm.YearsOfService,
                    AccountId = bm.AccountId

                })
                .ToListAsync();

            var accountIds = boardingMembers.Select(bm => bm.AccountId).Distinct().ToList();

            var accounts = await _context.Accounts
                .Where(a => accountIds.Contains(a.AccountId))
                .ToListAsync();


            var accountDict = accounts.ToDictionary(a => a.AccountId);

            foreach (var boardingMember in boardingMembers)
            {
                if (accountDict.TryGetValue(boardingMember.AccountId, out var account))
                {
                    boardingMember.Username = account.Username;
                    boardingMember.Password = account.Password;
                }
            }
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
                StartDate = c.StartDate,
                AccountId = c.AccountId

                })
                .ToListAsync ();

            var accountIds = cleaners.Select(c => c.AccountId).Distinct().ToList();

            var accounts = await _context.Accounts
                .Where(a => accountIds.Contains(a.AccountId))
                .ToListAsync();


            var accountDict = accounts.ToDictionary(a => a.AccountId);

            foreach (var cleaner in cleaners)
            {
                if (accountDict.TryGetValue(cleaner.AccountId, out var account))
                {
                    cleaner.Username = account.Username;
                    cleaner.Password = account.Password;
                }
            }
            return cleaners;
        }


        public async Task AddCourseAsync(CourseViewModel courseModel)
        {
            var course = new Entities.Course
            {
                CourseTitle = courseModel.CourseTitle
            };
            await _context.Courses.AddAsync(course);

            await _context.SaveChangesAsync();
        }


        public async Task AddStudentAsync(StudentViewModel studentModel)
        {
            var account = new Account
            {
                Username = studentModel.Username,
                Password = studentModel.Password,
                AccountRole= Role.Student
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


        public async Task UpdateStudentAsync(StudentViewModel studentModel)
        {
            
            var existingStudent = await _context.Students
                .Include(s => s.Account) 
                .FirstOrDefaultAsync(s => s.AccountId == studentModel.AccountId);

            if (existingStudent != null)
            {
                
                existingStudent.FirstName = studentModel.FirstName;
                existingStudent.LastName = studentModel.LastName;
                existingStudent.Age = studentModel.Age;
                existingStudent.StartDate = studentModel.StartDate;

                existingStudent.Account.Username = studentModel.Username;
                existingStudent.Account.Password = studentModel.Password;

                await _context.SaveChangesAsync();
            }
            else
            {
                
                throw new ArgumentException("Student not found.");
            }
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


        public async Task AddCleanerAsync(CleanerViewModel cleanerModel)
        {
            var account = new Account
            {
                Username = cleanerModel.Username,
                Password = cleanerModel.Password,
                AccountRole = Role.Cleaner
            };
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();


            var cleaner = new Entities.Cleaner
            {
                FirstName = cleanerModel.FirstName,
                LastName = cleanerModel.LastName,
                Age = cleanerModel.Age,
                Wage = cleanerModel.Wage,
                StartDate = cleanerModel.StartDate,
                AccountId = account.AccountId
            };
            await _context.Cleaners.AddAsync(cleaner);

            await _context.SaveChangesAsync();
        }


        public async Task UpdateCleanerAsync(CleanerViewModel cleanerModel)
        {

            var existingCleaner = await _context.Cleaners
                .Include(c => c.Account)
                .FirstOrDefaultAsync(c => c.AccountId == cleanerModel.AccountId);

            if (existingCleaner != null)
            {

                existingCleaner.FirstName = cleanerModel.FirstName;
                existingCleaner.LastName = cleanerModel.LastName;
                existingCleaner.Age = cleanerModel.Age;
                existingCleaner.StartDate = cleanerModel.StartDate;

                existingCleaner.Account.Username = cleanerModel.Username;
                existingCleaner.Account.Password = cleanerModel.Password;

                await _context.SaveChangesAsync();
            }
            else
            {

                throw new ArgumentException("Cleaner not found.");
            }
        }


        public async Task RemoveCleanerAsync(CleanerViewModel cleanerModel)
        {
            var cleaner = await _context.Cleaners.
                FirstOrDefaultAsync(c => c.FirstName == cleanerModel.FirstName && c.LastName == cleanerModel.LastName);

            if (cleaner != null)
            {
                var accountId = cleaner.AccountId;

                _context.Cleaners.Remove(cleaner);

                var account = await _context.Accounts.FindAsync(accountId);
                if (account != null)
                {
                    _context.Accounts.Remove(account);
                }

                await _context.SaveChangesAsync();
            }
        }


        public async Task AddBoardingMemberAsync(BoardingMemberViewModel boardingMemberModel)
        {
            var account = new Account
            {
                Username = boardingMemberModel.Username,
                Password = boardingMemberModel.Password,
                AccountRole = Role.BoardingMember
            };
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();


            var boardingMember = new Entities.BoardingMember
            {
                FirstName = boardingMemberModel.FirstName,
                LastName = boardingMemberModel.LastName,
                Age = boardingMemberModel.Age,
                Wage = boardingMemberModel.Wage,
                StartDate = boardingMemberModel.StartDate,
                Position = boardingMemberModel.Position,
                YearsOfService = boardingMemberModel.YearsOfService,
                AccountId = account.AccountId
            };
            await _context.BoardingMembers.AddAsync(boardingMember);

            await _context.SaveChangesAsync();
        }


        public async Task UpdateBoardingMemberAsync(BoardingMemberViewModel boardingMemberModel)
        {

            var existingBoardingMember = await _context.BoardingMembers
                .Include(bm => bm.Account)
                .FirstOrDefaultAsync(bm => bm.AccountId == boardingMemberModel.AccountId);

            if (existingBoardingMember != null)
            {

                existingBoardingMember.FirstName = boardingMemberModel.FirstName;
                existingBoardingMember.LastName = boardingMemberModel.LastName;
                existingBoardingMember.Age = boardingMemberModel.Age;
                existingBoardingMember.StartDate = boardingMemberModel.StartDate;

                existingBoardingMember.Account.Username = boardingMemberModel.Username;
                existingBoardingMember.Account.Password = boardingMemberModel.Password;

                await _context.SaveChangesAsync();
            }
            else
            {

                throw new ArgumentException("Boarding Member not found.");
            }
        }


        public async Task RemoveBoardingMemberAsync(BoardingMemberViewModel boardingMemberModel)
        {
            var boardingMember = await _context.BoardingMembers.
                FirstOrDefaultAsync(bm => bm.FirstName == boardingMemberModel.FirstName && bm.LastName == boardingMemberModel.LastName);

            if (boardingMember != null)
            {
                var accountId = boardingMember.AccountId;

                _context.BoardingMembers.Remove(boardingMember);

                var account = await _context.Accounts.FindAsync(accountId);
                if (account != null)
                {
                    _context.Accounts.Remove(account);
                }

                await _context.SaveChangesAsync();
            }
        }


        public async Task UpdateTeacherAsync(TeacherViewModel teacherModel)
        {

            var existingTeacher = await _context.Teachers
                .Include(t => t.Account)
                .FirstOrDefaultAsync(t => t.AccountId == teacherModel.AccountId);

            if (existingTeacher != null)
            {

                existingTeacher.FirstName = teacherModel.FirstName;
                existingTeacher.LastName = teacherModel.LastName;
                existingTeacher.Age = teacherModel.Age;
                existingTeacher.StartDate = teacherModel.StartDate;

                existingTeacher.Account.Username = teacherModel.Username;
                existingTeacher.Account.Password = teacherModel.Password;

                await _context.SaveChangesAsync();
            }
            else
            {

                throw new ArgumentException("Teacher not found.");
            }
        }


        public async Task RemoveTeacherAsync(TeacherViewModel teacherModel)
        {
            var teacher = await _context.Teachers.
                FirstOrDefaultAsync(t => t.FirstName == teacherModel.FirstName && t.LastName == teacherModel.LastName);

            if (teacher != null)
            {
                var accountId = teacher.AccountId;

                _context.Teachers.Remove(teacher);

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

