using Domain.Entities;
using ServicePattern;

namespace Service
{
    public interface IUserService:IService<User>
    {
    }
}