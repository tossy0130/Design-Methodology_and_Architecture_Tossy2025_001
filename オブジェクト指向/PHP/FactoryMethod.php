<?php 

/*

Factory Method（ファクトリーメソッド）

・生成処理をサブクラスに委ねて柔軟にオブジェクトを生成する。

*/

interface Product {
    public function getName(): string;

}

class ConcreteProductA implements Product {
    public function getName(): string {
        return "Product A";
    }
}

class ConcreteProductB implements Product {
    public function getName(): string {
        return "Product B";
    }
}

abstract class Creator {
    abstract public function createProduct(): Product;
}

class CreatorA extends Creator {
    public function createProduct(): Product {
        return new ConcreteProductA();
    }
}

class CreatorB extends Creator {
    public function createProduct(): Product {
        return new ConcreteProductB();
    }
}

// ********* 使用 **********
$creator = new CreatorA();
$product = $creator->createProduct();
print $product->getName();  // Product A


?>