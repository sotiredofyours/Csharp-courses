
namespace csharp_course;

public class Game
{
    private FieldType[] gameGrid;
    private Renderer renderer;
    private int marked = 0;

    public Game()
    {
        gameGrid = new FieldType[9];
        renderer = new Renderer();
    }

    public void Start()
    {
        for (int i = 0; i < gameGrid.GetLength(0); i++)
        { 
            gameGrid[i] = FieldType.Empty;
        }
        renderer.PrintGameBoard(gameGrid);
        var result = Play();
        var winMessage = result switch
        {
            GameResult.D => "It`s draw. GG",
            GameResult.L => "Player B won. GG",
            _ => "Player A won. GG"
        };
        Console.WriteLine(winMessage);
    }

    private GameResult Play()
    {
        while (true)
        {
            Console.WriteLine("Player A`s turn");
            if (MakeMove(true))
            {
                renderer.PrintGameBoard(gameGrid);
                return GameResult.W;
            }
            renderer.PrintGameBoard(gameGrid);
            if (marked == 9) return GameResult.D;
            
            Console.WriteLine("Player B`s turn");
            renderer.PrintGameBoard(gameGrid);
            if (MakeMove(false))
            {
                renderer.PrintGameBoard(gameGrid);
                return GameResult.L;
            }
            renderer.PrintGameBoard(gameGrid);
            if (marked == 9) return GameResult.D; 
           
        }
    }
    private bool MakeMove(bool player)
    {
        Console.Write("Enter number of field: ");
        int number = 0;
        if (int.TryParse(Console.ReadLine(), out number))
        {
            if (number <= 0 || number > 9)
            {
                Console.WriteLine("[x] Number must be in range 1-9");
                return MakeMove(player);
            }
        }
        else
        {
            Console.WriteLine("[x] Incorrect input. Input number in range 1-9");
            return MakeMove(player);
        }

        if (gameGrid[number-1] != FieldType.Empty)
        {
            Console.WriteLine($"[x] Field already marked with {gameGrid[number-1]}");
            return MakeMove(player);
        }
        
        if (player) gameGrid[number-1] = FieldType.X;
        else gameGrid[number-1] = FieldType.O;
        marked++;
        return IsWin();
    }
     private bool IsWin()
     {
         if (gameGrid[0] == gameGrid[1] && gameGrid[1] == gameGrid[2] && gameGrid[0] != FieldType.Empty) return true;
         if (gameGrid[0] == gameGrid[3] && gameGrid[3] == gameGrid[6] && gameGrid[0] != FieldType.Empty) return true;
         if (gameGrid[0] == gameGrid[4] && gameGrid[4] == gameGrid[8] && gameGrid[0] != FieldType.Empty) return true;
         if (gameGrid[1] == gameGrid[4] && gameGrid[4] == gameGrid[7] && gameGrid[1] != FieldType.Empty) return true;
         if (gameGrid[2] == gameGrid[5] && gameGrid[5] == gameGrid[8] && gameGrid[2] != FieldType.Empty) return true;
         if (gameGrid[3] == gameGrid[4] && gameGrid[4] == gameGrid[5] && gameGrid[3] != FieldType.Empty) return true;
         if (gameGrid[6] == gameGrid[7] && gameGrid[7] == gameGrid[8] && gameGrid[6] != FieldType.Empty) return true;
         if (gameGrid[2] == gameGrid[4] && gameGrid[4] == gameGrid[6] && gameGrid[2] != FieldType.Empty) return true;
         return false;
     }

}