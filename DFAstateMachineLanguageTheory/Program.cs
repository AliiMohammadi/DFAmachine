public class Progrm
{
    //0 = null
    //a = 1
    //b = 2
    //a,b = 3
    static int[,] States = new int[,]
    {
        //    0 1 2 3 4 5 6 7 8 9 10 
        /*0*/{0,0,1,0,0,0,2,0,0,0, 0},
        /*1*/{0,0,1,0,0,0,0,0,0,0, 0},
        /*2*/{0,0,0,2,1,0,0,0,0,0, 0},
        /*3*/{0,0,0,2,1,0,0,0,0,0, 0},
        /*4*/{0,0,0,0,0,1,0,0,0,0, 0},
        /*5*/{0,0,0,0,0,0,2,0,0,0, 0},
        /*6*/{0,0,0,0,0,0,0,2,0,0, 0},
        /*7*/{0,0,0,0,0,0,0,0,0,0, 1},
        /*8*/{0,0,0,0,0,0,0,0,0,0, 1},
        /*9*/{0,0,0,0,0,2,0,0,0,0, 0},
       /*10*/{0,0,0,0,0,2,0,0,0,0, 1},
    };

    //0 -> No error
    //1 -> a error
    //2 -> b error
    //3 -> a,b error

    static int[] Traps = new int[] {0,2,0,0,2,1,1,2,2,1,0};

    // L = (ab*aa / bba*ab)
    static void Main()
    {
        string[] Input = new string[] {"abaa","bbaab","abbbaa","aabaa","bbbaab","bababa"};

        foreach (string input in Input)
            Console.WriteLine(IsDomain(input, States, Traps));
    }

    //Only suports Σ = {a,b}
    static bool IsDomain(string input,int[,] states,int[] traps)
    {
        int statecount = traps.Length;
        int currentstate = 0; // Current State index

        for (int i = 0; i < input.Length; i++)
        {

            if (traps[currentstate] == 3) 
                return false;// Ended up in deadend.

            switch (input[i])
            {
                case 'a':
                    if (traps[currentstate] == 1) 
                        return false; // Stuck on the trap

                    bool flag = false;

                    for (int j = 0; j < statecount; j++)
                    {
                        if (states[currentstate, j] == 1 || states[currentstate, j] == 3)
                        {
                            currentstate = j;
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                        return false; //Path not founed
                    else
                        break;

                case 'b':
                    if (traps[currentstate] == 2)
                        return false; // Stuck on the trap

                    bool flag2 = false;

                    for (int j = 0; j < statecount; j++)
                    {
                        if (states[currentstate, j] == 2 || states[currentstate, j] == 3)
                        {
                            currentstate = j;
                            flag2 = true;
                            break;
                        }
                    }
                    if (!flag2)
                        return false;//Path not founed
                    else
                        break;

                default: 
                    return false; // not in the domain 
            }
        }

        return true;
    }
} // Ali Mohammadi

// TESTS
/*
 *     static int[,] SIMPLEStates = new int[,]
    {
        { 0, 1, 0},
        { 0, 0, 2},
        { 0, 0, 0},
    };
    static int[,] ORStates = new int[,]
    {
        { 0, 1, 2, 0, 0 },
        { 0, 0, 0, 1, 0 },
        { 0, 0, 0, 0, 1 },
        { 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0 },
    };
    static int[,] LOOPStates = new int[,]
    {
        {1,2},
        {2,0},
    };
    static int[] SIMPLETraps = new int[] {2,1,3};
    static int[] ORTraps = new int[] {0,2,2,3,3};
    static int[] LOOPTraps = new int[] {0,1};
 */