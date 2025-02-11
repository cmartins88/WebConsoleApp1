using WebApplication1.Models;

namespace WebApplication1.Data
{
    public interface IData<T, Y> where T : class
    {
        public T Get(Y id);
    }
}
