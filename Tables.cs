namespace zaba
{
    static public class CharTable
    {
        public static char Wall { get; } = '█';
        public static char Apple { get; } = '@';
        public static char Body { get; } = 'o';
        public static char Head { get; } = '0';
    }
    static public class StartCoords
    {
        public static int xPos { get; } = 30;
        public static int yPos { get; } = 10;
        public static int lenght { get; } = 7;
    }
    
    static public class cWnd
    {
        public static int xmin { get; } = 1;
        public static int xmax { get; } = 60;
        public static int ymin { get; } = 3;
        public static int ymax { get; } = 30;
    }
}