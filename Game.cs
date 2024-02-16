using System;
using System.Collections.Generic;
using System.Threading;

namespace Game;

class Tetris
{
 static int[,] field = new int[20, 10]; // игровое поле
 static int currentShape;
 static int currentRotation;
 static int currentX;
 static int currentY;

 static void Game()
 {
  Console.WindowHeight = 30;
  Console.WindowWidth = 40;
  Console.BufferHeight = 30;
  Console.BufferWidth = 40;

  Console.Title = "Tetris";

  InitializeGame();

  while (true)
  {
   DrawField();
   ConsoleKeyInfo key = Console.ReadKey();
   ProcessKey(key);
  }
 }

 static void InitializeGame()
 {
  currentShape = 0; // начальная фигура
  currentRotation = 0; // начальное положение фигуры
  currentX = field.GetLength(1) / 2 - 2; // начальная позиция по горизонтали
  currentY = 0; // начальная позиция по вертикали

  // Генерируем первую фигуру
  GenerateShape();
 }

 static void DrawField()
 {
  Console.Clear();

  for (int i = 0; i < field.GetLength(0); i++)
  {
   for (int j = 0; j < field.GetLength(1); j++)
   {
    Console.SetCursorPosition(j * 2, i);
    if (field[i, j] == 0)
     Console.Write("  "); // пустая ячейка
    else
     Console.Write("██"); // заполненная ячейка
   }
  }

  Console.SetCursorPosition(0, field.GetLength(0) + 1);
  Console.Write("Score: 0"); // здесь можно отобразить счет игры или другую информацию
 }


 static void ProcessKey(ConsoleKeyInfo key)
 {
  switch (key.Key)
  {
   case ConsoleKey.LeftArrow:
    MoveShape(-1, 0); // движение влево
    break;
   case ConsoleKey.RightArrow:
    MoveShape(1, 0); // движение вправо
    break;
   case ConsoleKey.DownArrow:
    MoveShape(0, 1); // ускоренное падение
    break;
   case ConsoleKey.UpArrow:
    RotateShape(); // поворот фигуры
    break;
   default:
    break;
  }
 }


 static void MoveShape(int deltaX, int deltaY)
 {
  // Удаляем текущую фигуру с поля
  ClearCurrentShape();

  // Пытаемся переместить фигуру
  if (IsMoveValid(deltaX, deltaY))
  {
   currentX += deltaX;
   currentY += deltaY;
  }

  // Рисуем фигуру на новом месте
  DrawCurrentShape();
 }


 static void RotateShape()
 {
  // Удаляем текущую фигуру с поля
  ClearCurrentShape();

  // Пытаемся повернуть фигуру
  int newRotation = (currentRotation + 1) % 4; // Простой поворот на 90 градусов
  if (IsRotationValid(newRotation))
  {
   currentRotation = newRotation;
  }

  // Рисуем фигуру на новом месте
  DrawCurrentShape();
 }

 static void CheckRows()
 {
  for (int i = field.GetLength(0) - 1; i >= 0; i--)
  {
   bool isRowFull = true;
   for (int j = 0; j < field.GetLength(1); j++)
   {
    if (field[i, j] == 0)
    {
     isRowFull = false;
     break;
    }
   }

   if (isRowFull)
   {
    ClearRow(i);
    MoveRowsDown(i);
   }
  }
 }


 static void ClearRow(int row)
 {
  // Очистка содержимого заполненного ряда
  for (int j = 0; j < field.GetLength(1); j++)
  {
   field[row, j] = 0;
  }
 }


 static void GenerateShape()
 {
  // Простой пример: случайная генерация номера фигуры
  Random random = new Random();
  currentShape = random.Next(1, 8); // Здесь 1-7 представляют разные формы фигур

  // Начальные координаты для новой фигуры
  currentX = field.GetLength(1) / 2 - 2;
  currentY = 0;
  currentRotation = 0;

  // Рисуем новую фигуру
  DrawCurrentShape();
 }

}