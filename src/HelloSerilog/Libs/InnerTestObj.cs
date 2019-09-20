using Serilog;

namespace HelloSerilog.Libs
{
    public class InnerTestObj
    {
        public void LogSoming(){
            Log.ForContext(this.GetType()).Information("Test2 Log Information In TestObj");
            Log.ForContext(this.GetType()).Error("Test2 Log Error In TestObj");
            Log.ForContext(this.GetType()).Warning("Test2 Log Warning In TestObj");
        }
    }
}