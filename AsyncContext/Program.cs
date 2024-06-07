namespace AsyncContext;

public class Program
{
    public static void Main(string[] args)
    {
        Program p = new Program();

        //Console.WriteLine($"Mano gautas int yra: { p.GetIntAsync().Result}");
        Task uzduotis = p.GetIntAsync();
        uzduotis.ContinueWith(t =>
        {
            if (t.IsFaulted)
            {
                Console.WriteLine("My task failed :(");
            }
            else
            {
                Console.WriteLine($"Task succeeded with result: {t}");
            }
        });

        var uzduotis2 = p.GetTuppleVariableAsync().Result;
        Console.WriteLine(uzduotis2.Item1 + " " + uzduotis2.Item2 + " " + uzduotis2.Item3);
        Console.ReadKey();
    }
    async void StartRandomPrints(Program p)
    {
        //p.SpausdintiRandom();
        //p.SpausdintiCounteri();
        // p.StartCiklas();
       
    }
    async Task SpausdintiRandom()
    {
        int i = 0;
        Random random = new Random();
        while(i < int.MaxValue)
        {
            Console.WriteLine($"Random Skaicius {random.Next(1, 100000000)}");
            await Task.Delay(500);
        }
    }
    async Task SpausdintiCounteri()
    {
        Random random = new Random();
        for( int i = 0; i < int.MaxValue; i++ )
        {
            Console.WriteLine($"Count {i}");
            await Task.Delay(200);
        }
    }
    async void StartCiklas()
    {
        for( int i = 0; i < int.MaxValue; i++ )
        {
            i = i+1;
            Console.WriteLine(i);
        }
    }
    public async Task<int> GetIntAsync()
    {
        int result = 0;
        for( int i = 0; i < 70000; i++ )
        {
            result = i;
            Console.WriteLine(i);
            if(i > 1000000000)
                throw new Exception("Pastrigo");
        }
        return result;
    }
    public async Task<Tuple<int, string, TaskStatus>> GetTuppleVariableAsync()
    {
        int result = 0;
        for (int i = 0; i < 70000; i++)
        {
            result = i;
            Console.WriteLine(i);
            if (i > 1000000000)
                throw new Exception("Pastrigo");
        }
        return new Tuple<int, string, TaskStatus>(result,"string kintamasis", TaskStatus.RanToCompletion);
    }
}