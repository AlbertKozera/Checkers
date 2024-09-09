# Checker Game

## Overview

The project involves the development of a checkers game, implemented as part of a distributed systems class project at the Kielce University of Technology. The game is designed to be played on an 8x8 board with standard checkers rules and features both single-player and multiplayer modes.

## Gameplay

### Board Setup
- The game is played on an 8x8 board with alternating light and dark squares.
- Each player starts with twelve pieces placed on the dark squares of the board.

### Rules
- The game begins with the player using white pieces.
- Players alternate moves, starting with white, and must make a move if possible.
- Pieces move diagonally forward to an empty square.
- A piece that reaches the promotion square (b8, d8, f8, h8 for white; a1, c1, e1, g1 for black) becomes a king.
- Kings can move diagonally in all directions to any empty square.

### Capturing
- A piece can jump over an opponent’s piece to an empty square directly beyond it, capturing the opponent’s piece.
- Capturing is mandatory.
- Kings are not restricted to moving forward.

### King Rules
- If a king captures a piece, it must continue capturing any additional pieces if possible.

## Technology Stack

- **Programming Language:** C#
- **Framework:** .NET 4.7.2
- **Graphics:** GDI+ and Windows Forms
- **Logging:** NLog
- **Development Environment:** Microsoft Visual Studio 2019

## User Interface

The graphical interface is built using Windows Forms with various `UserControl` components. Key windows include:

- **Main Window:** Offers options to start a new game, access settings, or exit the application.
- **Options Window:** Allows configuration of multi-threading and player setup for "player vs. computer" games.
- **Game Selection Window:** Offers choices between "player vs. player", "player vs. computer", and "computer vs. computer" modes.
- **Game Window:** Displays the game board, piece counts for both players, and the current turn.

![image](https://github.com/user-attachments/assets/01a865c9-596d-4ba5-b3a3-8d8c43e930bb)

![image](https://github.com/user-attachments/assets/6bc17260-e913-421a-983b-9eea2bc559c6)

## Game Algorithm - Minimax

The game uses the Minimax algorithm for decision-making, which is common in turn-based games. The algorithm evaluates the best move by considering all possible future moves and their outcomes. It operates on the principle of maximizing the score for one player while minimizing it for the opponent.

![image](https://github.com/user-attachments/assets/51b4ef0b-2822-450c-a432-3d328fd25053)

- **Heuristic Scoring:**
  - Capturing a piece: 4 points
  - Moving to specific board zones: 1-3 points
  - Reaching promotion square: 5 points
  
![image](https://github.com/user-attachments/assets/afc0cf13-4c73-4e49-abeb-7c474ad5e0ae)

![image](https://github.com/user-attachments/assets/edad21f3-15ce-4b53-a514-ff811ea3294a)

## Pseudocode

Here is a simplified pseudocode representation of the Minimax algorithm:

![image](https://github.com/user-attachments/assets/737d16fe-8c2c-4cc9-b72e-a279c1e830ad)

## Logging

The application logs game events to the console and saves them to `.log` files. Logs include move indices, captures, turn information, and round durations.

## Multithreading

To handle recursive calculations, the application uses the `Parallel.ForEach` loop for distributed processing. Critical sections, such as score calculation in the `evaluateGameBoard()` method, are synchronized using `MethodImplOptions.Synchronized` to ensure accurate results.

## TCP/IP Connections

The game supports network play via TCP/IP. Users connect by entering the IP address and port number. The server handles game logic, while the client manages the interface. The `SimpleTCP` library facilitates connection management and message broadcasting between players.

## Unit Testing

Unit tests are conducted using MSTest v2, built into Visual Studio 2019. Tests cover various functionalities to ensure correct behavior, with results showing that all tests pass without errors.

## Performance Testing

Performance tests measure game duration for different depths and processors. Distributed computing significantly reduces computation time.

| Processor Model | Depth | Time [ms] (Non-distributed) | Time [ms] (Distributed) |
|-----------------|-------|-----------------------------|--------------------------|
| i5-6300HQ       | 1     | 444                         | 182                      |
|                 | 2     | 714                         | 243                      |
|                 | 3     | 2086                        | 1536                     |
|                 | 4     | 7579                        | 4482                     |
|                 | 5     | 37150                       | 32089                    |
|                 | 6     | 190970                      | 141946                   |
| i5-9600K        | 1     | 516                         | 495                      |
|                 | 2     | 724                         | 535                      |
|                 | 3     | 1511                        | 778                      |
|                 | 4     | 5012                        | 3099                     |
|                 | 5     | 22515                       | 13450                    |
|                 | 6     | 102827                      | 56234                    |
| i5-4440         | 1     | 339                         | 344                      |
|                 | 2     | 560                         | 545                      |
|                 | 3     | 1268                        | 771                      |
|                 | 4     | 4611                        | 3959                     |
|                 | 5     | 21204                       | 13539                    |
|                 | 6     | 110353                      | 66628                    |

## Conclusions

Application supports various gameplay modes (human vs. human / human vs. computer / computer vs. computer). The Minimax algorithm performs well, though future improvements could include alpha-beta pruning for enhanced efficiency. The project provided valuable experience in C#, multithreading, and algorithm implementation, highlighting the importance of resource management.
