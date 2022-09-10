//Input: nums = [2, 7, 11, 15], target = 9
//Output: [0,1]
//Explanation: Because nums[0] +nums[1] == 9, we return [0, 1].

var list = new List<int>
{
    2, 7, 11 , 15
};

var list2 = new List<int>
{
    3,2,4
};

var list3 = new List<int>
{
    3,3
};

var target1 = 9;
var target2 = 6;
var target3 = 6;

var res1 = task1(list, target1);
var res2 = task1(list2, target2);
var res3 = task1(list3, target3);

Console.WriteLine("==========================");
foreach (var item in res1)
{
    Console.WriteLine(item);    
}
Console.WriteLine("==========================");
foreach (var item in res2)
{
    Console.WriteLine(item);
}
Console.WriteLine("==========================");
foreach (var item in res3)
{
    Console.WriteLine(item);
}

static List<int> task1(List<int> list, int target)
{
    var result = new List<int>();

    for (int i = 0; i < list.Count; i++)
    {
        var num1 = list[i];
        for (int j = i + 1; j < list.Count; j++)
        {
            if(num1 + list[j] == target)
            {
                result.Add(i);
                result.Add(j);
                    
            }
        }
    }

    return result;
    
}