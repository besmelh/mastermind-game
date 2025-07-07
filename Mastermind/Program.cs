// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// guess to int array -- return empty array if guess in invalid
// guess is valid a format if: it only has 4 numbers within 0-8
using System.Security.Permissions;

static int[] convert_guess(string guess)
{
    // protective step
    if (guess == null) return Array.Empty<int>();

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

// random code with distinct pieces
static int[] random_code()
{
    Random random = new Random();
    List<int> pieces = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    int[] code = new int[4];

    for (int i = 0; i < 4; i++)
    {
        int rand_i = random.Next(0, pieces.Count);
        code[i] = pieces[rand_i];
        pieces.RemoveAt(rand_i);
    }

    return code;
}


// main *******


// default values
string code_string = ""; //code
int attempts = 10; //attempts
int[] code = random_code();

// rewrite values if specified by player
Console.WriteLine("args:", args.Length);
for (int i = 0; i < args.Length; i++)
{
    int c_i = Array.FindIndex(args, x => x.Contains("-c"));
    if (c_i != -1)
    {
        code_string = args[c_i + 1];
        code = code_string.Select(x => x - 48).ToArray();
    }

    int t_i = Array.FindIndex(args, x => x.Contains("-t"));
    if (t_i != -1)
    {
        attempts = Int32.Parse(args[t_i + 1]);
    }
}



bool code_found = false;
int round = 0; //attempt counter

Console.WriteLine("Will you find the secret code?\nPlease enter a valid guess");
// Console.WriteLine($"code: {string.Join(", ", code)}");
// Console.WriteLine($"attempts: {attempts}");

while (!code_found && round < attempts)
{
    bool valid_guess = false;

    Console.WriteLine($"---\nRound {round}");

    while (!valid_guess)
    {
        // ask for input
        Console.Write(">");
        string guess_string = Console.ReadLine();

        // in case string is null - mainly for EOF handling
        if (guess_string == null)
        {
            Console.WriteLine("\nEnd of input detected. Exiting game.");
            Environment.Exit(0); // clean exit
        }

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

