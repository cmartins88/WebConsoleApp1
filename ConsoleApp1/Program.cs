using System.Collections;
using System.Net.Http.Json;
using System.Net.NetworkInformation;

namespace WebConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            const string url = "https://en.wikipedia.org/w/api.php?action=query&titles=Cristiano%20Ronaldo&prop=revisions&rvprop=content&format=json";
            const string weatherForecastUrl = "http://localhost:5062/api/WeatherForecast";

            HttpClient client = new HttpClient();

            var response = await client.GetFromJsonAsync<WeatherForecast[]>(weatherForecastUrl);

            Console.WriteLine("Wikipedia API Response:");
            foreach (WeatherForecast r in response)
            { 
                Console.WriteLine($"{r.Date} - {r.Summary}");
            }

            A a1 = new A();
            A a2 = new A();
            B b1 = new B();
            B b2 = new B();

            a1.Export();
            a2.Export();

            IExportable a3 = (IExportable)new A();

            ExportAllAsync(a1);
            ExportAllAsync(b1);

            Manager m = Manager.getInstance();
            m.ToString();

            int m1 = 1;
            C c = new C();
            Method1(ref m1, c);
            Console.WriteLine(m1);

            Action action = ActionHandler;
            Action<Exception> fallback = FallbackHandler;
            ExportAllAsync(a3, action, fallback);
        }

        public static void ActionHandler()
        {
            Console.WriteLine("Exportação concluida com sucesso!!");
        }

        public static void FallbackHandler(Exception error)
        {
            Console.WriteLine(error.Message);
        }

        public async static void ExportAllAsync(IExportable exp, Action callback = null, Action<Exception> fallback = null)
        {
            try
            {
                await exp.Export();
                callback?.Invoke();
            } catch (Exception ex) 
            {
                fallback?.Invoke(ex);
            }
        }

        public static void Method1(ref int a, C c)
        {
            a = 10;
        }

        public class A : IExportable
        {
            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public async Task Export()
            {
                throw new NotImplementedException();
            }

            public IEnumerator<string> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            bool IEquatable<IExportable>.Equals(IExportable? other)
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public class B : IExportable
        {
            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public async Task Export()
            {
                throw new NotImplementedException();
            }

            public IEnumerator<string> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            bool IEquatable<IExportable>.Equals(IExportable? other)
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public sealed class C : B { }

        public interface IExportable : IEnumerable<string>, IEquatable<IExportable>, IDisposable
        {
            public Task Export();
        }

        public abstract class D
        {
            public abstract void Export();
        }
    
    
    
    
    
        public class Manager
        {
            private Manager () { }

            private static volatile Manager _instance;

            public static Manager getInstance() {
                if(_instance == null) { _instance = new Manager(); }
                return _instance;
            }
        }
    }
}
