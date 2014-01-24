
namespace StairCalc
{
    class Tables
    {
    public static int riserTable (int dimFromInput)
    {
        int dimint = (dimFromInput);
        int ris;

        if (dimint >= 3000 && dimint <= 3300)                                //Stair table to calculate the number of risers
        { ris = (16); }
        else if (dimint >= 2800 && dimint <= 2999)
        { ris = (15); }
        else if (dimint >= 2600 && dimint <= 2799)
        { ris = (14); }
        else if (dimint >= 2400 && dimint <= 2599)
        { ris = (13); }
        else if (dimint >= 2200 && dimint <= 2399)
        { ris = (12); }
        else if (dimint >= 1980 && dimint <= 2199)
        { ris = (11); }
        else if (dimint >= 1760 && dimint <= 1979)
        { ris = (10); }
        else if (dimint >= 1540 && dimint <= 1759)
        { ris = (9); }
        else if (dimint >= 1320 && dimint <= 1539)
        { ris = (8); }
        else if (dimint >= 1100 && dimint <= 1319)
        { ris = (7); }
        else if (dimint >= 880 && dimint <= 1099)
        { ris = (6); }
        else if (dimint >= 660 && dimint <= 879)
        { ris = (5); }
        else
        { ris = (4); }
        return ris;    
       }
    public static int totalGoing(int riserDim1, int risNo1)
    {
        int toGo;
        int risDim = (riserDim1);
        int ris = (risNo1);
        if (risDim < 180)

        { toGo = ((risDim + 20) * (ris - 1)); }   //Table to calculate the total going
        else
        { toGo = ((risDim + 25) * (ris - 1)); }
        return toGo;
    }
    public static int inividualGoing(int riserDim2)
    {
        int risDim = (riserDim2);                         
        int Go;
        
        if (risDim < 180)                          //Table to calculate the inividual going
        { Go = risDim + 20; }
        else
        { Go = risDim + 25; }
        return Go;
    }
        
    public static int bottom(int riserDim3, int risNo2)
    {
        int risDim = (riserDim3);
        int ris = (risNo2);
        int bot;

        if (risDim < 180)                          //Table to calculate the bottom for hypotenuse calculation
        { bot = ((risDim + 20) * ris); }
        else
        { bot = ((risDim + 25) * ris); }
        return bot;
    }
  }
}
