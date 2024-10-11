using NWEB01.Application.DTOs;
using NWEB01.Domain.Entities;
using NWEB01.Domain.Interfaces;
using NWEB01.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Application.Services.UserService
{
	public class UserServices : IUserService
	{

		private IUserRepository userRepository;

		public UserServices(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public Task<PaginationList<UserDTO>> GetUsers(UserSpeParam userSpeParam)
		{
			int skip = (userSpeParam.pageIndex - 1) * userSpeParam.pageSize;
			int take = userSpeParam.pageSize;

			var spec = new BaseSpecification<User>(x =>
				(string.IsNullOrEmpty(userSpeParam.Search) || x.Name.Contains(userSpeParam.Search)) &&
				(!userSpeParam.Role.HasValue || x.Role == userSpeParam.Role)
			);

			userRepository.GetAll(spec);

			throw new NotImplementedException();
		}
	}
}
