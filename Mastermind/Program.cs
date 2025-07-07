// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// Helper functions **************************

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

// guess to int array -- return empty array if guess in invalid
// guess is valid a format if: it only has 4 numbers within 0-8
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




// main *********************************

// default values
string code_string = ""; //code
int attempts = 10; //attempts
int[] code = random_code();

// rewrite values if specified by player
for (int i = 0; i < args.Length; i++)
{
    if (args[i] == "-c" && i + 1 < args.Length)
    {
        code_string = args[i + 1];
        int[] converted_code = convert_guess(code_string);

        // in case provided code is invalid
        if (converted_code.Length == 0)
        {
            Console.WriteLine("\nInvalid code provided via -c. Will use another random code.\n");
        }
        else
        {
            code = converted_code;
        }

        i++;
    }

    else if (args[i] == "-t" && i + 1 < args.Length)
    {
        Int32.TryParse(args[i + 1], out attempts);
        i++;
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

            Console.WriteLine("Well placed pieces: " + score[0]);
            Console.WriteLine("Misplaced pieces: " + score[1]);
        }
    }

    round++;
}