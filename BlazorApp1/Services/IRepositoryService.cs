using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public interface IRepositoryService
    {
        Task<List<StudentCoursesDto>> GetStudentCoursesAsync(int studentId);
        Task<List<TeacherScheduleDto>> GetTeacherScheduleAsync(int accountId);
        Task<List<CleanerScheduleDto>> GetCleanerScheduleAsync(int accountId);
        Task<List<TeacherViewModel>> GetAllTeachersAsync();
        Task<List<StudentViewModel>> GetAllStudentsAsync();
        Task<List<BoardingMemberViewModel>> GetAllBoardingMembersAsync();
        Task<List<CleanerViewModel>> GetAllCleanersAsync();
        Task AddStudentAsync(StudentViewModel studentModel);
        Task UpdateStudentAsync(StudentViewModel studentModel);
        Task RemoveStudentAsync(StudentViewModel studentModel);
        Task AddCleanerAsync(CleanerViewModel cleanerModel);
        Task UpdateCleanerAsync(CleanerViewModel cleanerModel);
        Task RemoveCleanerAsync(CleanerViewModel cleanerModel);
        Task AddBoardingMemberAsync(BoardingMemberViewModel boardingMemberModel);
        Task UpdateBoardingMemberAsync(BoardingMemberViewModel boardingMemberModel);
        Task RemoveBoardingMemberAsync(BoardingMemberViewModel boardingMemberModel);
        Task UpdateTeacherAsync(TeacherViewModel teacherModel);
        Task RemoveTeacherAsync(TeacherViewModel teacherModel);
        Task<List<CourseViewModel>> GetAllCoursesAsync();
        Task AddCourseAsync(CourseViewModel courseModel);

    }
}
