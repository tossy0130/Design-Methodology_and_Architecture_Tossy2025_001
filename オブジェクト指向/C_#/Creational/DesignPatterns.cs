// 1. Singleton Pattern

/*
・private constructor により、外部からの new を禁止。
・static プロパティ経由でアクセスするため、グローバルに安全に使える。
・lock を使っているのはマルチスレッド環境でも安全に初期化を行うため。
*/
public class Singleton
{
    private static Singleton _instance;

    // スレッドセーフ対策
    private static readonly object _lock = new object();
    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            lock (_lock) // スレッドセーフにインスタンスを生成
            {
                return _instance ??= new Singleton();
            }
        }
    }
}

// 2. Factory Method Pattern

/*

Creator クラスが 共通の生成インターフェース を提供。

ConcreteCreator が 具体的なインスタンスの生成 を担当。

クライアント側は Creator のインターフェースだけを使うので、柔軟に製品を差し替え可能。

*/
public abstract class Product
{
    public abstract void Use(); // 製品の共通操作
}

public class ConcreteProduct : Product
{
    public override void Use() => Console.WriteLine("ConcreteProductの使用")
}

public abstract class Creator {
    public abstract Product FactoryMethod(); // 製品の生成を委ねる
}

public class ConcreteCreator : Creator {
    public override Product FactoryMethod() => new ConcreteProduct(); // 具体的な生成方法
}
