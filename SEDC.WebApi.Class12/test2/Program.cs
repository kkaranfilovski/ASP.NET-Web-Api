//input = l1 = [2,4,3] l2= [5,6,4]
// output = [7, 0 , 8]
// explanation = 465 + 342 = 807.

var list1 = new List<int> { 2, 4, 3 };
var list2 = new List<int> { 5, 6, 4 };
var num1 = 0;
var num2 = 0;

var divider1 = list1.Count * 10;
var divider2 = list2.Count * 10; // 100

for (int i = list2.Count - 1; i >= 0; i--)
{
    Console.WriteLine(list2[i]);
    num1 += list2[i] * divider2; // 4 * 100
    //Console.WriteLine(num1);

    divider2 = divider2 % 10;
}

Console.WriteLine(num1);