using System.Linq;

namespace Jwt.Services;

public class UsersService : object, IUsersService
{
	#region Static Member(s)
	private System.Collections.Generic.List
		<UserManagement.Domain.Users.User>
		_users;

	protected System.Collections.Generic.List
		<UserManagement.Domain.Users.User> Users
	{
		get
		{
			if (_users is null || _users.Any() == false)
			{
				_users =
					new
					System.Collections.Generic.List
					<UserManagement.Domain.Users.User>();

				for (int index = 0; index <= 5; index++)
				{
					var user =
						new
						UserManagement.Domain.Users.User
						(username: $"Username{index}", password: "1234512345")
						{
							Id = index,
							LastName = $"Last Name {index}",
							FirstName = $"First Name {index}",
							EmailAddress = $"EmailAddress{index}@GMail.com",
						};

					switch (index)
					{
						case 0:
							{
								user.Role =
									UserManagement.Domain.Enums.UserType.User;

								break;
							}
						case 1:
							{
								user.Role =
									UserManagement.Domain.Enums.UserType.Admin;

								break;
							}
						case 2:
							{
								user.Role =
									UserManagement.Domain.Enums.UserType.Owner;

								break;
							}
						case 3:
							{
								user.Role =
									UserManagement.Domain.Enums.UserType.Programmer;

								break;
							}
						default:
							{
								user.Role = UserManagement.Domain.Enums.UserType.User;

								break;
							}
					}

					_users.Add(item: user);
				}
			}

			return _users;
		}
	}
	#endregion Static Member(s)

	#region Constructor(s)
	public UsersService
		(Infrastructure.Settings.Main setting) : base()
	{
		Settings = setting;

		_users =
			new
			System.Collections.Generic.List
			<UserManagement.Domain.Users.User>();
	}
	#endregion /Constructor(s)

	#region Property(ies)
	protected Infrastructure.Settings.Main Settings { get; }
	#endregion /Property(ies)

	#region Get All
	public System.Collections.Generic.IList
		<UserManagement.Domain.Users.User> GetAll()
	{
		var foundedUsers = Users;

		return foundedUsers;
	}
	#endregion /Get All

	#region Get All Async
	public async
		System.Threading.Tasks.Task
		<System.Collections.Generic.IList
		<UserManagement.Domain.Users.User>> GetAllAsync()
	{
		var foundedUsers = Users;

		await System.Threading.Tasks.Task.CompletedTask;

		return foundedUsers;
	}
	#endregion /Get All Async

	#region Get By Id
	public UserManagement.Domain.Users.User? GetById(int id)
	{
		var foundedUser =
			Users
			.Where(current => current.Id == id)
			.FirstOrDefault();

		return foundedUser;
	}
	#endregion /Get By Id

	#region Get By Id Async
	public async
		System.Threading.Tasks.Task
		<UserManagement.Domain.Users.User?>
		GetByIdAsync(int id)
	{
		var foundedUser =
			Users
			.Where(current => current.Id == id)
			.FirstOrDefault();

		await System.Threading.Tasks.Task.CompletedTask;

		return foundedUser;
	}
	#endregion /Get By Id Async

	#region Login
	public
		UserManagement.ViewModels.Users.LoginResponseViewModel?
		Login(UserManagement.ViewModels.Users.LoginRequestViewModel viewModel)
	{
		if (viewModel is null)
		{
			return null;
		}
		else if (string.IsNullOrWhiteSpace(value: viewModel.Password))
		{
			return null;
		}
		else if (string.IsNullOrWhiteSpace(value: viewModel.Username))
		{
			return null;
		}

		var foundedUser =
			Users
			.Where(current => current.Username.ToLower() == viewModel.Username.ToLower())
			.FirstOrDefault();

		if (foundedUser is null)
		{
			return null;
		}

		if (string.Compare(strA: foundedUser.Password, strB: viewModel.Password, ignoreCase: false) != 0)
		{
			return null;
		}

		var token =
			Infrastructure.JwtUtility.GenerateJwtToken
			(user: foundedUser, setting: Settings);

		var response =
			new
			UserManagement.ViewModels.Users.LoginResponseViewModel
			(id: foundedUser.Id, username: foundedUser.Username,
			role: foundedUser.Role.ToString(), token: token);

		return response;
	}
	#endregion /Login

	#region Login Async
	public async
		System.Threading.Tasks.Task
		<UserManagement.ViewModels.Users.LoginResponseViewModel?>
		LoginAsync(UserManagement.ViewModels.Users.LoginRequestViewModel viewModel)
	{
		if (viewModel is null)
		{
			return null;
		}
		else if (string.IsNullOrWhiteSpace(value: viewModel.Password))
		{
			return null;
		}
		else if (string.IsNullOrWhiteSpace(value: viewModel.Username))
		{
			return null;
		}

		var foundedUser =
			Users
			.Where(current => current.Username.ToLower() == viewModel.Username.ToLower())
			.FirstOrDefault();

		if (foundedUser is null)
		{
			return null;
		}
		else if (string.Compare(strA: foundedUser.Password, strB: viewModel.Password, ignoreCase: false) != 0)
		{
			return null;
		}

		var token =
			Infrastructure.JwtUtility.GenerateJwtToken
			(user: foundedUser, setting: Settings);

		var response =
			new
			UserManagement.ViewModels.Users.LoginResponseViewModel
			(id: foundedUser.Id, username: foundedUser.Username,
			role: foundedUser.Role.ToString(), token: token);

		await System.Threading.Tasks.Task.CompletedTask;

		return response;
	}
	#endregion /Login Async
}
