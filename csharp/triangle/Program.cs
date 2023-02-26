char MAIN_CHAR = '#';
char BLANK_CHAR = ' ';
int MAX_ROWS = 15;
int MAX_DIR = 50;
int TARGET_FPS = 60;


string s;
int offset = 0;
int direction = 1;


void drawFrame(int i, int offset) {
  s = "";
  for (int j = 0; j < MAX_ROWS + offset - i; j++) {
    s += BLANK_CHAR;
  }
  for (int j = 0; j <= i * 2; j++) {
    s += MAIN_CHAR;
  }

  Console.WriteLine("[" + direction + "]" + offset + " " + s);
}

while (true) {
  Console.Clear();

  if (offset == 0) {
    direction = 1;
  } else if (offset == MAX_DIR) {
    direction = -1;
  }

  if (direction == 1) {
    for (int i = 0; i < MAX_ROWS; i++) {
      drawFrame(i, offset);
    }
  } else {
      for (int i = MAX_ROWS - 1; i >= 0; i--) {
        drawFrame(i, offset);
      }
  }


  if (direction == 1) {
    offset++;
  } else {
    offset--;
  }

  

  Thread.Sleep(1000 / TARGET_FPS);

}
