namespace DotNet_Assignemnts.RepeatedElements;

public  class Application
{
    public static void Start(string[] args)
    {
        int[] ar = { 1, 2, 3, 4, 5, 6, 1, 1, 2 };

        RepeatedElements.CountOfEachElement(ar);
        RepeatedElements.RemoveDuplicates(ar);
    }
   
}
