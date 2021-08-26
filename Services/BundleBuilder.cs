using System.Threading;

namespace BundleBuilderJP.Services.Actions
{
    public class Bundle
    {
        public static void Builder()
        {
            Actions.BatExecute(1);
            Thread.Sleep(3000);
            Actions.BatExecute(2);
            Thread.Sleep(3000);
            Actions.BackupToDirectory();
            Actions.ExtractToDirectory();
            Actions.MergeDirectory();
            Actions.DeleteItem();

        }

    }

}