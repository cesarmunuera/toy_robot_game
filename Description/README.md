# toy_robot_game
Simple robot game. This is repo contais a simple game, in C#.

Description & commands:
- "PLACE_ROBOT x,y,ORIENTATION": Place the robot into the input coordinates, if its empty. 

    Also writeable as "PLACE_ROBOT x, y, ORIENTATION".

- "PLACE_WALL x,y": Place the wall into the input coordinates, if its empty. 

    Also writeable as "PLACE_WALL x, y.

- "MOVE": Move the robot one step in its direction, if its empty.

    For example. If robot is in (1,1,NORTH), and (1,2,NORTH) is available, it will move to there.

- "RIGHT" or "LEFT": Will change the robot's direction, 90º to right or left.

- "REPORT": Return the position and orientation of the robot as "x,y,ORIENTATION".

Every command also available in lowercase.