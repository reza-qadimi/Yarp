using UserManagement.ViewModels.Users;

namespace Jwt.Services
{
	public interface IUsersService
	{
		#region Get By Id
		UserManagement.Domain.Users.User? GetById(int id);

		System.Threading.Tasks.Task
			<UserManagement.Domain.Users.User?> GetByIdAsync(int id);
		#endregion /Get By Id

		#region Get All
		System.Collections.Generic.IList<UserManagement.Domain.Users.User> GetAll();

		System.Threading.Tasks.Task
			<System.Collections.Generic.IList
			<UserManagement.Domain.Users.User>> GetAllAsync();
		#endregion /Get All

		#region Login
		LoginResponseViewModel?
			Login
			(LoginRequestViewModel viewModel);

		System.Threading.Tasks.Task
			<LoginResponseViewModel?>
			LoginAsync(LoginRequestViewModel viewModel);
		#endregion Login
	}
}
