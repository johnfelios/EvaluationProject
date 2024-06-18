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
        Task AddStudentAsync(StudentViewModel studentModel, string username, string password);
        Task RemoveStudentAsync(StudentViewModel studentModel);
    }
}
