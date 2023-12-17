int[,] NewScreenMatrix()
{
    int[,] screenMatrix = new int[20,10];
    for (int i = 0; i < screenMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < screenMatrix.GetLength(1); j++)
        {
            screenMatrix[i, j] = 0;
        }
    }
    return screenMatrix;
}
string PrintCell(int cellInt)
{
    string cellImage = "";
    if (cellInt == 0) cellImage = "[ ]";
    if (cellInt == 1) cellImage = "[0]";
    return cellImage;
}
void PrintScreen(int[,] screenMatrix)
{
    for (int i = 0; i < screenMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < screenMatrix.GetLength(1); j++)
        {
            Console.Write(PrintCell(screenMatrix[i, j]));
        }
        Console.WriteLine();
    }
}
int[,] NewFigureMatrix()
{
    int[,] figureMatrix = new int[,]
    {
        {0,0,0,0},
        {0,0,0,0},
        {0,0,0,0},
        {0,0,0,0},
    };
    int randFigureMatrix = new Random().Next(1, 7);
    if (randFigureMatrix == 1) // Фигура -|
    {
        figureMatrix[0, 1] = 1;
        figureMatrix[1, 0] = 1;
        figureMatrix[1, 1] = 1;
        figureMatrix[2, 1] = 1;
    }
    if (randFigureMatrix == 2) // Фигура |
    {
        figureMatrix[0, 0] = 1;
        figureMatrix[1, 0] = 1;
        figureMatrix[2, 0] = 1;
        figureMatrix[3, 0] = 1;
    }
    if (randFigureMatrix == 3) // Фигура Г
    {
        figureMatrix[0, 0] = 1;
        figureMatrix[0, 1] = 1;
        figureMatrix[1, 0] = 1;
        figureMatrix[2, 0] = 1;
    }
    if (randFigureMatrix == 4) // Фигура L
    {
        figureMatrix[0, 0] = 1;
        figureMatrix[1, 0] = 1;
        figureMatrix[2, 0] = 1;
        figureMatrix[2, 1] = 1;
    }
    if (randFigureMatrix == 5) // Фигура o
    {
        figureMatrix[0, 0] = 1;
        figureMatrix[0, 1] = 1;
        figureMatrix[1, 0] = 1;
        figureMatrix[1, 1] = 1;
    }
    if (randFigureMatrix == 6) // Фигура z
    {
        figureMatrix[0, 1] = 1;
        figureMatrix[1, 0] = 1;
        figureMatrix[1, 1] = 1;
        figureMatrix[2, 0] = 1;
    }
    if (randFigureMatrix == 7) // Фигура s
    {
        figureMatrix[0, 0] = 1;
        figureMatrix[1, 0] = 1;
        figureMatrix[1, 1] = 1;
        figureMatrix[2, 1] = 1;
    }
    return figureMatrix;
}
int[,] InputFigureScreenMatrix(int[,] oldScreenMatrix, int[,] figureMatrix, int rowIndex, int columnIndex)
{
    int[,] newScreenMatrix = oldScreenMatrix;
    for (int x = rowIndex, i = 0; x < figureMatrix.GetLength(0)+rowIndex; x++, i++)
    {
        for (int y = columnIndex, j = 0; y < figureMatrix.GetLength(1)+columnIndex; y++, j++)
        {
            newScreenMatrix[x, y] = figureMatrix[i, j];
        }
    }
    return newScreenMatrix;
}

//------------------------

int[,] screenMatrixMain = NewScreenMatrix();
int firstFigureRowIndex = 0, firstFigureColumnIndex = 4;
ConsoleKeyInfo keyInfo;
while (true) 
{
    int[,] FigureMatrix = NewFigureMatrix();
    int figureRowIndex = firstFigureRowIndex, figureColumnIndex = firstFigureColumnIndex;
    Console.Clear();
    while (true)
    {
        int[,] newScreenMatrixMain = InputFigureScreenMatrix(screenMatrixMain, FigureMatrix, figureRowIndex, figureColumnIndex);
        Console.Clear();
        PrintScreen(newScreenMatrixMain);
        keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.RightArrow)
        {
            figureColumnIndex++;
            newScreenMatrixMain = screenMatrixMain;
        }
        if (keyInfo.Key == ConsoleKey.LeftArrow)
        {
            figureColumnIndex--;
            newScreenMatrixMain = screenMatrixMain;
        }
        if (keyInfo.Key == ConsoleKey.UpArrow) 
        {
            figureRowIndex--;
            newScreenMatrixMain = screenMatrixMain;
        }
        if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            figureRowIndex++;
            newScreenMatrixMain = screenMatrixMain;
        }
        if (keyInfo.Key == ConsoleKey.Enter)
        {
            screenMatrixMain = newScreenMatrixMain;
            break;
        }
        if (keyInfo.Key == ConsoleKey.Q) return;
    }


//-------------------------------------------
    keyInfo = Console.ReadKey();
    if (keyInfo.Key == ConsoleKey.Q) return;
}