namespace Labs {
  class Box {
    public int Width { get; set; }
    public int Height { get; set; }
    public int Depth { get; set; }

    public Box(int l, int w, int h) {
      Width = w;
      Height = h;
      Depth = l;
    }

    private int _width;
    public int WidthParam {
      get { return _width; }
      set { _width = value; }
    }

    private int _height;
    public int HeightParam {
      get { return _height; }
      set { _height = value; }
    }

    private int _depth;
    public int DepthParam {
      get { return _depth; }
      set { _depth = value; }
    }

    public int Volume() {
      return Width * Height * Depth;
    }

    public int VolumeParam() {
      return WidthParam * HeightParam * DepthParam;
    }
  }

  class Lab8 {
    public static void Run() {
      Box box = new Box(1, 2, 3);
      Console.WriteLine(box.Volume());

      box.Width = 4;
      box.Height = 5;
      box.Depth = 6;
      Console.WriteLine(box.Volume());

      box.WidthParam = 7;
      box.HeightParam = 8;
      box.DepthParam = 9;
      Console.WriteLine(box.VolumeParam());
    }
  }
}
