using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace ThirdPartyAccessManagement.Repository
{
	public interface IMethodRepo
	{
		Method GetAll();
		Method GetById(int id);
	}

	public class EFMethodRepo
		: IMethodRepo
	{
		public Method GetAll()
		{
			throw new NotImplementedException();
		}

		public Method GetById(int id)
		{

			throw new NotImplementedException();
		}
	}

	public class DapperMethodRepo
		: IMethodRepo
	{
		public Method GetAll()
		{
			throw new NotImplementedException();
		}

		public Method GetById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
