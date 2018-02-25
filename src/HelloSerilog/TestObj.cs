using Serilog;

namespace HelloSerilog
{
    public class TestObj
    {
        public void LogSoming(){
            Log.ForContext(this.GetType()).Warning("Test Log Warning In TestObj");
        }

    }
}