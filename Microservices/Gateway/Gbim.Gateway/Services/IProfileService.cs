using System.Threading.Tasks;
using Gbim.Shared.DataContracts.Auth;
using Refit;

namespace Gbim.Gateway.Services {
    /// <summary> Сервис получения данных пользователя </summary>
    public interface IProfileService {
        /// <summary> Получение данных пользователя по логину </summary>
        [Get("/byLogin/{login}")]
        Task<ApiResponse<UserShortDto>> GetUserAccountByLoginAsync(string login);
        
        /// <summary> Получение данных пользователя по ИИН </summary>
        [Get("/byIin/{iin}")]
        Task<ApiResponse<UserShortDto>> GetUserAccountByIinAsync(string iin);
    }
}