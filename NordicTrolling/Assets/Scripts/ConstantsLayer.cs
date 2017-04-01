using System;

public static class ConstantsLayer
{
    public static int terrain = 8;
    public static int troll = 9;
    public static int trap = 10;
    public static int obstacle = 11;
    public static int viking = 12;

    public static int BIT( params int[] x ) {
        int ret = 0;
        foreach( int i in x )
            ret |= 1 << i;
        return ret;
    }
}
