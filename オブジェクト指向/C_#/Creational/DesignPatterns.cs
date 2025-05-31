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


// Abstract Factory（抽象ファクトリ）パターン

/*
・UIライブラリなど、一式の部品をプラットフォームごとにまとめて切り替えたいとき
・Windows / Mac など 複数の関連製品をセットで生成
*/

public interface IButton {
    void Render(); // ボタンの表示動作
}

public class WinButton : IButton {
    public void Render() => Console.WriteLine("Windows ボタンのレンダリング");
}

public class MacButton : IButton {
    public void Render() => Console.WriteLine("Mac ボタンのレンダリング");
}

public class WinFactory : IGUIFactory {
    public IButton CreateButton() => new WinButton(); // Windows用
}

public class MacFactory : IGUIFactory {
    public IButton CreateButton() => new MacButton(); // mac 用
}

// === 使用 ===
IGUIFactory factory = new WinFactory();
IButton button = factory.CreateButton();
button.Render(); // Windows ボタンのレンダリング


// Builder（ビルダー）
/*

複雑なオブジェクトの生成手順を分離し、同じ構築手順で異なる表現を可能にする。

*/

public class Product {
    public string PartA { get; set; }
    public string PartB { get; set; }
}

public interface IBuilder {
    void BuildPartA();
    void BuildPartB();
    Product GetResult();
}

public class ConcreteBuilder : IBuilder {
    private Product product = new Product();

    public void BuildPartA() => product.PartA = "PartA";
    public void BuildPartB() => product.PartB = "PartB";
    public Product GetResult() => product;
 }

public class Director {
    public Product Construct(IBuilder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
        return builder.GetResult();
    }
 }

// Prototype（プロトタイプ）
/*

複製によって新しいインスタンスを生成（newを使わない）。

*/
public abstract class Prototype {
    public abstract Prototype Clone();
}

public class ConcretePrototype : Prototype {
    public int Data { get; set; }
    public override Prototype Clone() => (Prototype)this.MemberwiseClone();

}

// ============================ Structural（構造）パターン

//  Adapter（アダプター）

public interface ITarget {
    void Request();
}

public class AdaAdaptee {
    public void SpecificRequest() => Console.WriteLine("SpecificRequest")
}

public class Adapter : ITarget {
    private Adaptee _adaptee = new Adaptee();
    public void Request() => _adaptee.SpecificRequest();
}

// Bridge（ブリッジ）
public interface IImplementor {
    void OperationImpl();
}

public class ConcreteImplementorA : IImplementor {
    public void OperationImpl() => Console.WriteLine("A Impl");
}

public abstract class Abstraction {
    protected IImplementor _impl;
    public Abstraction(IImplementor impl) => _impl = iml;
    public abstract void Operation();
}

public class RefinedAbstraction : Abstraction {
    public RefinedAbstraction(IImplementor iml) : base(iml) { }
    public override void Operation() => _impl.OperationImpl();
}

// Composite（コンポジット）
public abstract class Component {
    public abstract void Operation();
}

public class Leaf : Component {
    public override void Operation() => Console.WriteLine("Leaf");
}

public class Composite : Component {
    private List<Component> children = new List<Component>();
    public void Add(Component c) => children.Add(c)
    public override void Operation() {
        foreach (var child in children) child.Operation();
    }
}
