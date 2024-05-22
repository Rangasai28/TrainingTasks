namespace DotNet_Assignemnts.CharOccurence;

public static  class Application
{
    public static void Start(string[] args)
    {
        CharOccurence charOccurence = new CharOccurence();
        string str = "bala ranga sai";

        charOccurence.countOfEachChar(str);
    }

}
