// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

string c = "2800"; //code
int t = 10; //attempts

bool code_found = false;
// int t_i = 0; //attempt counter
// string[] c_array = char.ToCharArray();

// int[] digits = c.ToString().ToCharArray().Select(Convert.ToInt32).ToArray();
int[] digits = c.Select(x => x - 48).ToArray();


// Console.WriteLine(digits.ToString());

foreach (var item in digits)
{
    Console.WriteLine(item.ToString());
}

// for (int i = 0; i < c_array.Length; i++)
// {
//     Console.WriteLine("Hello, World!");
// }


// while (!code_found && t_i < 10)
// {

// }
