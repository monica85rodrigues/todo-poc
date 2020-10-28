using System.Threading.Tasks;

namespace TodoList.UseCases
{
    public interface IUseCase<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
    
    public interface IUseCase<TRequest>
    {
        void Execute(TRequest request);
    }

    public interface IUseCaseAsync<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
    
    public interface IUseCaseAsync<TRequest>
    {
        Task ExecuteAsync(TRequest request);
    }
}