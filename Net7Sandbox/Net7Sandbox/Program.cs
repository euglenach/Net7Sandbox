// See https://aka.ms/new-console-template for more information

using System.Numerics;
using static iostream;

Console.WriteLine(Sum(1,2,3,4,5,6,7,8,9));
Console.WriteLine(Sum2(1,2,3,4,5,6,7,8,9));
Console.WriteLine(Radix<int>());
Console.WriteLine(Radix<float>());
Console.WriteLine(Radix<double>());
Console.WriteLine(Radix<byte>());
Console.WriteLine(Radix<short>());
Console.WriteLine(Radix<uint>());
Console.WriteLine(Radix<nint>());
Console.WriteLine(Radix<nuint>());
Console.WriteLine(Radix<long>());

ReadOnlySpan<byte> utf8 = "aaaaa"u8;
utf8 = "a"u8 + "b"u8 + "c"u8; 
Console.WriteLine("aaaaa"u8.Length);
Console.WriteLine(utf8.Length);
Console.WriteLine(IsAbcBytes(utf8));

1.M(); // ここのファイル内だけの拡張メソッド

Console.WriteLine(LogicalLeftShift(1, 4));
Console.WriteLine(LogicalLeftShift((byte)1, 4));
Console.WriteLine(LogicalLeftShift((short)1, 14));
Console.WriteLine(LogicalLeftShift((ushort)1, 15));

_ = cout << "Hello World!" << endl;

var b = Random.Shared.Next() % 2 == 0;
var u8 = b? "abc"u8 : stackalloc byte[]{97, 98, 99};

var x = 0;
var y = 1;

var quote = """
    " はそのまま " として使われて、
    \ も \ のままの意味。
    \\ は \ が2個。
    {} とかも特別な解釈はされない。{
    インデントの空白文字はスルーされる(そもそもへこませるとエラーになる)
    "を3つ並べて書きたいときは "を4つ並べて始める 4つ以上も同様。何個でもいい
    """; // ここの行のインデントが文字の開始位置の基準になる。これより前のスペースは消える

var quote2 = $""""
    {nameof(x)} : {x} この中で単体の波カッコは使えない？？？？？
    {nameof(y)} : {y}
    """";

var quote3 = $$"""
    {nameof(x)} : {x} これは補間されない
    {{nameof(y)}} : {{y}} これは補間される
    """;

var quote4 = $$""" 
    {nameof(x)} : {x} これは補間されない
    {{nameof(y)}} : {{y}} これは補間される
    """;

var quote5 = """"
    "を3つ並べて書きたいときは "を4つ並べて始める 4つ以上も同様。何個でもいい """
    """";

var quote6 = """"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
    """"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""" ←1個少ない
    """""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""";

// 単一行生文字列。
var singleLine = """この中身が文字列リテラル""";

// 複数行生文字列。
var multiLine = """
    この行が文字列リテラル。この前後には改行文字は残らない。
    """;

// 複数行生文字列。
var multiLine2 = """                 
    この行が文字列リテラル。↑にスペースがあっても無視
    """;

ReadOnlySpan<byte> utf8Json = """
    {
      "id": 123,
      "name": "abc",
      "flag": true
    }
    """u8; // utf8もできる


T Sum<T>(params T[] sources) where T : INumber<T>
{
    var total = T.Zero;

    foreach(var number in sources)
    {
        total += number;
    }
    
    return total;
}

T Sum2<T>(params T[] sources) where T : INumber<T>
{
    return sources.Aggregate(T.Zero, (current, number) => current + number);
}

int Radix<T>() where T : INumber<T>
{
    return T.Radix;
}

T Zero<T>() where T : INumber<T>
{
    return T.Zero;
}

static T LogicalLeftShift<T>(T s, int bits)
    where T : IShiftOperators<T,int,T>
    => s << bits;


bool IsAbcChars(ReadOnlySpan<char> x) => x is "abc";
bool IsAbcBytes(ReadOnlySpan<byte> x) => x is [ 97, 98, 99 ];

record struct Str();
record Cla();

struct S
{
    private int i = 111;
    private string str = $"aaaa";

    public S()
    {
        i = 123;
        str = "bbbbb";
    }

    public S(int i, string str)
    {
        this.i = i;
        this.str = str;
    }
}

ref struct ByReference<T>
{
    public ref T Value;
}

file static class Extensions
{
    public static void M(this int x) => Console.WriteLine(x);
}

public static class iostream
{
    public static readonly ConsoleOut cout = new();
    public static readonly ConsoleEndLine endl = new();

    public struct ConsoleOut
    {
        public static ConsoleOut operator <<(ConsoleOut x, string value) { Console.Write(value); return x; }
        public static ConsoleOut operator <<(ConsoleOut x, ConsoleEndLine _) { Console.WriteLine(); return x; }
    }

    public struct ConsoleEndLine { }
}