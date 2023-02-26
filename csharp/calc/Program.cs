while (true) {
  string rawData = Console.ReadLine();

  if (rawData == null) {
    break;
  }

  string[] data = rawData.Split(' ');

  double a = Convert.ToDouble(data[0]);
  char operation = data[1][0];
  double b = Convert.ToDouble(data[2]);

  double result = 0;
  switch (operation) {
    case '+':
      result = a + b;
      break;
    case '-':
      result = a - b;
      break;
    case '*':
      result = a * b;
      break;
    case '/':
      result = a / b;
      break;
  }

  Console.WriteLine(result);
}
