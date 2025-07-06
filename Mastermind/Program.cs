// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// guess to int array -- return empty array if guess in invalid
// guess is valid a format if: it only has 4 numbers within 0-8
static int[] convert_guess(string guess)
{
    int[] result = { };

    // check length = 4
    if (guess.Length == 4)
    {
        // check guess is a numbers -- parse to int
        if (int.TryParse(guess, out _))
        {
            // convert to array 
            int[] guess_array = guess.Select(x => x - 48).ToArray();

            // check there's no 9
            if (!guess_array.Contains(9))
            {
                // if all checks pass, return array, else return -1, means guess is invalid
                result = guess_array;
            }

        }
    }

    // guess invalid
    return result;
}


string c = "2800"; //code
int t = 10; //attempts

bool code_found = false;
int attempt_counter = 0; //attempt counter
int[] c_array = c.Select(x => x - 48).ToArray();

string guess = "3048"; //code

Console.WriteLine("is valid? " + string.Join(", ", convert_guess(guess)));



// while (!code_found && t_i < 10)
// {

// }
