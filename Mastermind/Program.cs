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


// returns [well-placed, misplaced]
static int[] guess_score(int[] code, int[] guess)
{
    int[] result = [0, 0];

    for (int i = 0; i < 4; i++)
    {
        // well-placed
        if (code[i] == guess[i])
        {
            result[0] = result[0] + 1;
        }

        // misplaced
        else if (code.Contains(guess[i]))
        {
            result[1] = result[1] + 1;
        }
    }

    return result;
}


// main *******

string code_int = "2800"; //code
int attempts = 10; //attempts
bool code_found = false;
int round = 0; //attempt counter
int[] code = code_int.Select(x => x - 48).ToArray();

// string guess_int = "3008"; //code
// int[] guess = convert_guess(guess_int);

Console.WriteLine("Will you find the secret code?\nPlease enter a valid guess");

while (!code_found && round < attempts)
{
    bool valid_guess = false;

    Console.WriteLine($"---\nRound {round}");

    while (!valid_guess)
    {
        // ask for input
        string guess_string = Console.ReadLine();
        int[] guess = convert_guess(guess_string);

        if (guess.Length == 0)
        {
            Console.WriteLine("\nWrong input!");
        }
        else
        {
            valid_guess = true;
            // get guess score
            int[] score = guess_score(code, guess);

            if (score[0] == 4)
            {
                Console.WriteLine("Congratz! You did it! ");
                code_found = true;
                break;
            }

            Console.WriteLine("Well placed pieces:" + score[0]);
            Console.WriteLine("Misplaced pieces:" + score[1]);
        }
    }

    round = round + 1;
}

// Console.WriteLine("is valid? " + string.Join(", ", guess));

// Console.WriteLine("score: " + string.Join(", ", guess_score(code, guess)));


// while (!code_found && t_i < 10)
// {

// }
