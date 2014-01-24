using System.Windows;
namespace StairCalc
{
    class Messages
    {
        public static void missing()
        {
            MessageBox.Show("Please input a dimension", "Missing dimension",
            MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static void boundrys()
        {
            MessageBox.Show("The dimensions must be between \n 440mm and 3300mm", "Dimentions out of boundrys",
            MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static void fileInUse()
        {
            MessageBox.Show
    ("The file is in use by another program, \n could not save \n eather close the other program \n or save as a different name", "File in use",
            MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public static void noData()
        {
            MessageBox.Show("There is no data to save", "No data",
            MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static void exit(string Results)
        {
            if (Results == "")                                          //Exit anyway if there is no data present
            { System.Environment.Exit(0); }
            else if (Results != "")                                     //Show message if data is present and ask if they want to exit
            {
                MessageBoxResult Answer = MessageBox.Show("Exit without saving?", "Confirmation",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (Answer == MessageBoxResult.No)
                { return; }                                                    //Keep program running so they can save
                else
                { System.Environment.Exit(0); }                               //Exit if they do want to exit without saving
            }
        }

    }
}
