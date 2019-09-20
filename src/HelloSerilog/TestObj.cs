using Serilog;

namespace HelloSerilog
{
    public class TestObj
    {
        public void LogSoming(){
            Log.ForContext(this.GetType()).Information("Test Log Information In TestObj");
            Log.ForContext(this.GetType()).Error("Test Log Error In TestObj");
            Log.ForContext(this.GetType()).Warning("Test Log Warning In TestObj");
        }

    }
}